using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Desarquivamento.Domain.Models
{
    public partial class EFTJDesarquivamentoPesquisa
    {
        public int EFAccountID3 { get; set; }
        public int EFAccountID4 { get; set; }

        public int N4AccountID { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string N3 { get; set; }
        public string N4 { get; set; }
        public string ItemCode { get; set; }
        public decimal ItemSeq { get; set; }
        public string Ind_Asc_6 { get; set; }
        public decimal Ind_Num_1 { get; set; }
        public decimal Ind_Num_2 { get; set; }
        public decimal Ind_Num_3 { get; set; }
        public decimal Ind_Num_4 { get; set; }
        public decimal Ind_Num_5 { get; set; }
        public decimal Ind_Num_6 { get; set; }
        public decimal Dic1ID { get; set; }
        public string Dic1Desc { get; set; }
        public string Ind_Asc_3 { get; set; }
        public string Ind_Asc_4 { get; set; }
        public string Ind_Asc_9 { get; set; }
        public decimal Dic2ID { get; set; }
        public string Dic2Desc { get; set; }
        public string Dic9Desc { get; set; }
        public string Ind_Asc_1 { get; set; }
        public string Ind_Asc_2 { get; set; }
        public int ObjectID { get; set; }
        public string ObjectCode { get; set; }
        public string ObjectDesc { get; set; }
        public string Caixa { get; set; }
        public DateTime? DataDestruicao { get; set; }
        public DateTime DataAdicao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Prioridade { get; set; }
        public int HasImage { get; set; }
        public int Auditoria { get; set; }
        public int AnoCaixa { get; set; }
        public int ItemSeqCaixa { get; set; }
        public string LocationCode { get; set; }
        public int StatusID { get; set; }
        public string Msg { get; set; }
        public string MsgTJ { get; set; }
        public string StatusItem { get; set; }
        public string ContainerItemID { get; set; }
        public DateTime? DestroyDtime { get; set; }
        public string AlternateCode { get; set; }
        public string WorkOrderCode { get; set; }
        public int EFTJDocumentoOperacaoID { get; set; }
        public int Pacote { get; set; }
        public int AnoPacote { get; set; }
        public int TipoImagem { get; set; }

        public List<EFTJPolo> Polos { get; set; }
        public string CreateUserCode { get; set; }
        public string UserCode { get; set; }
        public string Assunto { get; set; }
        public string Competencia { get; set; }
    }
}
