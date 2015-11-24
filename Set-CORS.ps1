# Cross cutting items
$balSite = "MyDashAPI"
$rg = "MyDashRG"

# Populate empty ezAuthSettings
$corsSettings = Get-Content .\settings.cors.json | ConvertFrom-Json

# MyDashAPI
Set-AzureRmResource -PropertyObject $corsSettings -ResourceGroupName $rg -ResourceType Microsoft.Web/sites/config -ResourceName ($balSite + "/web") -ApiVersion 2015-08-01 -Force
