import { createApp } from 'vue'
import App from './App.vue'
import router from "./router/index"

import store from "./store/index"

import PrimeVue from 'primevue/config';
import VueCookies from 'vue-cookies'

import 'primevue/resources/themes/saga-blue/theme.css'
import 'primevue/resources/primevue.min.css'
import 'primeicons/primeicons.css'
import 'primeflex/primeflex.css';




createApp(App).use(router).use(store).use(PrimeVue).mount('#app')