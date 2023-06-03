import { createApp } from 'vue'
import App from './App.vue'

import store from './store/index';
import router from './router/index';

import axios from './axios/index';
import VueAxios from 'vue-axios';

const myApp = createApp(App);

myApp.use(store);
myApp.use(router);
myApp.use(VueAxios, axios);

myApp.mount('#app');
