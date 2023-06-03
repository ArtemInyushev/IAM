import axios from "axios";
import store from "../store/index";
import Auth from "../auth/index";

const request = axios.create({
    baseURL: process.env.VUE_APP_SERVER_URL,
    timeout: process.env.VUE_APP_REQUEST_DELAY_MS
});

request.interceptors.request.use(
    (config) => {
        const token = store.state.userData.accessToken;
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

let loop = 0;
let isRefreshing = false;
let subscribers = [];

function subscribeTokenRefresh(cb) {
    subscribers.push(cb);
}

function onRefreshed(token) {
    subscribers.map((cb) => cb(token));
}

request.interceptors.response.use(undefined, (err) => {
    if (err.code == "ECONNABORTED") {
        return Promise.reject(err);
    }

    const {
        config, 
        response : {status }
    } = err;
    const originalRequest = config;

    if (status === 401 && loop < 1) {
        loop++;
        if (!isRefreshing) {
            isRefreshing = true;
            Auth.getToken().then((response) => {
                isRefreshing = false;
                onRefreshed(response);
                subscribers = [];
            });
        }

        return new Promise((resolve) => {
            subscribeTokenRefresh((token) => {
                originalRequest.headers.Authorization = `Bearer ${token}`;
                resolve(axios(originalRequest));
            });
        });
    }
    return Promise.reject(err);
});

export default request;