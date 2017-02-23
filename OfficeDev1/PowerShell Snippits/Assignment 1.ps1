#	- Create a subweb called "MySubweb"  - New‑PnPWeb
#
#	- Add a document library called SuperCoolList 
#	- Upload a file of your choice
#Add a field to the list called "Extra Info"

Connect-PnPOnline -Url https://zalo.sharepoint.com/sites/OD1 -Credentials credsforme

#https://absolute-sharepoint.com/2013/06/sharepoint-2013-site-template-id-list-for-powershell.html
Remove-PnPWeb -Url MSW  -Force
$newweb = New-PnPWeb -Title MySubWeb -Url MSW -Locale 1033 -Template STS#0

New-PnPList  -Title "doclib" -Template DocumentLibrary -Url "doclib" -Web $newweb

#upload single file
Add-PnPFile -Web $newweb -Folder doclib -Path D:\temp\Uppgift.docx


#upload files from a directory
$files = Get-ChildItem -Path D:\temp\

foreach ($file in $files)
{
    Add-PnPFile -Web $newweb -Folder doclib -Path $file.FullName 
}

$list = Get-PnPList -Web  $newweb -Identity "doclib"

Add-PnPField -Web $newweb -List $list -Type text -Id "{3BA2C0E3-69D9-4FDF-9BA3-1FCC7B0E574F}" -InternalName pnpPStestField -DisplayName pnpPStestField 

Get-PnPListItem -List $list -Web $newweb

$queryFromStaticMethod = [Microsoft.SharePoint.Client.CamlQuery]::CreateAllItemsQuery()

$camlquery = New-Object Microsoft.SharePoint.Client.CamlQuery
$items = $list.GetItems($camlquery)
$ctx = $list.Context
$ctx.Load($items);
$ctx.ExecuteQuery();
$items 
$items | Where-Object {$_.Id -gt 2 } | Out-GridView