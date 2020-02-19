<template>
  <div id="app">

    <Header version="SW1 - 3.5.4.4" :user="userData"/>

    <section class="content-page">

      <div id="progressbar-man" style="display: none;" class="ajaxloader-2">
          <center>
              <br />
              Aguarde...
          </center>
      </div>

      <FormTitle :title="title"></FormTitle>
      <div id="formContent">
        <Login />
      </div>

    </section>

    <Footer server="BRSPOMTJSD01" />

  </div>
</template>

<script>
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'
import Login from './components/Login.vue'
import FormTitle from './components/FormTitle.vue'

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
    Header,
    Footer,
    Login,
    FormTitle
  },
  data: function() {
    return data;
  },
  methods: {
    signIn: function() {

    }, 
    signOut: function() {

    }
  },

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
