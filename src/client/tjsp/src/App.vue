<template>
  <div id="app">

    <Header version="SW1 - 3.5.4.4" />

    <div class="content-page">

      <div id="progressbar-man" style="display: none;" class="ajaxloader-2">
          <center>
              <br />
              Aguarde...
          </center>
      </div>

      <FormTitle :title="title"></FormTitle>
      <div id="formContent">
        <router-view  default="{name: 'home'}"/>

      </div>

    </div>

    <Footer server="BRSPOMTJSD01" />

  </div>
</template>

<script>

import Footer from './components/Footer.vue'
import FormTitle from './components/FormTitle.vue'
import Header from './components/Header.vue'
import { mapActions, mapState } from 'vuex';

var data = {
  userData: {
    login: undefined,
    name: undefined
  },
  token: {
    
  },
  title: "SGDAU - Sistema Gerenciador de Documentação e Arquivo Unificado",
};

export default {
  name: 'App',
  components: {
    Footer,
    FormTitle,
    Header,
  },
  data: function() {
    return data;
  },
  computed: {
      ...mapState(['userInfo']),
  },
  methods: {
    ...mapActions(['loadUserInfo']),
  },
  created() {
    this.loadUserInfo();
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 0px;
  margin-left:auto;
  margin-right: auto;
  width: 900px;
  height:100%;
}
#formContent{
  padding-top:0px;
  padding-left:10px;
  padding-right:10px;
  height: 80%
}
</style>
