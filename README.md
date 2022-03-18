[![.NET Core Desktop](https://github.com/fz0000/Win11ContextMenu/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/fz0000/Win11ContextMenu/actions/workflows/dotnet-desktop.yml)

# Win11ContextMenu
Change Win11 context menu to classic style

## How

We can easily find the answer on Google:

To change to the old style context menu (Without the "Show More Options" step), just add an empty key in restistry:
`HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32`

Then logoff or restart explorer.exe to take effect.
