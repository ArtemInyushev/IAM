import { PublicClientApplication } from '@azure/msal-browser';
import store from '../store/index';

export const msalInstance = new PublicClientApplication(
    store.state.msalConfig,
);