#!/bin/bash

# Clear console
clear


# Ensure we're in a Git repo
if ! git rev-parse --is-inside-work-tree > /dev/null 2>&1; then
  echo "❌ This is not a Git repository."
  exit 1
fi

# Ensure GPG signing is configured
if ! git config --get user.signingkey > /dev/null; then
  echo "❌ No GPG signing key configured."
  echo "Run: git config --global user.signingkey YOUR_KEY_ID"
  exit 1
fi

# Name of the local branch for commits
LOCAL_BRANCH="master-local"

# Check current branch
CURRENT_BRANCH=$(git branch --show-current)

# If not on LOCAL_BRANCH, create or switch to it
if [ "$CURRENT_BRANCH" != "$LOCAL_BRANCH" ]; then
  if git show-ref --verify --quiet "refs/heads/$LOCAL_BRANCH"; then
    git checkout "$LOCAL_BRANCH" || exit 1
  else
    git checkout -b "$LOCAL_BRANCH" || exit 1
  fi
  echo "ℹ Now on branch $LOCAL_BRANCH"
fi

# Stage all changes automatically
git add -A

# Check if there's anything to commit
if git diff --cached --quiet; then
  echo "❌ No changes to commit."
  exit 1
fi

# Prompt for commit message
read -p "Enter commit message: " COMMIT_MESSAGE

# Validate empty message
if [ -z "$COMMIT_MESSAGE" ]; then
  echo "❌ Commit message cannot be empty."
  exit 1
fi

# Get yesterday's date (macOS BSD date)
YESTERDAY_DATE=$(date -v-1d +"%Y-%m-%d")
COMMIT_TIMESTAMP="${YESTERDAY_DATE}T00:00:00 +0000"

# Create signed commit with forced timestamp
GIT_AUTHOR_DATE="$COMMIT_TIMESTAMP" \
GIT_COMMITTER_DATE="$COMMIT_TIMESTAMP" \
git commit -S -m "$COMMIT_MESSAGE"

if [ $? -eq 0 ]; then
  echo "✅ Signed commit created on branch $LOCAL_BRANCH with date: $COMMIT_TIMESTAMP"
else
  echo "❌ Commit failed. Check your GPG setup."
fi