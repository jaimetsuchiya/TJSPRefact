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
            <form id="frmLogin" >
                <b-row class="form-group">
                    <b-col col lg="4" md="6" class="text-bold text-left-sm text-left-xs text-right m-r-5">
                        Login ou CPF:
                    </b-col>
                    <b-col col lg="7" md="5">
                        <input type="text" id="login" v-model="authenticationRequest.login" class="campo_comum" autocomplete="off" maxlength="20" />
                    </b-col>
                </b-row>
                <b-row class="form-group">
                    <b-col col lg="4" md="6" class="text-bold text-left-sm text-left-xs text-right m-r-5">
                        Senha:
                    </b-col>
                    <b-col col lg="7" md="5" >
                        <input type="password" v-model="authenticationRequest.password" class="campo_comum" autocomplete="off" maxlength="20" />
                    </b-col>
                </b-row>
                <b-row class="form-group">
                    <b-col>
                        <span class="validate-msg-error">
                            {{authenticationResponse.message}}
                        </span>
                    </b-col>
                </b-row>
                <b-row class="form-group">
                    <b-col class="text-center">
                        <input id="btnLogin" type="button" class="button120" value="Login" v-on:click="requestSignIn(authenticationRequest)"/>
                    </b-col>
                </b-row>
            </form>
        </b-col>
    </b-row>
</div>
</template>
<script>

var data = {
  authenticationRequest: {
    login: '',
    password: '',
    clientId: 'b5efeeaf2d46854a78cbe4a3ca50ad6b'
  },
  authenticationResponse: {
      message: '',
      userData: null,
      token: null
  }
};
import routes from '../routes';
import * as axios from 'axios';
axios.defaults.headers.common['Content-Type'] = 'application/json'
axios.defaults.headers.common['Access-Control-Allow-Origin'] = 'https://localhost:44306/api';
axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';

export default {
    name: 'Login',
    data: function() {
        return data;
    },
    methods: {
        requestSignIn: function(dto) {
            axios.post('https://localhost:44306/api/security/Authenticate', dto)
            .then(res=> {
                            localStorage.setItem("userInfo", JSON.stringify(res));
                            routes.push('/');
                        }).catch(err => {
                            localStorage.removeItem("userInfo");
                            console.log('requestSignIn Error:', err);
                        });
        },
        requestSignOut: function() {
            localStorage.removeItem("userInfo");
        }
    },
    mounted() {
        document.getElementById('login').focus();
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
