# GitHub Workflows Convention

This repository utilizes GitHub Actions workflows for automating various tasks. GitHub Actions allows you to automate your software development workflows directly within your repository.

## What are GitHub Workflows?

GitHub Workflows are custom automated processes that you can define in your repository. These workflows are triggered by various events, such as pushes to a repository, pull requests, or other activities. They help automate tasks like building, testing, and deploying your code.

## Convention: One Job per File

To maintain clarity and organization, we follow a convention of placing one job configuration in one file. Each workflow job is defined in a separate YAML file within the `.github/workflows/` directory.

### Example Structure:

```bash
.github/workflows/
│ build.yml
│ test.yml
│ deploy.yml
```

This convention makes it easier to manage and understand individual workflows, promoting a clean and maintainable codebase.

## Contributing

Feel free to contribute by creating or enhancing existing workflows based on our convention. If you have suggestions or improvements, open an issue or submit a pull request.
