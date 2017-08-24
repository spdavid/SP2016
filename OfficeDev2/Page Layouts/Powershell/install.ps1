Set-PNPTraceLog -On -Level Debug # turn on for extra info

Connect-PnPOnline -Url https://zalo.sharepoint.com/sites/devsearch -Credentials zalo

$web = Get-PnPWeb

Apply-PnPProvisioningTemplate -Path ./setup.xml -Web $web 





