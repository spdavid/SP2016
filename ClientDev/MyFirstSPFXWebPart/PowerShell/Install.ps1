Connect-PnPOnline -Url https://zalo.sharepoint.com/sites/OD1/

#Create Terms
New-PnPTermGroup -Name "Hockey Example" -Id '46933810-79f7-41df-a9b9-d2aaf7ba0e3a'
$group  = Get-PnPTermGroup -Identity '46933810-79f7-41df-a9b9-d2aaf7ba0e3a' 
$ts = New-PnPTermSet -Name 'Hockey Positions' -id '635b5bca-8c5f-4831-8bf8-a0d9d5eb75e0' -TermGroup $group

New-PnPTerm -Id "a9eeece2-1d7b-484e-b60d-a69bb4e7dd98" -Name "Center" -TermSet $ts -TermGroup $group
New-PnPTerm -Id "2326a1ee-9663-406c-b9ab-5a2e9a158aeb" -Name "Left Wing" -TermSet $ts -TermGroup $group
New-PnPTerm -Id "f6d3b14b-dee1-495d-b763-354ab1f6b2f6" -Name "Right Wing" -TermSet $ts -TermGroup $group
New-PnPTerm -Id "aa33fee1-ede2-4ccd-b01d-9c667961ca02" -Name "Left Def" -TermSet $ts -TermGroup $group
New-PnPTerm -Id "14b37ad4-a09a-4998-993f-ca46062f41e6" -Name "Right Def" -TermSet $ts -TermGroup $group
New-PnPTerm -Id "145c47c6-b188-4b36-b041-48c9979cf19b" -Name "Goalie" -TermSet $ts -TermGroup $group

# Create List and add fields
New-PnPList -Title HockeyPlayers -Template GenericList

$list = Get-PnPList -Identity HockeyPlayers

Add-PnPField -List $list -id '5b77adf4-4267-41f5-a92f-d4d9782d87c9' -Type Number -DisplayName 'Shirt Number' -InternalName 'HockeyShirtNumber'
Add-PnPField -List $list -id '071cd34c-e2eb-4bb6-abce-2f8569286cdf' -Type Number -DisplayName 'Goals Made' -InternalName 'HockeyGoalsMade'
Add-PnPField -List $list -id '8f2d44d0-f06f-4251-b55c-7963a2e09092' -Type URL -DisplayName 'Picture' -InternalName 'HockeyPicture'
Add-PnPTaxonomyField -List $list -id '7303e4d2-764e-4e07-b995-4b1a80a14d24' -TermSetPath 'Hockey Example|Hockey Positions'  -DisplayName 'Position' -InternalName 'HockeyPosition'

$view = (Get-PnPView -List $list)[0] 
$view.ViewFields.Add("HockeyShirtNumber")
$view.ViewFields.Add("HockeyGoalsMade")
$view.ViewFields.Add("HockeyPicture")
$view.ViewFields.Add("HockeyPosition")
$view.Update()
Execute-PnPQuery


$item = Add-PnPListItem -List $list 
$item["Title"] = "Henrik Tömmernes";
$item["HockeyShirtNumber"] = 7;
$item["HockeyGoalsMade"] = 5;
$item["HockeyPicture"] = "https://cdn.shl.se/sports/player/portrait/200/qQ9-e9f8rPgRL-1474291392.jpg";
$item.Update();

Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName "HockeyPosition" -TermId "aa33fee1-ede2-4ccd-b01d-9c667961ca02"
#Execute-pnpQuery




