<template>
<div class="col-lg-11" id="divLogin">
    <b-row class="loginResponsive">
        <b-col col lg="6" md="6" class="login-left2">
            <br/><br/><br/>
            <span class="welcome-login">Seja bem-vindo ao SGDAU.</span><br/>
            <span class="welcome-login-2">Sistema Gerenciador de Documentação e Arquivo Unificado</span><br/>
            <br/>
            <b-row>
                <a  id="esqueceuSenha" 
                    class="clear text-right p-t-10 p-r-10 col-lg-12 cursor-pointer link-menu-header" 
                    onclick="esqueceuSenha();">
                    Esqueci minha senha
                </a>
            </b-row>
        </b-col>
        <b-col col lg="6" md="6" class="m-t-20">
            <p class="text-color-red text-size-12 text-bold">Informe os dados para acesso</p>
            <form id="frmLogin">
                <b-row class="form-group">
                    <b-col col lg="4" md="6" class="text-bold text-left-sm text-left-xs text-right m-r-5">
                        Login ou CPF:
                    </b-col>
                    <b-col col lg="7" md="5">
                        <input type="text" class="campo_comum" autocomplete="off" maxlength="20" />
                    </b-col>
                </b-row>
                <b-row class="form-group">
                    <b-col col lg="4" md="6" class="text-bold text-left-sm text-left-xs text-right m-r-5">
                        Senha:
                    </b-col>
                    <b-col col lg="7" md="5" >
                        <input type="password" class="campo_comum" autocomplete="off" maxlength="20" />
                    </b-col>
                </b-row>
                <b-row class="form-group">
                    <b-col>
                        <span class="validate-msg-error"></span>
                    </b-col>
                </b-row>
                <b-row class="form-group">
                    <b-col class="text-center">
                        <input id="btnLogin" type="button" class="button120" value="Login" />
                    </b-col>
                </b-row>
            </form>
        </b-col>
    </b-row>
</div>
</template>
<script>

export default {
    name: 'Login',
    components: {
        
    }
}

</script>
<style scoped>
    #divLogin {
        margin-left: auto;
        margin-right: auto;
        margin-top:0px;
        padding:0px;
    }
</style>
