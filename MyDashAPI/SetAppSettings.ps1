$appSettings = Get-Content .\secrets.json | ConvertFrom-Json
New-AzureRMResource -PropertyObject $appSettings -ResourceGroupName MyDashRG -ResourceType Microsoft.Web/sites/config -ResourceName MyDashAPI/appsettings -ApiVersion 2015-08-01 -Force
$ezAuthSettings = Get-Content .\settings.ezauth.json | ConvertFrom-Json
$ezAuthSettings.siteAuthEnabled = $true
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name clientId -value $appSettings."ida:ClientId" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name aadClientId -value $appSettings."ida:ClientId" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name issuer -value $appSettings."ida:Authority" -force
$ezAuthSettings.siteAuthSettings | Add-Member -type NoteProperty -name openIdIssuer -value $appSettings."ida:Authority" -force
Set-AzureRMResource -PropertyObject $ezAuthSettings -ResourceGroupName MyDashRG -ResourceType Microsoft.Web/sites/config -ResourceName MyDashAPI/web -ApiVersion 2015-08-01 -Force