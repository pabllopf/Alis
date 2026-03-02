#!/bin/bash

clear

# Branch for new commits
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
  echo "ℹ Now on $LOCAL_BRANCH"
fi

# Get yesterday at 00:00
YESTERDAY_DATE=$(date -v-1d +"%Y-%m-%d")
COMMIT_TIMESTAMP="${YESTERDAY_DATE}T00:00:00 +0000"

# Determine commits that are local-only (not in remote)
BASE=$(git merge-base "$LOCAL_BRANCH" "$REMOTE_BRANCH")
echo "ℹ Rewriting commits since remote base: $BASE"

# Non-interactive rebase of only local commits
git rebase -i "$BASE" -x "GIT_AUTHOR_DATE='$COMMIT_TIMESTAMP' GIT_COMMITTER_DATE='$COMMIT_TIMESTAMP' git commit --amend -S --no-edit" || { echo "❌ Error during rebase."; exit 1; }

echo "✅ All new commits on $LOCAL_BRANCH are now dated $COMMIT_TIMESTAMP and signed."

# Prompt for merge and push
read -p "Do you want to merge $LOCAL_BRANCH into master and push? (y/n): " PUSH_CONFIRM
if [[ "$PUSH_CONFIRM" =~ ^[Yy](es)?$ ]]; then
  git checkout master || exit 1
  git merge --no-ff "$LOCAL_BRANCH" -m "Merge $LOCAL_BRANCH into master" || exit 1
  git push || exit 1
  echo "✅ master branch updated and pushed successfully."
else
  echo "ℹ Merge and push skipped."
fi