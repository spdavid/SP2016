Connect-PnPOnline -Url https://zalo.sharepoint.com/sites/devsearch -Credentials zalo

$field = Get-PnPField -Identity PublishingPageContent

$field.SchemaXml | clip.exe