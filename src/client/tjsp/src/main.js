import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue/dist/bootstrap-vue.esm';
import App from './App.vue'
import * as axios from 'axios';
import router from './router'

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import store from './store';

Vue.use(BootstrapVue);


require('./assets/main.css')
axios.defaults.headers.common['Content-Type'] = 'application/json'
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App),
  
}).$mount('#app')
