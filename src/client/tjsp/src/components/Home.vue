<template>
<b-row class="p-l-20 p-r-20 p-t-20 text-bold">
    <b-col col lg="12" class="text-left">
        Prezado Sr. Cartorário da Comarca da <span class="text-color-red">CAPITAL</span>:<br />
        <br />
        Para baixar a Planilha de Reclamação - Atraso Desarquivamento, <a class="btn-link-custom-table" href="../assets/upload/Planilha_Reclamacao_Atraso_Desarquivamento.xls"
                                                                          target="_blank">clique aqui.</a><br />
        <br />
        O envio das Planilhas e Relatórios, bem como as dúvidas, por favor direcionar para
        SPI Arquivo - <a class="btn-link-custom-table" href="mailto:spi.arquivo@tjsp.jus.br">spi.arquivo@tjsp.jus.br</a><br />
        <br />
    </b-col>
    <b-col col lg="12" class="p-t-20 text-left">
        Prezado Sr. Cartorário das Comarcas do <span class="text-color-red">INTERIOR</span>:<br />
        <br />
        Para baixar a Planilha de Reclamação - Atraso Desarquivamento, <a class="btn-link-custom-table" href="../assets/upload/Planilha_Reclamacao_Atraso_Desarquivamento.xls"
                                                                          target="_blank">clique aqui.</a><br />
        <br />
        O envio das Planilhas e Relatórios, bem como as dúvidas, por favor direcionar para
        SPI Arquivo Interior - <a class="btn-link-custom-table" href="mailto:spi.arquivointerior@tjsp.jus.br">spi.arquivointerior@tjsp.jus.br</a><br />
        <br />
        <br />
        Atenciosamente,<br />
        <br />
        SPI 2.4 - Coordenadoria de Gestão Documental e Arquivos
    </b-col>
    <b-col col lg="10" class="m-t-40 text-left">
        <div class="comunicados left m-t-20 m-b-20 text-color-red">
            <ul>
                <li class="versaoSistema cursor-pointer text-underline">Ver Últimas Atualizações do SGDAU</li>
                <li class="manuaisSistema cursor-pointer text-underline">Ver Manuais do SGDAU</li>
            </ul>
        </div>
    </b-col>
    <b-col col lg="2">
        <div class="inicio-imagem m-t-20 p-l-10 m-b-20 box-border-left">
            <p class="text-size-7 ">
                SGDAU - Sistema Gerenciador de Documentação e Arquivo Unificado
            </p>
            <img src="../assets/images/Recall_Operations.jpg" alt="Recall" />
        </div>
    </b-col>
    <b-col col lg="12">
        <ul>
            <li class="text-left" v-for="unidade in unidades" v-bind:key="unidade.eFTJUnidadeID">
                <!-- content -->
                {{unidade.description}}
            </li>
        </ul>
    </b-col>
</b-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';
import { dataService } from '../shared/data.service';


var data = {
    unidades: []
};

export default {
    name: "Home",
    data: function() {
        return data;
    },
    computed: {
        ...mapState(['userInfo']),
        
    },
    methods: {
        ...mapActions(['loadUserInfo']),

        getUnidades: async function() {
            var result = await dataService.executeQuery({
                "query": "{unidades {eFTJUnidadeID,description}}"
            });

            console.log('result unidades', result.unidades);
            this.unidades = result.unidades;
        }
    },
    mounted(){
        if( this.userInfo === undefined ) {
            console.log('userInfo', this.userInfo)
            this.$router.push({ path: '/login' })
        }
        setTimeout(() => this.getUnidades(), 1000);
    },
    created() {
         this.loadUserInfo();
    }
}
</script>
<style scoped>

</style>

