# Introduction
This a demo to show how to secure your RestFul API hosted in Azure Web App by using [Azure AD v1.0](https://docs.microsoft.com/en-us/azure/active-directory/develop/). The self-signed certificate is used to authenticate the local application that consumes the RestFul API. The whole demo is implemented by .Net framework.

# How to set up environment to run this demo
To run this demo, you will need:
* Visual Studio 2019
* Azure subscription

## Step 1: create and set up Azure web app service instance for AAD login
1. Create a new app service and the "Runtime Stack" shoulf be set to "ASP.NET V4.7" and then go to its manangement page
2. Select "Authentication / Authorization" and set authentication to "on"
3. Select "Azure Active Directory" as authentication provider
4. Configure the provider and select "Express" as management mode and then select "Create New AD App"
5. Save all the changes
6. Launch to the overview page of the newly created AD App and click the link after "Managed application in..."
7. Click Properties on the left and set "User assignment required?" to yes
8. Go back to AD App's overview page and add below contents to its manifest
> "appRoles": [
>   {
>     "allowedMemberTypes": ["Application"],
>     "description": "xxxx",
>     "displayName": "xxxx",
>     "id": "GUID",
>     "isEnabled": true,
>     "lang": null,
>     "origin": "Application",
>     "value": "access_as_application"
>   }
> ]

## Step 2: create AD App for the local application to consume the RestFul API
1. Create a new AD App registration
2. Add the created permission in step 1 to it
3. Upload your [self-signed certificate](https://docs.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-certificates-point-to-site) to it