#!/bin/bash

set -e
clear
set -x

# Ensure we are in a Git repository
if ! git rev-parse --is-inside-work-tree > /dev/null 2>&1; then
  echo "❌ Not a Git repository."
  exit 1
fi

# Checkout master
git checkout master

# Stage all changes
git add -A

# Check if there is anything to commit
if git diff --cached --quiet; then
  echo "❌ No changes to commit."
  exit 1
fi

# Prompt for commit message
read -p "Enter commit message: " COMMIT_MESSAGE
if [ -z "$COMMIT_MESSAGE" ]; then
  echo "❌ Commit message cannot be empty."
  exit 1
fi

# Yesterday at 00:00
YESTERDAY_DATE=$(date -v-1d +"%Y-%m-%d")
COMMIT_TIMESTAMP="${YESTERDAY_DATE}T00:00:00+0000"

# Create commit with forced timestamp
GIT_COMMITTER_DATE="$COMMIT_TIMESTAMP" \
git commit --date="$COMMIT_TIMESTAMP" -m "$COMMIT_MESSAGE"

echo "✅ Commit created on master with date: $COMMIT_TIMESTAMP"