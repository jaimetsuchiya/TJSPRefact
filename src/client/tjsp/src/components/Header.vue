<template>
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 top img-responsive hidden-xs">
    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5 p-l-20 p-t-7">
        <button type="link" v-if="isAuthenticated" :click="logOff()" class="link-menu-header">Sair</button>
        <span v-if="isAuthenticated" class="text-bold">|</span> 
        <button type="link" v-if="isAuthenticated" :click="changePwd()" class="link-menu-header">Alterar Senha</button>
    </div>
    <div class="col-lg-7 col-md-7 col-sm-7 col-xs-7 p-t-7">
        <div v-if="isAuthenticated" class="col-lg-7 col-md-7 col-sm-7 col-xs-7 p-t-3 text-blue text-size-9 text-bold" >
            {{user.login}} - {{ user.name }}
        </div>
        <div v-if="isAuthenticated" class="col-lg-5 col-md-5 col-sm-5 col-xs-5 text-size-8 text-blue hidden-sm hidden-xs" >
            {{ version }}
        </div>
    </div>
</div>
</template>

<script>
export default {
  name: 'Header',
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
      },
      changePwd() {
          console.log('changePwd');
      }
  }
}
</script>
<style scoped>
.top {
    width: 900px;
    height: 143px;
    background-image: url(../assets/images/back_topo2.jpg);
}
</style>
