Connect-PnPOnline -Url https://zalodev.sharepoint.com/sites/OD1/ -credentials DEVENV2

Add-PnPJavaScriptLink -Name "someCustomLink" -Url "https://zalodev.sharepoint.com/sites/OD1/Code/main.js" -Scope Site