# A B2C IEF Custom Policy which returns the Facebook Access token

## Disclaimer
The sample policy is developed and managed by the open-source community in GitHub. This policy is not part of Azure AD B2C product and it's not supported under any Microsoft standard support program or service. The policy is provided AS IS without warranty of any kind.

## Scenario
For scenarios where you would like users to return the access token from a Social IdP.

## Modications

**TrustFrameworkBase**
```xml
<ClaimType Id="identityProviderAccessToken">
	<DisplayName>Identity Provider Access Token</DisplayName>
	<DataType>string</DataType>
	<DefaultPartnerClaimTypes>
		<Protocol Name="OAuth2" PartnerClaimType="idp_access_token" />
		<Protocol Name="OpenIdConnect" PartnerClaimType="idp_access_token" />
	</DefaultPartnerClaimTypes>
	<AdminHelpText>The access token returned by the identity provider.</AdminHelpText>
	<UserHelpText>The access token returned by the identity provider.</UserHelpText>
</ClaimType>
```

**TrustframeworkExtensions**
```xml
<TechnicalProfile Id="Facebook-OAUTH">
...
<OutputClaims>
    <OutputClaim ClaimTypeReferenceId="identityProviderAccessToken" PartnerClaimType="{oauth2:access_token}" />
</OutputClaims>
```

**RelyingParty**
```xml
<OutputClaim ClaimTypeReferenceId="identityProviderAccessToken" />
```