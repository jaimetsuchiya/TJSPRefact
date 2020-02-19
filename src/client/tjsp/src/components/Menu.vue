<template>
<div id="menu">
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
            <ul class="nav navbar-nav" data-smartmenus-id="1582133003170208">
                <li id="liHome">
                    <a href="/AcervoAdministrativo/Home.aspx/Index">
                        <img src="/AcervoAdministrativo/images/home_18.png" alt="Home" title="Ir para página inicial">
                    </a>
                </li>
                <li id="1" class="menuRoot">
                    <a class="dropdown-toggle" href="/AcervoAdministrativo/Desarquivamento.aspx/Index">Desarquivamento</a>
                </li>
                <li id="2" class="menuRoot">
                        <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-1" aria-controls="sm-1582133003170208-2">Cadastro <span class="caret"></span><span class="sub-arrow"></span></a>


                    <ul class="dropdown-menu" id="sm-1582133003170208-2" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-1" aria-expanded="false">
                                <li class="text-left" id="152"><a href="/AcervoAdministrativo/CadastroProcesso.aspx/Index">Cadastro de Volumes e Apensos</a></li>
                                <li class="text-left" id="153"><a href="/AcervoAdministrativo/CadastroProcesso.aspx/BaixaProcesso">Baixa de Volumes e Apensos</a></li>
                                <li class="text-left" id="272"><a href="/AcervoAdministrativo/CadastroAdministrativo.aspx/Index">Cadastro de Acervo Administrativo</a></li>
                                <li class="text-left" id="273"><a href="/AcervoAdministrativo/CadastroAdministrativo.aspx/BaixaProcesso">Baixa de Acervo Administrativo</a></li>
                    </ul>
                </li>
                <li id="3" class="menuRoot">
                    <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-3" aria-controls="sm-1582133003170208-4">Consulta <span class="caret"></span><span class="sub-arrow"></span></a>
                    <ul class="dropdown-menu" id="sm-1582133003170208-4" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-3" aria-expanded="false">
                        <li class="text-left" id="5"><a href="/AcervoAdministrativo/OrdemServicoConsulta.aspx/Index">Histórico de Ordem de Serviço</a></li>
                        <li class="text-left" id="7"><a href="/AcervoAdministrativo/ConsultaProcessoInformatizado.aspx/Index">Consulta Processos Cadastrados</a></li>
                        <li class="text-left" id="8"><a href="/AcervoAdministrativo/ConsultaPacote.aspx/Index">Consulta Pacotes Cadastrados</a></li>
                        <li class="text-left" id="111"><a href="/AcervoAdministrativo/Suprimento.aspx/Index">Movimento de Suprimentos</a></li>
                        <li class="text-left" id="174"><a href="/AcervoAdministrativo/ConsultaTipoGuardaSeletiva.aspx/Index">Consulta Tipo de Guarda Seletiva</a></li>
                        <li class="text-left" id="175"><a href="/AcervoAdministrativo/HistoricoCaixa.aspx/Index">Consulta Caixas Cadastradas</a></li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-5" aria-controls="sm-1582133003170208-6">
                                Gestão Documental <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-6" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-5" aria-expanded="false">
                                    <li class="text-left" id="205">
                                        <a href="/AcervoAdministrativo/Eliminacao.aspx/Index" class="dropdown-toggle">Movimento de Lotes de Eliminação</a>
                                    </li>
                                    <li class="text-left" id="208">
                                        <a href="/AcervoAdministrativo/Custodia.aspx/Index" class="dropdown-toggle">Movimento de Custódias</a>
                                    </li>
                                    <li class="text-left" id="201">
                                        <a href="/AcervoAdministrativo/GerenciamentoAcervoCatalogado.aspx/Index" class="dropdown-toggle">Gerenciamento de Acervo Catalogado</a>
                                    </li>
                                    <li class="text-left" id="207">
                                        <a href="/AcervoAdministrativo/Custodiador.aspx/Index" class="dropdown-toggle">Consulta/Cadastro Custodiador</a>
                                    </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li id="9" class="menuRoot">
                    <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" onclick="navigate('/AcervoAdministrativo/ControleMalote.aspx/Index')" id="sm-1582133003170208-7" aria-controls="sm-1582133003170208-8">Atendimento <span class="caret"></span><span class="sub-arrow"></span></a>
                    <ul class="dropdown-menu" id="sm-1582133003170208-8" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-7" aria-expanded="false">
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-9" aria-controls="sm-1582133003170208-10">
                                Iron Mountain <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-10" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-9" aria-expanded="false">
                                    <li class="text-left" id="140">
                                        <a href="/AcervoAdministrativo/PreparacaoSubMalote.aspx/Index" class="dropdown-toggle">Preparação de Submalotes</a>
                                    </li>
                                    <li class="text-left" id="10">
                                        <a href="/AcervoAdministrativo/PreparacaoMalote.aspx/Index" class="dropdown-toggle">Preparação de Malotes</a>
                                    </li>
                                    <li class="text-left" id="146">
                                        <a href="/AcervoAdministrativo/ExpedicaoMalote.aspx/Index" class="dropdown-toggle">Expedição de Malotes</a>
                                    </li>
                                    <li class="text-left" id="86">
                                        <a href="/AcervoAdministrativo/RecebimentoMaloteEnviadoComarca.aspx/Index" class="dropdown-toggle">Recebimento de Malotes da Comarca</a>
                                    </li>
                                    <li class="text-left" id="16">
                                        <a href="/AcervoAdministrativo/ConferenciaMalote.aspx/Index" class="dropdown-toggle">Conferência de Recebimento de Malotes</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-11" aria-controls="sm-1582133003170208-12">
                                Distribuidor/Administração <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-12" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-11" aria-expanded="false">
                                    <li class="text-left" id="11">
                                        <a href="/AcervoAdministrativo/ComarcaRecebeMalote.aspx/Index" class="dropdown-toggle">Receber da Iron Mountain</a>
                                    </li>
                                    <li class="text-left" id="14">
                                        <a href="/AcervoAdministrativo/ComarcaRecebeVara.aspx/Index" class="dropdown-toggle">Receber da Vara</a>
                                    </li>
                                    <li class="text-left" id="15">
                                        <a href="/AcervoAdministrativo/ComarcaEnviaMalote.aspx/Index" class="dropdown-toggle">Enviar para Iron Mountain</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-13" aria-controls="sm-1582133003170208-14">
                                Vara <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-14" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-13" aria-expanded="false">
                                    <li class="text-left" id="12">
                                        <a href="/AcervoAdministrativo/VaraRecebeSubMaloteComarca.aspx/Index" class="dropdown-toggle">Receber SubMalote</a>
                                    </li>
                                    <li class="text-left" id="13">
                                        <a href="/AcervoAdministrativo/VaraEnviaSubMalote.aspx/Index" class="dropdown-toggle">Enviar para Comarca</a>
                                    </li>
                                    <li class="text-left" id="156">
                                        <a href="/AcervoAdministrativo/SolicitacaoColeta.aspx/Index" class="dropdown-toggle">Gerenciar Pedido de Coleta</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-15" aria-controls="sm-1582133003170208-16">
                                Outros Destinos <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-16" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-15" aria-expanded="false">
                                    <li class="text-left" id="51">
                                        <a href="/AcervoAdministrativo/SPIGDCRecebeMalote.aspx/Index" class="dropdown-toggle">Receber Malote da Iron Mountain</a>
                                    </li>
                                    <li class="text-left" id="52">
                                        <a href="/AcervoAdministrativo/SPIGDCEnviaMalote.aspx/Index" class="dropdown-toggle">Enviar Malote para Iron Mountain</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-17" aria-controls="sm-1582133003170208-18">
                                Consultas <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-18" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-17" aria-expanded="false">
                                    <li class="text-left" id="31">
                                        <a href="/AcervoAdministrativo/ConsultaHistoricoSubMaloteMalote.aspx/Index" class="dropdown-toggle">Consulta Histórico Malote/Submalote</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-19" aria-controls="sm-1582133003170208-20">
                                Manutenção <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-20" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-19" aria-expanded="false">
                                    <li class="text-left" id="54">
                                        <a href="/AcervoAdministrativo/RegularizarMaloteIron.aspx/Index" class="dropdown-toggle">Movimentar Malote</a>
                                    </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li id="42" class="menuRoot">
                    <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-21" aria-controls="sm-1582133003170208-22">Gerencial <span class="caret"></span><span class="sub-arrow"></span></a>
                    <ul class="dropdown-menu" id="sm-1582133003170208-22" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-21" aria-expanded="false">
                        <li class="text-left" id="43"><a href="/AcervoAdministrativo/Faturamento.aspx/Index">Faturamento</a></li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-23" aria-controls="sm-1582133003170208-24">
                                Usuários <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-24" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-23" aria-expanded="false">
                                    <li class="text-left" id="19">
                                        <a href="/AcervoAdministrativo/ManutencaoCadastroUsuario.aspx/Index" class="dropdown-toggle">Manutenção de Usuários</a>
                                    </li>
                                    <li class="text-left" id="20">
                                        <a href="/AcervoAdministrativo/CadastroGrupoUsuario.aspx/Index" class="dropdown-toggle">Grupo de Usuários</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-25" aria-controls="sm-1582133003170208-26">
                                Parametros <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-26" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-25" aria-expanded="false">
                                    <li class="text-left" id="38">
                                        <a href="/AcervoAdministrativo/ParametroAplicacao.aspx/Index" class="dropdown-toggle">Variáveis do Sistema</a>
                                    </li>
                            </ul>
                        </li>
                        <li class="text-left" id="82"><a href="/AcervoAdministrativo/Comarca.aspx/Index">Parametrização de Comarca</a></li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-27" aria-controls="sm-1582133003170208-28">
                                Cadastros <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-28" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-27" aria-expanded="false">
                                    <li class="text-left" id="91">
                                        <a href="/AcervoAdministrativo/Localidade.aspx/Index" class="dropdown-toggle">Localidade</a>
                                    </li>
                                    <li class="text-left" id="92">
                                        <a href="/AcervoAdministrativo/Operador.aspx/Index" class="dropdown-toggle">Operador de Resgate</a>
                                    </li>
                                    <li class="text-left" id="93">
                                        <a href="/AcervoAdministrativo/SuspenseListMotivo.aspx/Index" class="dropdown-toggle">Motivo de Suspense List</a>
                                    </li>
                                    <li class="text-left" id="94">
                                        <a href="/AcervoAdministrativo/Rota.aspx/Index" class="dropdown-toggle">Rota</a>
                                    </li>
                                    <li class="text-left" id="95">
                                        <a href="/AcervoAdministrativo/Unidade.aspx/Index" class="dropdown-toggle">Unidade</a>
                                    </li>
                                    <li class="text-left" id="96">
                                        <a href="/AcervoAdministrativo/Feriado.aspx/Index" class="dropdown-toggle">Feriado</a>
                                    </li>
                                    <li class="text-left" id="97">
                                        <a href="/AcervoAdministrativo/LocalidadeRegex.aspx/Index" class="dropdown-toggle">Regras de Localidades de Itens</a>
                                    </li>
                                    <li class="text-left" id="117">
                                        <a href="/AcervoAdministrativo/ReservaEtiqueta.aspx/Index" class="dropdown-toggle">Reserva de Etiquetas para Caixas</a>
                                    </li>
                                    <li class="text-left" id="202">
                                        <a href="/AcervoAdministrativo/Temporalidade.aspx/Index" class="dropdown-toggle">Temporalidade</a>
                                    </li>
                                    <li class="text-left" id="121">
                                        <a href="/AcervoAdministrativo/Malote.aspx/Index" class="dropdown-toggle">Malotes</a>
                                    </li>
                                    <li class="text-left" id="141">
                                        <a href="/AcervoAdministrativo/NCS.aspx/Index" class="dropdown-toggle">Cadastro de NCS</a>
                                    </li>
                                    <li class="text-left" id="160">
                                        <a href="/AcervoAdministrativo/CadastroImpressora.aspx/Index" class="dropdown-toggle">Impressora Zebra</a>
                                    </li>
                                    <li class="text-left" id="172">
                                        <a href="/AcervoAdministrativo/Advogado.aspx/Index" class="dropdown-toggle">Advogados</a>
                                    </li>
                            </ul>
                        </li>
                        <li class="text-left" id="131"><a href="/AcervoAdministrativo/Dashboard.aspx/Index">Dashboard</a></li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-29" aria-controls="sm-1582133003170208-30">
                                Utilitários <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-30" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-29" aria-expanded="false">
                                    <li class="text-left" id="179">
                                        <a href="/AcervoAdministrativo/ImportacaoSKP.aspx/Index" class="dropdown-toggle">Importação Arquivos SKP</a>
                                    </li>
                                    <li class="text-left" id="159">
                                        <a href="/AcervoAdministrativo/ConfiguracaoPerfil.aspx/Index" class="dropdown-toggle">Configuração de Perfil do Usuário</a>
                                    </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li id="40" class="menuRoot open">
                    <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-31" aria-controls="sm-1582133003170208-32">Operacional <span class="caret"></span><span class="sub-arrow"></span></a>
                    <ul class="dropdown-menu" id="sm-1582133003170208-32" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-31" aria-expanded="false">
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-33" aria-controls="sm-1582133003170208-34">
                                Desarquivamento <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-34" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-33" aria-expanded="false">
                                    <li class="text-left" id="99">
                                        <a href="/AcervoAdministrativo/OrdemServico.aspx/Index" class="dropdown-toggle">Movimento de Ordem de Acesso</a>
                                    </li>
                                    <li class="text-left" id="151">
                                        <a href="/AcervoAdministrativo/PriorizacaoAtendimento.aspx/Index" class="dropdown-toggle">Priorização Atendimento Desmobilização</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-35" aria-controls="sm-1582133003170208-36">
                                Devolução <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-36" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-35" aria-expanded="false">
                                    <li class="text-left" id="56">
                                        <a href="/AcervoAdministrativo/Indexacao.aspx/Index" class="dropdown-toggle">Indexação de Processos</a>
                                    </li>
                                    <li class="text-left" id="70">
                                        <a href="/AcervoAdministrativo/Auditoria.aspx/Index" class="dropdown-toggle">Auditoria de Caixas</a>
                                    </li>
                            </ul>
                        </li>
                        <li class="text-left" id="102"><a href="/AcervoAdministrativo/ManutencaoPacote.aspx/Index">Manutenção de Pacotes</a></li>
                        <li class="text-left" id="83"><a href="/AcervoAdministrativo/Expurgo.aspx/Index">Expurgo de Pacotes</a></li>
                        <li class="text-left" id="105"><a href="/AcervoAdministrativo/SuspenseList.aspx/Index">Itens Aguardando Localização</a></li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-37" aria-controls="sm-1582133003170208-38">
                                Apanhas de Novos Pacotes <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-38" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-37" aria-expanded="false">
                                    <li class="text-left" id="73">
                                        <a href="/AcervoAdministrativo/ApanhaOld.aspx/Index" class="dropdown-toggle">Movimento de Apanhas</a>
                                    </li>
                                    <li class="text-left" id="75">
                                        <a href="/AcervoAdministrativo/Auditor.aspx/Index" class="dropdown-toggle">Configuração de Auditores</a>
                                    </li>
                                    <li class="text-left" id="76">
                                        <a href="/AcervoAdministrativo/ConferenciaTransporte.aspx/Index" class="dropdown-toggle">Coleta de Caixas Auditadas</a>
                                    </li>
                                    <li class="text-left" id="77">
                                        <a href="/AcervoAdministrativo/RecebimentoApanha.aspx/Index" class="dropdown-toggle">Recebimento de Caixas Coletadas</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-39" aria-controls="sm-1582133003170208-40">
                                Junção de Caixas <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-40" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-39" aria-expanded="false">
                                    <li class="text-left" id="85">
                                        <a href="/AcervoAdministrativo/JuncaoCaixa.aspx/Index" class="dropdown-toggle">Junção de Pacotes</a>
                                    </li>
                                    <li class="text-left" id="84">
                                        <a href="/AcervoAdministrativo/JuncaoDevolucao.aspx/Index" class="dropdown-toggle">Junção de Processos</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-41" aria-controls="sm-1582133003170208-42">
                                Desmobilização 1940 <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-42" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-41" aria-expanded="false">
                                    <li class="text-left" id="59">
                                        <a href="/AcervoAdministrativo/Desmobilizacao.aspx/Index" class="dropdown-toggle">Movimento de Desmobilização - Recall</a>
                                    </li>
                                    <li class="text-left" id="61">
                                        <a href="/AcervoAdministrativo/DesmobilizacaoSPI.aspx/Index" class="dropdown-toggle">Movimento de Desmobilização - SPI</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-43" aria-controls="sm-1582133003170208-44">
                                Movimentação e Regularização <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-44" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-43" aria-expanded="false">
                                    <li class="text-left" id="118">
                                        <a href="/AcervoAdministrativo/AlterarLocalizacaoCaixa.aspx/Index" class="dropdown-toggle">Alterar Localização/Status de Item</a>
                                    </li>
                                    <li class="text-left" id="120">
                                        <a href="/AcervoAdministrativo/IndexacaoItemIrregular.aspx/Index" class="dropdown-toggle">Indexação de Itens Irregulares</a>
                                    </li>
                                    <li class="text-left" id="106">
                                        <a href="/AcervoAdministrativo/ReetiquetamentoCaixa.aspx/Index" class="dropdown-toggle">Reetiquetamento de Caixas</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-45" aria-controls="sm-1582133003170208-46">
                                Relatórios <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-46" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-45" aria-expanded="false">
                                    <li class="text-left" id="116">
                                        <a href="/AcervoAdministrativo/RelatorioOperacao.aspx/Index" class="dropdown-toggle">Relatório de Operações de Processos</a>
                                    </li>
                                    <li class="text-left" id="125">
                                        <a href="/AcervoAdministrativo/ProcessosDevolvidos.aspx/Index" class="dropdown-toggle">Processos Devolvidos Sem Registro Sistêmico</a>
                                    </li>
                                    <li class="text-left" id="126">
                                        <a href="/AcervoAdministrativo/SubMalotesDevolvidos.aspx/Index" class="dropdown-toggle"> Submalotes Devolvidos Sem Registro Sistêmico</a>
                                    </li>
                                    <li class="text-left" id="127">
                                        <a href="/AcervoAdministrativo/AcompanhamentoOrdemServico.aspx/Index" class="dropdown-toggle">Acompanhamento de Ordem de Serviço</a>
                                    </li>
                                    <li class="text-left" id="145">
                                        <a href="/AcervoAdministrativo/MaloteDisponivelComarca.aspx/Index" class="dropdown-toggle">Malotes disponíveis nas Comarcas</a>
                                    </li>
                                    <li class="text-left" id="144">
                                        <a href="/AcervoAdministrativo/SubMaloteDisponivelVara.aspx/Index" class="dropdown-toggle">Submalotes disponíveis nas Varas</a>
                                    </li>
                            </ul>
                        </li>
                        <li class="text-left" id="128"><a href="/AcervoAdministrativo/PreApanhaPacote.aspx/Index">Pré Apanha Pacote</a></li>
                        <li class="text-left" id="129"><a href="/AcervoAdministrativo/CronogramaApanha.aspx/Index">Cronograma de Apanha</a></li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-47" aria-controls="sm-1582133003170208-48">
                                Coleta <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-48" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-47" aria-expanded="false">
                                    <li class="text-left" id="154">
                                        <a href="/AcervoAdministrativo/Coleta.aspx/Index" class="dropdown-toggle">Movimentação de Coleta</a>
                                    </li>
                                    <li class="text-left" id="161">
                                        <a href="/AcervoAdministrativo/ConferenciaColeta.aspx/Index" class="dropdown-toggle">Coleta de Caixas Auditadas</a>
                                    </li>
                                    <li class="text-left" id="162">
                                        <a href="/AcervoAdministrativo/RecebimentoColeta.aspx/Index" class="dropdown-toggle">Recebimento de Caixas Coletadas</a>
                                    </li>
                                    <li class="text-left" id="163">
                                        <a href="/AcervoAdministrativo/ConferenciaCaixa.aspx/Index" class="dropdown-toggle">Conferência de Caixas Coletadas</a>
                                    </li>
                                    <li class="text-left" id="170">
                                        <a href="/AcervoAdministrativo/IndexacaoColeta.aspx/Index" class="dropdown-toggle">Indexação de Processos</a>
                                    </li>
                                    <li class="text-left" id="171">
                                        <a href="/AcervoAdministrativo/AuditoriaSeletiva.aspx/Index" class="dropdown-toggle">Auditoria Seletiva</a>
                                    </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle has-submenu" aria-haspopup="true" aria-expanded="false" id="sm-1582133003170208-49" aria-controls="sm-1582133003170208-50">
                                Catalogação <span class="caret"></span>
                            <span class="sub-arrow"></span></a>
                            <ul class="dropdown-menu" id="sm-1582133003170208-50" role="group" aria-hidden="true" aria-labelledby="sm-1582133003170208-49" aria-expanded="false">
                                    <li class="text-left" id="178">
                                        <a href="/AcervoAdministrativo/CatalogacaoLote.aspx/Index" class="dropdown-toggle">Movimento de Lotes</a>
                                    </li>
                                    <li class="text-left" id="182">
                                        <a href="/AcervoAdministrativo/CadastroCatalogacao.aspx/Index" class="dropdown-toggle">Cadastro de Processos e Apensos</a>
                                    </li>
                                    <li class="text-left" id="181">
                                        <a href="/AcervoAdministrativo/IndexacaoCatalogacao.aspx/Index" class="dropdown-toggle">Indexação Catalogação</a>
                                    </li>
                                    <li class="text-left" id="180">
                                        <a href="/AcervoAdministrativo/AuditoriaCatalogacao.aspx/Index" class="dropdown-toggle">Auditoria Catalogação</a>
                                    </li>
                                    <li class="text-left" id="184">
                                        <a href="/AcervoAdministrativo/RelatorioItensRecebidosCatalogacao.aspx/Index" class="dropdown-toggle">Relatório de Itens Recebidos na Unidade de Catalogação</a>
                                    </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
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
<style scoped>
    #menu { 
        width:100%;
        margin:0px;
        padding:0px;
    }
</style>