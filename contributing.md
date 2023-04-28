# Contributing Guide

👋 Thank you for investing your time in contributing to our project! Any contribution you make will be reflected
on [docs.github.com](https://docs.github.com/en).

Read our [Code of Conduct](./code_of_conduct.md) to keep our community approachable and respectable. Be respectful and kind when interacting with other members of the community.

In this guide, you will get an overview of the contribution workflow, from opening an issue to creating a PR, reviewing, and merging the PR.

## New Contributor Guide

To get an overview of the project, read the [README](README.md). Here are some resources to help you get started with open-source contributions:

- [Finding ways to contribute to open source on GitHub](https://docs.github.com/en/get-started/exploring-projects-on-github/finding-ways-to-contribute-to-open-source-on-github) 🕵️
- [Set up Git](https://docs.github.com/en/get-started/quickstart/set-up-git) 🐙
- [GitHub flow](https://docs.github.com/en/get-started/quickstart/github-flow) 🌊
- [Collaborating with pull requests](https://docs.github.com/en/github/collaborating-with-pull-requests) 🤝

## Getting Started

To navigate our codebase with confidence, see [the introduction to working in the docs repository](/contributing/working-in-docs-repository.md). For more information on how we write our markdown files, see [the GitHub Markdown reference](contributing/content-markup-reference.md).

Check to see what [types of contributions](/contributing/types-of-contributions.md) we accept before making changes. Some of them don't even require writing a single line of code.

### Issues

#### Create a New Issue

If you spot a problem with the docs, [search if an issue already exists](https://docs.github.com/en/github/searching-for-information-on-github/searching-on-github/searching-issues-and-pull-requests#search-by-the-title-body-or-comments). If a related issue doesn't exist, you can open a new issue using a relevant [issue form](https://github.com/github/docs/issues/new/choose).

#### Solve an Issue

Scan through our [existing issues](https://github.com/github/docs/issues) to find one that interests you. You can narrow down the search using `labels` as filters. See [Labels](/contributing/how-to-use-labels.md) for more information. As a general rule, we don’t assign issues to anyone. If you find an issue to work on, you are welcome to open a PR with a fix.

### Make Changes

#### Make Changes in the UI

Click **Make a contribution** at the bottom of any docs page to make small changes such as a typo, sentence fix, or a broken link. This takes you to the `.md` file where you can make your changes and [create a pull request](#pull-request) for a review. 📝

#### Make Changes in a Codespace

For more information about using a codespace for working on GitHub documentation, see "[Working in a codespace](https://github.com/github/docs/blob/main/contributing/codespace.md)." 💻

#### Make Changes Locally

1. [Install Git LFS](https://docs.github.com/en/github/managing-large-files/versioning-large-files/installing-git-large-file-storage). 📦 This is required to handle large files that may be part of the repository.

2. Fork the repository. 🍴 This creates a copy of the original repository on your own GitHub account, which you can modify without affecting the original project until you're ready to merge your changes.

- Using GitHub Desktop:
    - [Getting started with GitHub Desktop](https://docs.github.com/en/desktop/installing-and-configuring-github-desktop/getting-started-with-github-desktop) will guide you through setting up Desktop.
    - Once Desktop is set up, you can use it to [fork the repo](https://docs.github.com/en/desktop/contributing-and-collaborating-using-github-desktop/cloning-and-forking-repositories-from-github-desktop)!

- Using the command line:
    - [Fork the repo](https://docs.github.com/en/github/getting-started-with-github/fork-a-repo#fork-an-example-repository) so that you can make your changes without affecting the original project until you're ready to merge them.

3. Install or update to the required tools or libraries. For more information, see [the development guide](contributing/development.md). 💻

4. Create a working branch and start with your changes! 🌳 This helps keep your changes separate from the main branch and makes it easier to track and manage your work.

### Commit Your Update

Commit the changes once you are happy with them. 💬 This creates a snapshot of your changes that you can revert to if needed. See [Atom's contributing guide](https://github.com/atom/atom/blob/master/CONTRIBUTING.md#git-commit-messages) to know how to use emoji for commit messages.

Once your changes are ready, don't forget to [self-review](/contributing/self-review.md) to speed up the review process.🔍

### Pull Request

When you're finished with the changes, create a pull request, also known as a PR. 🚀

- Fill the "Ready for review" template so that we can review your PR. This template helps reviewers understand your changes as well as the purpose of your pull request.
- Don't forget to [link PR to issue](https://docs.github.com/en/issues/tracking-your-work-with-issues/linking-a-pull-request-to-an-issue) if you are solving one. 🔗
- Enable the checkbox to [allow maintainer edits](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/allowing-changes-to-a-pull-request-branch-created-from-a-fork) so the branch can be updated for a merge.
- Once you submit your PR, a Docs team member will review your proposal. We may ask questions or request for additional information.
- We may ask for changes to be made before a PR can be merged, either using [suggested changes](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/incorporating-feedback-in-your-pull-request) or pull request comments. You can apply suggested changes directly through the UI. You can make any other changes in your fork, then commit them to your branch.
- As you update your PR and apply changes, mark each conversation as [resolved](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/commenting-on-a-pull-request#resolving-conversations).
- If you run into any merge issues, checkout this [git tutorial](https://lab.github.com/githubtraining/managing
