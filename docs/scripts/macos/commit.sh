#!/bin/bash

# Ensure we are inside a Git repository
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

# Stage all changes automatically
git add -A

# Check if there is anything to commit
if git diff --cached --quiet; then
  echo "❌ No changes to commit."
  exit 1
fi

# Prompt for commit message
echo "Enter commit message:"
read -r COMMIT_MESSAGE

# Validate empty message
if [ -z "$COMMIT_MESSAGE" ]; then
  echo "❌ Commit message cannot be empty."
  exit 1
fi

# Get yesterday's date (BSD date for macOS)
YESTERDAY_DATE=$(date -v-1d +"%Y-%m-%d")

# Build ISO timestamp at 00:00:00
COMMIT_TIMESTAMP="${YESTERDAY_DATE}T00:00:00"

# Create signed commit with forced timestamp
GIT_AUTHOR_DATE="$COMMIT_TIMESTAMP" \
GIT_COMMITTER_DATE="$COMMIT_TIMESTAMP" \
git commit -S -m "$COMMIT_MESSAGE"

if [ $? -eq 0 ]; then
  echo "✅ Signed commit created with date: $COMMIT_TIMESTAMP"
else
  echo "❌ Commit failed. Check your GPG setup."
fi