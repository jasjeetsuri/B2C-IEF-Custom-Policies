# B2C IEF Custom Policy example scenarios
Azure AD B2C Identity Experience Framework Custom Policy examples for various scenarios.

## Disclaimer
The sample policies in this repo are developed and managed by the open-source community in GitHub. This policy is not part of Azure AD B2C product and it's not supported under any Microsoft standard support program or service. The policy is provided AS IS without warranty of any kind.

## Usage
To use these examples in your own AAD B2C tenant, you will need to make the following changes:
1. Follow the guidance to setup the required keys [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#add-signing-and-encryption-keys).

2. Register the required Application Registrations [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#register-applications).

3. Update the `login-NonInteractive` technical profile in the `TrustframeworkExtensions` file as noted [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#add-application-ids-to-the-custom-policy).

4. Register an Application Registration to manage any Extension Attributes (schema extensions) within AAD B2C as noted [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#add-application-ids-to-the-custom-policy).

5. Update the `AAD-Common` technical profile in the `TrustFrameworkBase` file as noted [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-create-custom-attributes-profile-edit-custom#modify-your-custom-policy-to-add-the-applicationobjectid).

6. Update the `TenantId` parameter in all files to match your B2C Tenant, in the format `something.onmicrosoft.com`.

7. Create an AAD B2C Application Registration. Choose to include a Web API and add https://jwt.ms as a reply url.

8. Upload and Test your policies via the AAD B2C Blade at portal.azure.com as noted [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-get-started-custom#upload-the-policies).

## Examples
* [Account Link](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/SocialAndLocalAccounts%20-%20Account%20Link) - A policy which will associate a user who logged in via a federated provider to a pre-created Local Account.

* [MFA IP Timeout](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/LocalAccounts%20-%20MFA%20IP%20Timeout) - A policy which forces the user to do MFA on 3 conditions:
    1. The user has newly signed up.
    2. The user has not done MFA in the last X seconds.
    3. The user is logging in from a different IP than they last logged in from.

 * [SAML Relying Party](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/LocalAccounts%20-%20SAML%20RP) - An example set of policies to integrate with a SAML RP.

 * [Username based journey](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/LocalAccounts%20-%20Username) - For scenarios where you would like users to sign up and sign in with Usernames rather than Emails.

 * [Email Verification at Sign In](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/LocalAccounts%20-%20Sign%20In%20Email%20Verification) - For scenarios where you would like users to validate their email via TOTP on every sign in.

* [Return the access token from a Social IdP](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/SocialAccounts%20-%20Facebook%20Access%20Token) - For scenarios where you would like users to return the access token from a Social IdP.

 ## Troubleshooting
 Find guidance [here](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-troubleshoot-custom) to help troubleshoot your policies.
 
 ## Miscellaneous
Use the VSCode Extension to help develop your policies [here](https://marketplace.visualstudio.com/items?itemName=AzureADB2CTools.aadb2c).