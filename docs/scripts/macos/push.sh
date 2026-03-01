#!/bin/bash

clear

LOCAL_BRANCH="master-local"
REMOTE_BRANCH="origin/master"
CURRENT_BRANCH=$(git branch --show-current)

# Switch/create master-local
if [ "$CURRENT_BRANCH" != "$LOCAL_BRANCH" ]; then
  if git show-ref --verify --quiet "refs/heads/$LOCAL_BRANCH"; then
    git checkout "$LOCAL_BRANCH" || exit 1
  else
    echo "ℹ Creating branch $LOCAL_BRANCH from master..."
    git checkout -b "$LOCAL_BRANCH" master || exit 1
  fi
fi

# Get yesterday 00:00
YESTERDAY_DATE=$(date -v-1d +"%Y-%m-%d")
COMMIT_TIMESTAMP="${YESTERDAY_DATE}T00:00:00 +0000"

# Find commits not pushed yet
BASE=$(git merge-base "$LOCAL_BRANCH" "$REMOTE_BRANCH")
LOCAL_COMMITS=$(git rev-list "$BASE"..HEAD)

if [ -z "$LOCAL_COMMITS" ]; then
  echo "ℹ No new commits to rewrite."
else
  NUM_COMMITS=$(echo "$LOCAL_COMMITS" | wc -l)
  echo "ℹ Rewriting $NUM_COMMITS new commit(s)..."

  # Loop through commits from oldest to newest using tail -r (reverse)
  echo "$LOCAL_COMMITS" | tail -r | while read commit; do
    MESSAGE=$(git log --format=%s -n 1 "$commit")
    echo "✏️ Rewriting commit $commit: $MESSAGE"
    
    GIT_COMMITTER_DATE="$COMMIT_TIMESTAMP" \
    GIT_AUTHOR_DATE="$COMMIT_TIMESTAMP" \
    git commit --amend -S --no-edit "$commit" >/dev/null 2>&1
    
    if [ $? -eq 0 ]; then
      echo "✅ Commit $commit updated."
    else
      echo "❌ Failed to update commit $commit."
    fi
  done
fi

echo "✅ All new commits on $LOCAL_BRANCH are now dated $COMMIT_TIMESTAMP and signed."

# Return to original branch
if [ "$CURRENT_BRANCH" != "$LOCAL_BRANCH" ]; then
  git checkout "$CURRENT_BRANCH"
fi

# Prompt for merge & push
read -p "Do you want to merge $LOCAL_BRANCH into master and push? (y/n): " PUSH_CONFIRM
if [[ "$PUSH_CONFIRM" =~ ^[Yy](es)?$ ]]; then
  git checkout master || exit 1
  git merge --no-ff "$LOCAL_BRANCH" -m "Merge $LOCAL_BRANCH into master" || exit 1
  git push || exit 1
  echo "✅ master updated and pushed."
else
  echo "ℹ Merge and push skipped."
fi

echo "Done."