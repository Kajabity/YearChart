# Release Versioning

## Purpose

Define how YearChart versions are assigned for builds and releases.

## Decisions

* YearChart uses semantic versioning.
* The next release version is `0.5.0`.
* A Git tag in the form `X.Y.Z` is the source of truth for release versions.
* Build and release version values must be derived from the tagged release version rather than duplicated in multiple files.
* Pushing a release tag triggers the GitHub Actions release workflow.
* Release builds produce the Windows installer as a release artifact.
* The installer version must match the tagged release version.
* `CHANGELOG.md` records notable changes for each release.
* Before creating a release tag, `CHANGELOG.md` must be updated with the release version and date.
* GitHub release notes should be based on the corresponding `CHANGELOG.md` entry.
