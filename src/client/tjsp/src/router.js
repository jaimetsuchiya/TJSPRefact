import Vue from 'vue'
import VueRouter from  'vue-router'
import Home from './components/Home.vue';
import Login from './components/Login.vue';

Vue.use(VueRouter);

const routes = [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]

  const router = new VueRouter({
    mode: 'history',
    routes
  })

  export default router
