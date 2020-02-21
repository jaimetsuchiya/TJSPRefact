<template>
<div class="header">
  <b-row class="top img-responsive hidden-sm hidden-xs">
    <b-col col lg="4" md="4" class="text-left">
      <a v-if="isAuthenticated" v-on:click="logOff()" class="link-menu-header text-bold">Sair</a>
          <span v-if="isAuthenticated" class="text-bold"> | </span> 
          <a v-if="isAuthenticated" v-on:click="changePwd()" class="link-menu-header text-bold">Alterar Senha</a>
    </b-col>
    <b-col col lg="4" md="4" class="text=center">
        <span v-if="isAuthenticated" class="text-blue text-size-9 text-bold" >
              {{user.login}} - {{ user.name }}
        </span>
    </b-col>
    <b-col col lg="4" md="4" class="text=center">
      <span v-if="isAuthenticated" class="text-size-8 text-blue" >
              {{ version }}
      </span>
    </b-col>
  </b-row>  
  <b-row v-if="isAuthenticated" class="menu-area">
    <b-col col lg="10" >
      <nav class="navbar navbar-default navbar-default-menu">
        <Menu />
      </nav>
    </b-col>
  </b-row>
</div>
</template>

<script>
import Menu from './Menu.vue'

export default {
  name: 'Header',
  components: {
    Menu
  },
  props: {
    version: String,
    user: Object
  },
  computed: {
    isAuthenticated: function () {
      return this.user !== undefined && this.user.login !== undefined;
    }
  },
  methods: {
      logOff() {
        console.log('logOff');
        this.user = undefined;
        //TODO: Implementar emit
      },
      changePwd() {
          console.log('changePwd');
      }
  }
}
</script>
<style scoped>
  .navigationArea {
        margin-left: auto;
        margin-right: auto;
        margin-top: 0px;
        margin-bottom: 0px;
        padding:0px;
    }
</style>