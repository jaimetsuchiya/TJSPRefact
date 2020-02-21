<template>
    <b-row class="formTitle">
        <b-col class="header-page-text text-left">
            {{ title }}
        </b-col>
        <div class="header-page">
        </div>
    </b-row>
</template>

<script>
export default {
    name: "FormTitle",
    props: {
        title: String,
    }
}
</script>
<style scoped>
    .formTitle {
        margin-left: auto;
        margin-right: auto;
        margin-top: 0px;
        margin-bottom: 0px;
    }
</style>