This sample demonstrates how the "Easy Auth" feature in Azure App Service can be used to secure a multi-tier application without writing code on the backend(s).

To use this sample:

1. Deploy each of the three projects in this sample to its own Azure App Service Web App.  [Optional - if you don't already have AAD applications] Configure Easy Auth in the Web Apps settings (Azure portal) for MyDashAPI and MyDashDataAPI.

2. Create a secrets.json file in the MyDashAPI folder with the following structure:

        {
          "ida:Authority": "https://login.windows.net/[your tenant]",
          "ida:ClientId": "[fill in client id of caller (MyDashAPI)]",
          "ida:ClientSecret": "[fill in client secret of caller (MyDashAPI)]",
          "ida:Resource": "[fill in client id of target (MyDashDataAPI)]"
        }

3. Adjust the parameters in MyDashFE\app\scripts\app.js to match the above (namely ClientId and Authority).

4. To have MyDashDataAPI restrict access to a specific service principal, specify AllowedClientPrincipalId in Web.config. 

5. Run Set-AppSettings.ps1 in the root folder.  Note: Adjust the constants up top to match your deployment.  You will need Azure PowerShell 1.0 or greater.
