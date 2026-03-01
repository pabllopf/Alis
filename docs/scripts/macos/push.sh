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

# Check commits to rewrite (local only)
BASE=$(git merge-base "$LOCAL_BRANCH" "$REMOTE_BRANCH")
LOCAL_COMMITS=$(git rev-list "$BASE"..HEAD)

if [ -z "$LOCAL_COMMITS" ]; then
  echo "ℹ No new commits to rewrite."
else
  NUM_COMMITS=$(echo "$LOCAL_COMMITS" | wc -l)
  echo "ℹ Rewriting $NUM_COMMITS new commit(s)..."

  # Non-interactive rebase of all local commits
  git rebase --onto "$BASE" "$BASE" "$LOCAL_BRANCH" \
    -x "GIT_AUTHOR_DATE='$COMMIT_TIMESTAMP' GIT_COMMITTER_DATE='$COMMIT_TIMESTAMP' git commit --amend -S --no-edit" || { 
      echo "❌ Error during rebase."; 
      exit 1; 
    }

  echo "✅ All new commits on $LOCAL_BRANCH are now dated $COMMIT_TIMESTAMP and signed."
fi

# Return to original branch if needed
if [ "$CURRENT_BRANCH" != "$LOCAL_BRANCH" ]; then
  git checkout "$CURRENT_BRANCH"
fi

# Prompt for merge & push
read -p "Do you want to merge $LOCAL_BRANCH into master and push? (y/n): " PUSH_CONFIRM
if [[ "$PUSH_CONFIRM" =~ ^[Yy](es)?$ ]]; then
  git checkout master || exit 1
  echo "ℹ Creating merge commit with date $COMMIT_TIMESTAMP..."
  GIT_AUTHOR_DATE="$COMMIT_TIMESTAMP" \
  GIT_COMMITTER_DATE="$COMMIT_TIMESTAMP" \
  git merge --no-ff "$LOCAL_BRANCH" -m "Merge $LOCAL_BRANCH into master" || exit 1
  git push || exit 1
  echo "✅ master updated and pushed."
else
  echo "ℹ Merge and push skipped."
fi

echo "Done."