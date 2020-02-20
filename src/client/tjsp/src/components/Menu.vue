<template>
<b-navbar toggleable="lg" id="bs-example-navbar-collapse-1">
    <b-navbar-brand href="#">
        <img src="../assets/images/home_18.png" alt="Home" title="Ir para página inicial">
    </b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
     
      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">

        <b-nav-item-dropdown text="Lang" right>
          <b-dropdown-item href="#">EN</b-dropdown-item>
          <b-dropdown-item href="#">ES</b-dropdown-item>
          <b-dropdown-item href="#">RU</b-dropdown-item>
          <b-dropdown-item href="#">FA</b-dropdown-item>
        </b-nav-item-dropdown>

        <b-nav-item-dropdown right>
          <!-- Using 'button-content' slot -->
          <template v-slot:button-content>
            <em>User</em>
          </template>
          <b-dropdown-item href="#">Profile</b-dropdown-item>
          <b-dropdown-item href="#">Sign Out</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>

    </b-collapse>
  </b-navbar>
</template>    

<script>
export default {
  name: 'Menu',
  props: {
  },
  methods: {
      goTo(url) {
        console.log('goTo', url);
      },
  }
}
</script>
<style scoped>
    #menu { 
        width:100%;
        margin:0px;
        padding:0px;
    }
</style>