# B2C-IEF-Custom-Policies
Azure AD B2C Identity Experience Framework Custom Policy examples


MFA IP Timeout - A policy which forces the user to do MFA on 3 conditions:
 1. The user has newly signed up.
 2. The user has not done MFA in the last X seconds.
 3. The user is logging in from a different IP than they last logged in from.