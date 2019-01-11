# A B2C IEF Custom Policy which allows disabling accounts that are from External IDPs

## Disclaimer
The sample policy is developed and managed by the open-source community in GitHub. This policy is not part of Azure AD B2C product and it's not supported under any Microsoft standard support program or service. The policy is provided AS IS without warranty of any kind.

## Scenario
For scenarios where you would like to block logins for social accounts or external IdP accounts that have been marked disabled in Azure AD B2C.

At sign in, read the `accountEnabled` attribute as part of `AAD-UserReadUsingAlternativeSecurityId`. If this value is set to `false`, then run the `AAD-DisabledUserPage` orchestration step. 

This step follows a validation technical profile as part of a dummy self asserted page which will only allow a user to proceed if accountEnabled=true. 

This occurs via the outputClaimsTransoformation `AssertAccountEnabledIsTrue` called by the `AAD-AssertAccountEnabled` technical profile.

Since only users in a disabled state reach this page, this will always result in an error defined by the metadata key item `UserMessageIfClaimsTransformationBooleanValueIsNotEqual`. The user will not be issued a JWT Token.