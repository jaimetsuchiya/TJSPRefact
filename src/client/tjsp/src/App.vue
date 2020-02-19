<template>
  <div id="app">
    <Header version="SW1 - 3.5.4.4" user="userData"/>
  </div>
</template>

<script>
import Header from './components/Header.vue'

var data = {
  userData: {
        login: "GSWTJ4126",
        name: "JAIME TSUCHIYA"
  }
};

export default {
  name: 'App',
  components: {
    Header
  },
  data: function() {
    return data;
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
  margin-top: 60px;
}
</style>
