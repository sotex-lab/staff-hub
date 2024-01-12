## Convetional commits
We use [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/) and each MR should have a title structured as the following example:
```bash
type(scope): message
```
Even though the check will pass if you ommit `(scope)` the team will ask you to adhere to this policy so we maintain the quality of history.

## Building and linting of dotnet code
In the process of automatic quality checking of code we run linting and building. While we accept building warnings (which we might remove at some point in the future), we won't accept code that is not linted properly.

When the check fails due to linting one should simply run the following command:
```bash
dotnet format StaffHub.sln
```
After that the tool will automatically lint the solutions and they can push the linted code which will then result in a green check mark on the check.
