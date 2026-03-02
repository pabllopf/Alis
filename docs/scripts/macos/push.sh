#!/bin/bash
# push_local_commits_yesterday.sh
# Update only local commits not yet pushed, set date to yesterday 00:00, and optionally push.

set -e
clear
set -x

REMOTE_BRANCH="origin/master"
CURRENT_BRANCH=$(git branch --show-current)

# Ensure we are on master
if [ "$CURRENT_BRANCH" != "master" ]; then
  git checkout master
fi

# Ensure working tree is clean
if ! git diff --quiet || ! git diff --cached --quiet; then
  echo "⚠️ You have uncommitted changes. Stashing temporarily..."
  git stash push -m "temp before rewriting local commits"
fi

# Get yesterday 00:00
YESTERDAY_DATE=$(date -v-1d +"%Y-%m-%d")
COMMIT_TIMESTAMP="${YESTERDAY_DATE}T00:00:00 +0000"

# Find commits that are local only
BASE=$(git merge-base master "$REMOTE_BRANCH")
LOCAL_COMMITS=$(git rev-list "$BASE"..HEAD)

if [ -z "$LOCAL_COMMITS" ]; then
  echo "ℹ No new local commits to rewrite."
else
  NUM_COMMITS=$(echo "$LOCAL_COMMITS" | wc -l)
  echo "ℹ Rewriting $NUM_COMMITS local commit(s) with date $COMMIT_TIMESTAMP..."

  # Non-interactive rebase to update dates of local commits
  # GIT_SEQUENCE_EDITOR=true avoids opening editor
  GIT_SEQUENCE_EDITOR=true git rebase -i "$BASE" --exec \
    "GIT_AUTHOR_DATE='$COMMIT_TIMESTAMP' GIT_COMMITTER_DATE='$COMMIT_TIMESTAMP' git commit --amend --no-edit" || {
      echo "❌ Error during rebase."
      exit 1
  }

  echo "✅ Local commits updated with new date."
fi

# Push to master automatically
read -p "Do you want to push updated master to origin? (y/n): " PUSH_CONFIRM
if [[ "$PUSH_CONFIRM" =~ ^[Yy](es)?$ ]]; then
  git push origin master --force
  echo "✅ master pushed to origin with updated commit dates."
else
  echo "ℹ Push skipped."
fi

echo "Done."