<template>
<b-navbar toggleable="lg" id="bs-example-navbar-collapse-1">
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
    <b-collapse id="nav-collapse" is-nav>
     
      <!-- Right aligned nav items -->
      <b-navbar-nav class="ml-auto">
        
        <b-nav-item href="#">
            <img src="../assets/images/home_18.png" alt="Home" title="Ir para página inicial">
        </b-nav-item>
        <b-nav-item href="#">
            Desarquivamento
        </b-nav-item>
        <b-nav-item-dropdown text="Cadastro" left>
          <b-dropdown-item href="#">Cadastro de Volumes e Apensos</b-dropdown-item>
          <b-dropdown-item href="#">Baixa de Volumes e Apensos</b-dropdown-item>
          <b-dropdown-item href="#">Cadastro de Acervo Administrativo</b-dropdown-item>
          <b-dropdown-item href="#">Baixa de Acervo Administrativo</b-dropdown-item>
        </b-nav-item-dropdown>

        <b-nav-item-dropdown text="Consulta" left>
          <b-dropdown-item href="#">Histórico de Ordem de Serviço</b-dropdown-item>
          <b-dropdown-item href="#">Consulta Processos Cadastrados</b-dropdown-item>
          <b-dropdown-item href="#">Consulta Pacotes Cadastrados</b-dropdown-item>
          <b-dropdown-item href="#">Movimento de Suprimentos</b-dropdown-item>
          <b-dropdown-item href="#">Consulta Tipo de Guarda Seletiva</b-dropdown-item>
          <b-dropdown-item href="#">Consulta Caixas Cadastradas</b-dropdown-item>
        </b-nav-item-dropdown>

        <b-nav-item-dropdown text="Atendimento" left>
          <b-dropdown-item href="#">Iron Mountain</b-dropdown-item>
          <b-dropdown-item href="#">Distribuidor/Administração</b-dropdown-item>
          <b-dropdown-item href="#">Vara</b-dropdown-item>
          <b-dropdown-item href="#">Outros Destinos</b-dropdown-item>
          <b-dropdown-item href="#">Consultas</b-dropdown-item>
          <b-dropdown-item href="#">Manutenção</b-dropdown-item>
        </b-nav-item-dropdown>

        <b-nav-item-dropdown text="Gerencial" left>
          <b-dropdown-item href="#">Faturamento</b-dropdown-item>
          <b-dropdown-item href="#">Usuários</b-dropdown-item>
          <b-dropdown-item href="#">Parâmetros</b-dropdown-item>
          <b-dropdown-item href="#">Parametrização de Comarca</b-dropdown-item>
          <b-dropdown-item href="#">Cadastros</b-dropdown-item>
          <b-dropdown-item href="#">Dashboard</b-dropdown-item>
          <b-dropdown-item href="#">Utilitários</b-dropdown-item>
        </b-nav-item-dropdown>

        <b-nav-item-dropdown text="Operacional" left>
          <b-dropdown-item href="#">Desarquivamento</b-dropdown-item>
          <b-dropdown-item href="#">Devolução</b-dropdown-item>
          <b-dropdown-item href="#">Manutenção de Pacotes</b-dropdown-item>
          <b-dropdown-item href="#">Expurgo de Pacotes</b-dropdown-item>
          <b-dropdown-item href="#">Itens Aguardando Localização</b-dropdown-item>
          <b-dropdown-item href="#">Apanhas de Novos Pacotes</b-dropdown-item>
          <b-dropdown-item href="#">Junção de Caixas</b-dropdown-item>
          <b-dropdown-item href="#">Desmobilização 1940</b-dropdown-item>
          <b-dropdown-item href="#">Movimentação e Regularização</b-dropdown-item>
          <b-dropdown-item href="#">Relatórios</b-dropdown-item>
          <b-dropdown-item href="#">Pré Apanha Pacotes</b-dropdown-item>
          <b-dropdown-item href="#">Cronograma de Apanha</b-dropdown-item>
          <b-dropdown-item href="#">Coleta</b-dropdown-item>
          <b-dropdown-item href="#">Catalogação</b-dropdown-item>
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
<style >
    #menu { 
        width:100%;
        margin:0px;
        padding:0px;
    }
  
</style>