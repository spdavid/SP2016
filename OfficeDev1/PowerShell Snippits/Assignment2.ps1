
#Content types and filds always on root site 

#	- Create a ContentType with Powershell called "Candy"
#	- Create the fields 
#		○ CandyType (choice)
#		○ Color - Text
#		○ Descriptiong - multitext
#	- Create a custom list
#	- Add the content type to the list
#	- Create a few items and add it to the list

#Challenge
#	Read data from an xml file and import it via powershell. 

Connect-PnPOnline -Url https://zalo.sharepoint.com/sites/od1 -Credentials credsforme


Add-PnPContentType -Name Candy -ContentTypeId 0x0100A4452594634A44F79B516E07FF19129F 


Add-PnPField -Id "{86766D47-311F-4F06-9A56-BC205C928380}" -DisplayName "Candy Type" -Type Choice -Choices "Hard", "Sour", "Suckers", "Salty" -InternalName "od1_candytype" 
Add-PnPField -Id "{D0D30F52-3279-46B6-AC55-C054A15912D5}" -DisplayName "Color" -Type Text  -InternalName "od1_color" 
Add-PnPField -Id "{1EEEA144-FF16-4154-8AE9-6156CA9A5380}" -DisplayName "Description" -Type Note  -InternalName "od1_desc" 

Add-PnPFieldToContentType -Field "{86766D47-311F-4F06-9A56-BC205C928380}" -ContentType 0x0100A4452594634A44F79B516E07FF19129F 
Add-PnPFieldToContentType -Field "{D0D30F52-3279-46B6-AC55-C054A15912D5}" -ContentType 0x0100A4452594634A44F79B516E07FF19129F 
Add-PnPFieldToContentType -Field "{1EEEA144-FF16-4154-8AE9-6156CA9A5380}" -ContentType 0x0100A4452594634A44F79B516E07FF19129F 

New-PnPList -Title Candy -Template GenericList -EnableContentTypes

Add-PnPContentTypeToList -List Candy -ContentType 0x0100A4452594634A44F79B516E07FF19129F -DefaultContentType

Remove-PnPContentTypeFromList -List Candy -ContentType Item

$list = Get-PnPList -Identity Candy
$list.EnableAttachments = $false;
$list.Update();
Execute-PnPQuery

Add-PnPListItem -List Candy -Values @{"Title"="Jawbreaker";"od1_candytype"="Hard"; "od1_color"="Green"; "od1_desc"="hard candy that breaks the jaw" }


$view = Get-PnPView -List Candy -Identity e44093bd-3119-4a05-972f-8084b1fb3799

$view.ViewFields.Add("od1_candytype");
$view.ViewFields.Add("od1_color");
$view.ViewFields.Add("od1_desc");

$view.Update()
Execute-PnPQuery




