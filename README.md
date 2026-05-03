Kajabity YearChart
===================

[![Build](https://github.com/Kajabity/YearChart/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/Kajabity/YearChart/actions/workflows/build.yml)
[![Vulnerability Scan](https://github.com/Kajabity/YearChart/actions/workflows/vulnerability-scan.yml/badge.svg?branch=master)](https://github.com/Kajabity/YearChart/actions/workflows/vulnerability-scan.yml)
[![Secret Scan](https://github.com/Kajabity/YearChart/actions/workflows/secret-scan.yml/badge.svg?branch=master)](https://github.com/Kajabity/YearChart/actions/workflows/secret-scan.yml)
[![Dependabot](https://img.shields.io/badge/Dependabot-enabled-025e8c?logo=dependabot)](https://github.com/Kajabity/YearChart/blob/master/.github/dependabot.yml)
[![License](https://img.shields.io/badge/License-Apache--2.0-blue.svg)](LICENSE.md)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/platform-Windows-0078D4?logo=windows)](YearChart/YearChart.csproj)

YearChart is a Windows desktop application for creating printable day-to-day charts for date ranges from 1 day to 5 years.

It is useful for financial year planners, academic year planners, and other calendar-style planning layouts that are awkward to produce and maintain in a spreadsheet.

Features
--------

* Print a year planner for any year or any range of dates up to 5 years.
* Print on any size of paper your printer can print to.
* Includes Print Preview and Page Setup.
* Customise the title and first day of the week.
* Add extra labelled rows or columns to the chart.
* Includes built-in help.

Current Status
--------------

* Windows-only desktop application.
* WinForms application with a WiX installer project.
* GitHub Actions workflows for build, secret scanning, vulnerability scanning, and dependency update automation.
* The current codebase builds with the .NET 10 SDK.

Build
-----

From the repository root:

```powershell
dotnet restore YearChart.sln
dotnet build YearChart.sln -c Release
```

The application project is in `YearChart/` and the installer project is in `YearChart.WiX/`.

Quality And Security
--------------------

* GitHub Actions is used for CI.
* Dependabot is enabled for dependency updates.
* Secret scanning is configured locally via `pre-commit` and in GitHub Actions.
* Vulnerability scanning is configured in GitHub Actions.
* CodeQL is not currently configured; static security coverage is currently provided by secret scanning and NuGet vulnerability scanning.

Project Notes
-------------

* This repository is being modernised incrementally.
* Small specs for engineering and feature work live under `specs/`.

For much more detail on the original application, see <http://www.kajabity.com/year-chart/>.
