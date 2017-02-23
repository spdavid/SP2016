#Create a site collection
Get-PnPTimeZoneId

New-PnPTenantSite -TimeZone 4 -Title "OD1P2" -Url https://zalo.sharepoint.com/sites/OD1P2 -Lcid 1033 -Template STS#0 -Owner "david@zalosolutions.com" 

