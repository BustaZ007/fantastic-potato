import Vue from 'vue'
import App from './App.vue'
import Axios from 'axios'
import router from "./router";

Vue.config.productionTip = false;

const api = Axios.create({
  baseURL: 'http://localhost:5000/'
});

const axiosPlugin = {
  install(Vue){
    Vue.prototype.$api = api;
  }
};

Vue.use(axiosPlugin);
new Vue({
  router,
  render: h => h(App),
}).$mount('#app');
