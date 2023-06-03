import { BrowserAuthError, InteractionRequiredAuthError } from "@azure/msal-browser";
import { msalInstance } from "./msalInstance";
import store from "../store/index";

class Auth {
    static async acquireTokenSilent(){
        const account = msalInstance.getAllAccounts()[0];
        const accessTokenRequest = {
            scopes: [`${process.env.VUE_APP_CLIENT_ID}/.default`],
            account: account
        };

        const accessTokenResponse = await msalInstance.acquireTokenSilent(accessTokenRequest);
        if (accessTokenResponse) {
            store.dispatch('updateUserData', {
                account: accessTokenResponse.account.username,
                name: accessTokenResponse.account.name,
                roles: accessTokenResponse.account.idTokenClaims.roles,
                accessToken: accessTokenResponse.accessToken
            });
        }
        return true;
    }

    static async getToken() {
        let response;
        const redirectResponse = await msalInstance.handleRedirectPromise();
        if (redirectResponse !== null){
            // Acquire token silent success
            response = redirectResponse;
        }
        else {
            const account = msalInstance.getAllAccounts()[0];
            const accessTokenRequest = {
                scopes: [`${process.env.VUE_APP_CLIENT_ID}/.default`],
                account: account
            };
            
            try {
                const accessTokenResponse = await msalInstance.loginRedirect(accessTokenRequest);
                response = accessTokenResponse;
            }
            catch (err) {
                if (err instanceof BrowserAuthError ||
                    err instanceof InteractionRequiredAuthError) {
                        
                    msalInstance.acquireTokenRedirect(accessTokenRequest);
                }
            }
        }
        
        if (response) {
            store.dispatch('updateUserData', {
                account: response.account.username,
                name: response.account.name,
                roles: response.account.idTokenClaims.roles,
                accessToken: response.accessToken
            });
            return true;
        }
        return false;
    }
};

export default Auth;