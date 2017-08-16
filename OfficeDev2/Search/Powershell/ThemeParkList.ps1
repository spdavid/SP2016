Set-PNPTraceLog -On -Level Debug
Connect-PnPOnline -Url https://zalo.sharepoint.com/sites/devsearch -Credentials zalo

$web = Get-PnPWeb

Apply-PnPProvisioningTemplate -Path .\Themepark.xml -Web $web 


#Remove-PnPList -Identity "ThemeParks" -Confirm:$false
#Remove-PnPContentType -Identity ThemePark 