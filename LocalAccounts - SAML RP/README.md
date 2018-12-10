# A B2C IEF Custom Policy which issues a SAML Response for a SAML RP

**IMPORTANT NOTE: SAML - Relying Party support is available as a preview feature.** Support is not available for the general public on this functionality as it has only been tested on some specific modalities.

## Disclaimer
The sample policy is developed and managed by the open-source community in GitHub. This policy is not part of Azure AD B2C product and it's not supported under any Microsoft standard support program or service. The policy is provided AS IS without warranty of any kind.

### Example usage and guidance
The policy files have been configured based on the SAML RP guidance [here](https://github.com/jasjeetsuri/active-directory-b2c-advanced-policies/blob/patch-1/Walkthroughs/RP-SAML.md). A working integration for a SAML RP. You can find more options on configuring the SAML Request/Response requirements in the reference section of this document.

* The flow can be initialised using a Service Provider initiated logon via this sample application [link](https://b2csamlrp.azurewebsites.net/SP?tenant=b2cprod&policy=B2C_1A_SAML_SignUpOrSignIn).

* The SAML RP Metadata is located [here](https://b2csamlrp.azurewebsites.net/Metadata?showpage=true).

* The AAD B2C SAML metadata is located [here](https://login.microsoftonline.com/te/b2cprod.onmicrosoft.com/B2C_1A_SAML_SignUpOrSignIn/Samlp/metadata).

* The AAD B2C SAML login request endpoint is:

    
       https://login.microsoftonline.com/te/b2cprod.onmicrosoft.com/B2C_1A_SAML_SignUpOrSignIn/samlp/sso/login

### Example SAML Request made to AAD B2C
```xml
<?xml version="1.0" encoding="utf-8"?>
<samlp:AuthnRequest xmlns:saml="urn:oasis:names:tc:SAML:2.0:assertion" ID="_1291973270" Version="2.0" IsPassive="false" ForceAuthn="false" IssueInstant="2018-12-10T12:16:51.0903137+00:00" Destination="https://b2cprod.b2clogin.com/te/b2cprod.onmicrosoft.com.onmicrosoft.com/B2C_1A_SAML_SignUpOrSignIn/samlp/sso/login" ProtocolBinding="urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST" AssertionConsumerServiceURL="https://b2csamlrp.azurewebsites.net/SP/AssertionConsumer" xmlns:samlp="urn:oasis:names:tc:SAML:2.0:protocol">
	<saml:Issuer xmlns:saml="urn:oasis:names:tc:SAML:2.0:assertion">https://b2csamlrp.azurewebsites.net</saml:Issuer>
	<samlp:NameIDPolicy xmlns:samlp="urn:oasis:names:tc:SAML:2.0:protocol" AllowCreate="true" SPNameQualifier="https://b2csamlrp.azurewebsites.net" />
</samlp:AuthnRequest>
```

### Example SAML Response from AAD B2C
```xml
<samlp:Response xmlns:saml="urn:oasis:names:tc:SAML:2.0:assertion" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" ID="_442cd20c-3eac-449b-b35a-cbe68c5644c6" InResponseTo="_1975631651" Version="2.0" IssueInstant="2018-12-10T12:13:44.2960568Z" Destination="https://b2csamlrp.azurewebsites.net/SP/AssertionConsumer" xmlns:samlp="urn:oasis:names:tc:SAML:2.0:protocol">
	<saml:Issuer Format="urn:oasis:names:tc:SAML:2.0:nameid-format:entity">https://login.microsoftonline.com/te/b2cprod.onmicrosoft.com/b2c_1a_saml/Samlp/metadata</saml:Issuer>
	<Signature xmlns="http://www.w3.org/2000/09/xmldsig#">
		<SignedInfo>
			<CanonicalizationMethod Algorithm="http://www.w3.org/2001/10/xml-exc-c14n#" />
			<SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1" />
			<Reference URI="#_442cd20c-3eac-449b-b35a-cbe68c5644c6">
				<Transforms>
					<Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature" />
					<Transform Algorithm="http://www.w3.org/2001/10/xml-exc-c14n#">
						<InclusiveNamespaces PrefixList="saml samlp xenc xs" xmlns="http://www.w3.org/2001/10/xml-exc-c14n#" />
					</Transform>
				</Transforms>
				<DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1" />
				<DigestValue>7v4Gm5+9jcdL8WHb8BZZutfvNrA=</DigestValue>
			</Reference>
		</SignedInfo>
		<SignatureValue>OgMQIXW6qeiY44hKgox9MsMeUZPAXD4s1TmXRvJzIE1ciN1NcUtbVGSTbLBZ+02wIfBk63ed9nph6Zf8lC7nh6rxWM0PKrH4Zw5OB1UZCHXLjjy3xrYcP65K+OFJ7YE+a4EttOfklZiOPjnrlNLAcmSCLTh/4qdUOTQK8w2tT0UvF5aWU7HtTQohMvVDeBnw88O1xsoLSr7i5/Zm5UCtRLjL9wXFmtwA8+c/YKF5mC0yhmOIlJxEctze0n4SZ+jdapEINx9VahdivWfXGO9Y9+/r5p7a7eEpddJK6EdppT5haqpuaHWC0u5xgkaiv8qQxqCdkUfjx+EARCIGML9b6g==</SignatureValue>
		<KeyInfo>
			<X509Data>
				<X509Certificate>MIIDNDCCAhygAwIBAgIQ05ocaoKq+4ZLSt+651WU1zANBgkqhkiG9w0BAQsFADAnMSUwIwYDVQQDExxzYW1sLmIyY3Byb2Qub25taWNyb3NvZnQuY29tMB4XDTE4MDkyMDIxNTQyMloXDTE4MTIyMTA3MDAwMFowJzElMCMGA1UEAxMcc2FtbC5iMmNwcm9kLm9ubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALQ+lfGYyuYUQOdj5zhvTxlYiXAue6jfH9/v/CSPCNheKuz255KyDmu76VX66BIq6r409fh7h31S+Vpf+PiRS3oyUXTJCR7Ii7wvd/Z1gk3VPV3+zj/EpvnFOjzp6Tbk3Dv5HqqaXf1zoVcvdfGUP3efktV+sJ44RXrD4x/98EYdumMLLM5Nn5JhFTqo0WaO20MauHLIrh78gKNC8Q4dO0qDXa+CreLh8elbmscFNlfCI1TEBsqfpEVHqimJWhfXWF7oL5njhGr5CcBgXXqml9S4q9WLJ1+CPoBmrUdluP2NwlpksgY74XROPViwDAu5IaszwmyJmfAc0oSRDvb0c7ECAwEAAaNcMFowWAYDVR0BBFEwT4AQ9NCCaYyO92mvf1YIRggM+KEpMCcxJTAjBgNVBAMTHHNhbWwuYjJjcHJvZC5vbm1pY3Jvc29mdC5jb22CENOaHGqCqvuGS0rfuudVlNcwDQYJKoZIhvcNAQELBQADggEBAHHnoAjNqPSqQyYAQJv5GYHwbEGUSB6b3Ou5b29BndFS22/eCl/ael1GewkZMwaFN6nVO9AN04VoKCO7Lsbq4S8l1yj6YIgYTvhfAr9hT05FxAhFHqKCMLlWuBT7ISMxMu7+Kc5oGk+ygVLEltLXEi5zIWj0rZkQdly4AgNXCF9Xuwea0D0e9jsr+NhZbXxFr/mVBghHg7IIiWGfnf6NBv1/g26nx9Do6JcuYknlh5LPHAaTFs/BS5Hz9uDAF89jK2RcSjIxMP7qt3SGaop0P8NDqCgaow/BtuEiKCT1ILMyJM9VmwJQXPaLYiTmjBD2M91BMdioExQv1WIG3f0ttR0=</X509Certificate>
			</X509Data>
		</KeyInfo>
	</Signature>
	<samlp:Status>
		<samlp:StatusCode Value="urn:oasis:names:tc:SAML:2.0:status:Success" />
	</samlp:Status>
	<saml:Assertion ID="_6d29f728-1c8b-4b11-938c-0d2ccaa197c9" Version="2.0" IssueInstant="2018-12-10T12:13:44.2648137Z">
		<saml:Issuer Format="urn:oasis:names:tc:SAML:2.0:nameid-format:entity">https://login.microsoftonline.com/te/b2cprod.onmicrosoft.com/b2c_1a_saml/Samlp/metadata</saml:Issuer>
		<saml:Subject>
			<saml:NameID Format="urn:oasis:names:tc:SAML:1.1:nameid-format:persistent">35cebd79-58e0-4818-acb7-b3e78eed31bc</saml:NameID>
			<saml:SubjectConfirmation Method="urn:oasis:names:tc:SAML:2.0:cm:bearer">
				<saml:SubjectConfirmationData NotOnOrAfter="2018-12-10T12:18:44.2648137Z" Recipient="https://b2csamlrp.azurewebsites.net/SP/AssertionConsumer" InResponseTo="_1975631651" />
			</saml:SubjectConfirmation>
		</saml:Subject>
		<saml:Conditions NotBefore="2018-12-10T12:13:44.2648137Z" NotOnOrAfter="2018-12-10T12:18:44.2648137Z">
			<saml:AudienceRestriction>
				<saml:Audience>https://b2csamlrp.azurewebsites.net</saml:Audience>
			</saml:AudienceRestriction>
		</saml:Conditions>
		<saml:AuthnStatement SessionIndex="65087fb0-3988-4235-989b-606a1f7b054a" AuthnInstant="2018-12-10T12:13:44.2648137Z">
			<saml:AuthnContext>
				<saml:AuthnContextClassRef>urn:oasis:names:tc:SAML:2.0:ac:classes:unspecified</saml:AuthnContextClassRef>
			</saml:AuthnContext>
		</saml:AuthnStatement>
		<saml:AttributeStatement xmlns:xs="http://www.w3.org/2001/XMLSchema">
			<saml:Attribute Name="http://schemas.microsoft.com/identity/claims/email" NameFormat="urn:oasis:names:tc:SAML:2.0:attrname-format:uri" FriendlyName="Email Address">
				<saml:AttributeValue xsi:type="xs:string">1@1.com</saml:AttributeValue>
			</saml:Attribute>
			<saml:Attribute Name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" NameFormat="urn:oasis:names:tc:SAML:2.0:attrname-format:uri" FriendlyName="Display Name">
				<saml:AttributeValue xsi:type="xs:string">1</saml:AttributeValue>
			</saml:Attribute>
			<saml:Attribute Name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname" NameFormat="urn:oasis:names:tc:SAML:2.0:attrname-format:uri" FriendlyName="Given Name">
				<saml:AttributeValue xsi:type="xs:string">Mark</saml:AttributeValue>
			</saml:Attribute>
			<saml:Attribute Name="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname" NameFormat="urn:oasis:names:tc:SAML:2.0:attrname-format:uri" FriendlyName="Surname">
				<saml:AttributeValue xsi:type="xs:string">Smith1</saml:AttributeValue>
			</saml:Attribute>
			<saml:Attribute Name="http://schemas.microsoft.com/identity/claims/objectidentifier" NameFormat="urn:oasis:names:tc:SAML:2.0:attrname-format:uri" FriendlyName="User's Object ID">
				<saml:AttributeValue xsi:type="xs:string">35cebd79-58e0-4818-acb7-b3e78eed31bc</saml:AttributeValue>
			</saml:Attribute>
		</saml:AttributeStatement>
	</saml:Assertion>
</samlp:Response>

```