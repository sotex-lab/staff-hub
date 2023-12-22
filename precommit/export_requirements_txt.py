from pathlib import Path
from subprocess import run

def export_requirements_txt():
    poetry_lock = Path("poetry.lock")
    if poetry_lock.exists():
        run(["poetry", "export", "--format=requirements.txt", "--output=requirements.txt"], check=True)

if __name__ == "__main__":
    export_requirements_txt()
