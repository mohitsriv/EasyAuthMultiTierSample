This sample demonstrates how the "Easy Auth" feature in Azure App Service can be used to secure a multi-tier application without writing code on the backend(s).

To use this sample:

1. Create a secrets.json file in the MyDashAPI folder with the following structure:

        {
          "ida:Authority": "https://login.windows.net/[your tenant]",
          "ida:ClientId": "[fill in client id of caller]",
          "ida:ClientSecret": "[fill in client secret of caller]",
          "ida:Resource": "[fill in client id of target]"
        }

2. To have MyDashDataAPI restrict access to a specific service principal, specify AllowedClientPrincipalId in Web.config. 

3. Deploy each of the three projects in this sample to its own Azure App Service Web App.

4. Run Set-AppSettings.ps1 in the root folder.  Note: Adjust the constants up top to match your deployment.  You will need Azure PowerShell 1.0 or greater.
