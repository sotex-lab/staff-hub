# Installs needed extensions for the users by default

# List of extensions in JSON format
$installed = (code --list-extensions) -split "`r`n" | Sort-Object
$want_install = (Get-Content .vscode/extensions.json | ConvertFrom-Json).recommendations | Sort-Object

# Extensions to install
$to_install = Compare-Object $installed $want_install | Where-Object { $_.SideIndicator -eq '=>' } | ForEach-Object { $_.InputObject }

# Install extensions
$to_install | ForEach-Object { code --force --install-extension $_ }
