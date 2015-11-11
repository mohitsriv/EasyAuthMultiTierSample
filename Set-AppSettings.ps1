# Cross cutting items
$balSite = "MyDashAPI"
$dalSite = "MyDashDataAPI"
$rg = "MyDashRG"

# Populate empty ezAuthSettings
$ezAuthSettings = Get-Content .\settings.ezauth.json | ConvertFrom-Json

# MyDashAPI
$appSettings = Get-Content (".\" + $balSite + "\secrets.json") | ConvertFrom-Json
$appSettings | Add-Member -type NoteProperty -name DataAPIUrl -value ("https://" + $dalSite + ".azurewebsites.net") -force
New-AzureRmResource -PropertyObject $appSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($balSite + "/appsettings") -ApiVersion 2015-08-01 -Force
$ezAuthSettings | Add-Member -type NoteProperty -name clientId -value $appSettings."ida:ClientId" -force
$ezAuthSettings | Add-Member -type NoteProperty -name issuer -value $appSettings."ida:Authority" -force
New-AzureRmResource -PropertyObject $ezAuthSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($balSite + "/authsettings") -ApiVersion 2015-08-01 -Force

#MyDashDataAPI
$ezAuthSettings | Add-Member -type NoteProperty -name clientId -value $appSettings."ida:Resource" -force
New-AzureRmResource -PropertyObject $ezAuthSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($dalSite + "/authsettings") -ApiVersion 2015-08-01 -Force