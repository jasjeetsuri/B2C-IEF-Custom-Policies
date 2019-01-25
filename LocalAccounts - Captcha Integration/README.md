# A B2C IEF Custom Policy which integrates with Google Captcha

## Disclaimer
The sample policy is developed and managed by the open-source community in GitHub. This policy is not part of Azure AD B2C product and it's not supported under any Microsoft standard support program or service. The policy is provided AS IS without warranty of any kind.

### Scenario
This set of policies demonstrates how to integrate Google Captcha into the Sign In page.

* JavaScript is used to embed the Captcha control.
The Captcha response is inserted into a hidden field which the `SelfAsserted-LocalAccountSignin-Email` technical profile exposes to the sign in page.
* The `SelfAsserted-LocalAccountSignin-Email` technical profile sends the Captcha response from the hidden field to the Captcha API which validates the blob against the Google servers.
* If the response from the Google server is successful, B2C continues to validate the credentials against the directory. 
* Otherwise, the API responds back to the client indicating the Captcha was invalid and must try again.
* Each time the user submits the page, the Captcha is reset using JavaScript.