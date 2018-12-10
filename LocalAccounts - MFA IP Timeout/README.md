# A B2C IEF Custom Policy which invokes MFA based on the IP and absolute time window in which the user last did MFA

## Disclaimer
The sample policy is developed and managed by the open-source community in GitHub. This policy is not part of Azure AD B2C product and it's not supported under any Microsoft standard support program or service. The policy is provided AS IS without warranty of any kind.

[MFA IP Timeout](https://github.com/jasjeetsuri/B2C-IEF-Custom-Policies/tree/master/LocalAccounts%20-%20MFA%20IP%20Timeout) - A policy which forces the user to do MFA on 3 conditions:
 1. The user has newly signed up.
 2. The user has not done MFA in the last X seconds.
 3. The user is logging in from a different IP than they last logged in from.

 The time window can be adjusted in seconds by modifying the `timeSpanInSeconds` paramter in the `CompareTimetoLastMFATime` technical profile in the `TrustFrameworkBase` file. It has been set to 100 seconds in this example.