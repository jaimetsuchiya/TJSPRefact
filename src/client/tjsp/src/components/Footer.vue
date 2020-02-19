<template>
<footer class="footer-page">
    <b-row>
        <b-col col lg="4" md="4" class="text-left">
        </b-col>
        <b-col col lg="4" md="4" class="text=center">
        </b-col>
        <b-col col lg="4" md="4" class="text=right">
            <p><img alt="Iron Mountain" src="../assets/images/im_logo.png" width="220" height="32"></p>
            <p><span class="text-size-7 pull-right">Server: {{server}}</span></p>
        </b-col>
    </b-row>
</footer>  
</template>

<script>
export default {
  name: 'Footer',
  props: {
    server: String
  },
}
</script>