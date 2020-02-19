<template>
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#"><br/></a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" >
            <ul class="nav navbar-nav">
                <li id="liHome">
                    <a :href="goTo('')">
                        <img src="../assets/images/home_18.png" alt="Home" title="Ir para página inicial" />
                    </a>
                </li>
            </ul>
        </div>
    </div>
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
