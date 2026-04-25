Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path

if (-not (Get-Command pre-commit -ErrorAction SilentlyContinue)) {
  Write-Error "The 'pre-commit' command was not found. Install pre-commit first, then rerun this script."
}

pre-commit install --install-hooks --config (Join-Path $repoRoot ".pre-commit-config.yaml")

Write-Host "pre-commit hooks are now installed for this repository."
Write-Host "Use 'pre-commit run --all-files' to run the checks manually."
