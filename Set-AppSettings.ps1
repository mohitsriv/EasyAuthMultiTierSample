# Cross cutting items
$balSite = "MyDashAPI"
$dalSite = "NodeDataAPI"
$rg = "MyDashRG"

# Populate empty ezAuthSettings
$ezAuthSettings = Get-Content .\settings.ezauth.json | ConvertFrom-Json

# MyDashAPI
$appSettings = Get-Content (".\" + $balSite + "\secrets.json") | ConvertFrom-Json
$appSettings | Add-Member -type NoteProperty -name DataAPIUrl -value ("https://" + $dalSite + ".azurewebsites.net") -force
New-AzureRMResource -PropertyObject $appSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($balSite + "/appsettings") -ApiVersion 2015-08-01 -Force
$ezAuthSettings.siteAuthEnabled = $true
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name clientId -value $appSettings."ida:ClientId" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name aadClientId -value $appSettings."ida:ClientId" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name issuer -value $appSettings."ida:Authority" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name openIdIssuer -value $appSettings."ida:Authority" -force
Set-AzureRMResource -PropertyObject $ezAuthSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($balSite + "/web") -ApiVersion 2015-08-01 -Force

#MyDashDataAPI
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name clientId -value $appSettings."ida:Resource" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name aadClientId -value $appSettings."ida:Resource" -force
Set-AzureRMResource -PropertyObject $ezAuthSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($dalSite + "/web") -ApiVersion 2015-08-01 -Force