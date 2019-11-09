import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import VueResource from 'vue-resource';
//import VueMaterial from 'vue-material';
//import 'vue-material/dist/vue-material.min.css'
//Vue.use(VueMaterial)
Vue.config.productionTip = false;
Vue.use(VueResource);
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");