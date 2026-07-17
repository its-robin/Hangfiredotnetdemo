# Contributing to Hangfire.AlertingDemo

Thank you for your interest in contributing! We welcome contributions of all kinds, including bug reports, feature requests, documentation improvements, and code contributions.

## 🐛 Reporting Issues

Before submitting an issue, please:
1. Search [existing issues](https://github.com/its-robin/Hangfiredotnetdemo/issues) to avoid duplicates
2. Check the [discussions](https://github.com/its-robin/Hangfiredotnetdemo/discussions) for common questions

**When reporting a bug, include:**
- A clear description of the issue
- Steps to reproduce
- Expected vs actual behavior
- Environment details (.NET version, OS, etc.)
- Error stacktrace or logs if applicable

## 💡 Feature Requests

We're excited about ideas to improve this project! Please:
1. Check if the feature is already requested
2. Describe the use case and benefit
3. Provide code examples or mockups if applicable

## 🔧 Development Setup

### Prerequisites
- .NET 8 SDK
- Visual Studio, VS Code, or Rider
- Git

### Getting Started

```bash
# Fork and clone the repository
git clone https://github.com/your-username/Hangfiredotnetdemo.git
cd Hangfiredotnetdemo

# Create a feature branch
git checkout -b feature/your-feature-name

# Build the solution
dotnet build

# Run the project
dotnet run --project Hangfire.AlertingDemo.Web
```

## 📝 Making Changes

1. **Keep commits atomic** - One logical change per commit
2. **Write clear commit messages** - Start with a verb (Add, Fix, Update, etc.)
3. **Follow C# conventions** - Use the existing code style
4. **Add comments** - For complex logic only
5. **Update documentation** - If your changes affect how the project is used

### Commit Message Examples
```
Add support for job retry policies
Fix database connection timeout issue
Update README with Docker setup instructions
Refactor AlertService to use dependency injection
```

## 🧪 Testing

Before submitting a PR:

```bash
# Build the project
dotnet build

# Run tests (when available)
dotnet test

# Verify no warnings
```

## 📤 Submitting a Pull Request

1. **Create a descriptive title** - What does it do?
2. **Provide context in the description**:
   - Why this change is needed
   - What problem does it solve
   - Any breaking changes
   - Screenshots (for UI changes)

3. **Link related issues** - Use "Closes #123"

4. **Keep it focused** - One feature/fix per PR

### PR Template
```markdown
## Description
Brief description of changes

## Motivation and Context
Why is this change needed? What problem does it solve?

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Testing Done
How was this tested?

## Checklist
- [ ] Code builds without errors
- [ ] No new warnings introduced
- [ ] Tests pass (if applicable)
- [ ] Documentation updated (if needed)
- [ ] Commit messages are clear
```

## 📌 Code Style Guidelines

### C# Conventions
```csharp
// Use PascalCase for public members
public class MyService { }

// Use camelCase for private/local variables
private string _connectionString;

// Use async/await
public async Task ExecuteJobAsync() { }

// Use null-coalescing operators
var value = config?.Setting ?? defaultValue;

// Use string interpolation
var message = $"Job {jobId} completed in {elapsed}ms";
```

### Naming Conventions
- Classes/Methods: `PascalCase`
- Properties: `PascalCase`
- Private fields: `_camelCase`
- Local variables: `camelCase`
- Constants: `UPPER_SNAKE_CASE`
- Async methods: End with `Async`

## 📚 Documentation Contributions

We value documentation improvements! You can help by:
- Fixing typos or grammar
- Adding examples or tutorials
- Clarifying confusing sections
- Adding comments to complex code
- Translating documentation

## 🎓 Licensing

By contributing, you agree that your contributions will be licensed under the MIT License.

## ❓ Questions?

- Check the [README](README.md)
- Browse [discussions](https://github.com/its-robin/Hangfiredotnetdemo/discussions)
- Open an issue with the `question` label

## 🙏 Thank You!

Your contributions help make this project better for everyone. We appreciate your time and effort!

---

**Happy coding! 🚀**
