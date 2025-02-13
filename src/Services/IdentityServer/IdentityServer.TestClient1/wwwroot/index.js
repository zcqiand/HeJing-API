﻿oidc.Log.setLogger(console);

const userManager = new oidc.UserManager({
    authority: 'https://localhost:55208',
    scope: 'openid offline_access',
    client_id: 'testclient1',
    redirect_uri: window.location.origin + '/callback.html',
    response_type: 'code',
    userStore: new oidc.WebStorageStateStore({ store: window.localStorage }),
});

function login() {
    return userManager.signinRedirect();
}

function refreshToken() {
    return userManager.signinSilent();
}

