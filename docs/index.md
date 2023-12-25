# Staff hub

This is an internal project of [Sotex Solutions](https://www.sotexsolutions.com/) that is used for managing staff. It is maintained by the team and is meant to be beginner friendly whilst keeping a high quality of code.

## Setup
This project is meant to be cross platform and should be runnable both from Windows, (any) Linux and MacOS.

### List of software needed
1. [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) - chosen [SDK](https://aws.amazon.com/what-is/sdk/) and [Runtime](https://en.wikipedia.org/wiki/Runtime_system) for this project
2. [python](https://www.python.org/downloads/) - if you opt for pyenv you can use that to install any version of python so this can be skipped
3. (Optional) [pyenv](https://github.com/pyenv/pyenv?tab=readme-ov-file#installation) - python version management system, it isn't supported for Windows, but there is a fork which adds that support [here](https://github.com/pyenv-win/pyenv-win)
4. [poetry](https://python-poetry.org/docs/#installing-with-the-official-installer) - python dependency management system, used for creating environments and easier porting to different platforms.

### Pre-commit hooks
Pre-commit hooks are a great way to have some general checks of your files locally before even creating a commit. Usually they are used to lint the code, automatically format files, and can do much much more.
```bash
# when you have python installed run the following command in the root of repository
pip install pre-commit
pre-commit install
```

### Setup on Windows
Since Windows has a lot of incompatibilities with other operating systems its suggested to use [WSL](https://en.wikipedia.org/wiki/Windows_Subsystem_for_Linux).

To install it here is a great [article](https://learn.microsoft.com/en-us/windows/wsl/install) from Microsoft on how to do that.

**NOTE**: Onces the setup of WSL is complete you should add all the software from _[List of software needed](#list-of-software-needed)_
