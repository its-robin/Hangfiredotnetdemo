# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Enhanced README with comprehensive documentation
- CONTRIBUTING.md guidelines
- GitHub issue templates
- CODE_OF_CONDUCT.md

### Changed
- Improved project structure documentation

## [1.0.0] - 2024-01-XX

### Added
- Initial release of Hangfire.AlertingDemo
- Fire-and-forget job support
- Delayed job scheduling
- Recurring job execution
- Job continuations
- Hangfire Dashboard integration
- SQL Server/LocalDB persistence
- REST API for job management
- Web UI for job triggering
- Example services: AlertService, EmailService, ReportService

### Features
- Complete .NET 8 implementation
- LocalDB/SQL Server storage
- Real-time job monitoring
- Simple and easy-to-understand codebase

---

## How to Update This Changelog

When making a release:
1. Replace `[Unreleased]` section with `[X.Y.Z] - YYYY-MM-DD`
2. Create a new `[Unreleased]` section
3. Use these categories:
   - **Added**: for new features
   - **Changed**: for changes in existing functionality
   - **Deprecated**: for soon-to-be removed features
   - **Removed**: for now removed features
   - **Fixed**: for any bug fixes
   - **Security**: in case of security vulnerabilities

Example:
```markdown
## [1.1.0] - 2024-02-15

### Added
- Docker support (Dockerfile and docker-compose.yml)
- Authentication for Hangfire Dashboard

### Fixed
- Connection timeout issue with LocalDB
```
