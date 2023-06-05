import { createApp } from 'vue'
import App from './App.vue'

import store from './store/index';
import router from './router/index';

import axios from './axios/index';
import VueAxios from 'vue-axios';

import i18n from './i18n/i18n';

const myApp = createApp(App);

myApp.use(store);
myApp.use(router);
myApp.use(VueAxios, axios);
myApp.use(i18n);

myApp.mount('#app');
