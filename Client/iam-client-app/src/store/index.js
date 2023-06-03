import { createStore } from 'vuex';

const store = createStore({
    state() {
        return {
            msalConfig: {
                auth: {
                    clientId: process.env.VUE_APP_CLIENT_ID,
                    authority: `${process.env.VUE_APP_INSTANSE}${process.env.VUE_APP_TENANT_ID}`
                },
                cache: {
                    cacheLocation: 'localStorage',
                }
            },
            userData: {
                account: '',
                name: '',
                roles: [],
                accessToken: '',
            }
        };
    },
    mutations: {
        mutateUserData(state, payload){
            state.userData = payload;
        }
    },
    actions: {
        updateUserData({ commit }, payload){
            if (!payload.account ||
                !payload.name ||
                //!payload.roles ||
                !payload.accessToken) {

                console.log("Error in user data");
                return;
            }
            commit('mutateUserData', payload);
        }
    }
});

export default store;