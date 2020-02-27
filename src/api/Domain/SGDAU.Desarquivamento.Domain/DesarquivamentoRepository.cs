using SGDAU.Desarquivamento.Domain.Models;
using SGDAU.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;

namespace SGDAU.Desarquivamento.Domain
{
    public interface IDesarquivamentoPesquisaRepository
    {
        ICollection<EFTJDesarquivamentoPesquisa> GetDesarquivamentoPesquisa(EFTJDesarquivamentoPesquisa DesarquivamentoPesquisa);
    }

    public class DesarquivamentoPesquisaRepository : IDesarquivamentoPesquisaRepository
    {
        private readonly IDatabaseQueryCommand databaseQueryCommand;

        public DesarquivamentoPesquisaRepository(IDatabaseQueryCommand databaseQueryCommand)
        {
            this.databaseQueryCommand = databaseQueryCommand;
        }

        public static string Procedure
        {
            get { return "consultar_inventario_sgdai2"; }
        }
        public string ProcedureItem
        {
            get { return "cadastro_item_sgdai"; }
        }

        public ICollection<EFTJDesarquivamentoPesquisa> GetDesarquivamentoPesquisa(EFTJDesarquivamentoPesquisa desarquivamentoPesquisa)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            //Consulta somente pelo ItemCode
            parameters.Add(new SqlParameter("@ItemCode", desarquivamentoPesquisa.ItemCode));
            parameters.Add(new SqlParameter("@EFAccountID3", desarquivamentoPesquisa.EFAccountID3));
            if (string.IsNullOrEmpty(desarquivamentoPesquisa.ItemCode))
            {
                //Consulta pelos filtros
                parameters.Add(new SqlParameter("@EFAccountID4", desarquivamentoPesquisa.EFAccountID4));
                parameters.Add(new SqlParameter("@Ind_Asc_6", desarquivamentoPesquisa.Ind_Asc_6));
                if (desarquivamentoPesquisa.Ind_Num_1 != decimal.MinValue && desarquivamentoPesquisa.Ind_Num_1 != 0)
                {
                    parameters.Add(new SqlParameter("@Ind_Num_1", desarquivamentoPesquisa.Ind_Num_1));
                }
                if (desarquivamentoPesquisa.Ind_Num_2 != decimal.MinValue && desarquivamentoPesquisa.Ind_Num_2 != 0)
                {
                    parameters.Add(new SqlParameter("@Ind_Num_2", desarquivamentoPesquisa.Ind_Num_2));
                }
                if (desarquivamentoPesquisa.Ind_Num_3 != decimal.MinValue && desarquivamentoPesquisa.Ind_Num_3 != 0)
                {
                    parameters.Add(new SqlParameter("@Ind_Num_3", desarquivamentoPesquisa.Ind_Num_3));
                }
                if (desarquivamentoPesquisa.Ind_Num_4 != decimal.MinValue && desarquivamentoPesquisa.Ind_Num_4 != 0)
                {
                    parameters.Add(new SqlParameter("@Ind_Num_4", desarquivamentoPesquisa.Ind_Num_4));
                }
                if (desarquivamentoPesquisa.Ind_Num_5 != decimal.MinValue && desarquivamentoPesquisa.Ind_Num_5 != 0)
                {
                    parameters.Add(new SqlParameter("@Ind_Num_5", desarquivamentoPesquisa.Ind_Num_5));
                }
                if (desarquivamentoPesquisa.Ind_Num_6 != decimal.MinValue && desarquivamentoPesquisa.Ind_Num_6 != 0)
                {
                    parameters.Add(new SqlParameter("@Ind_Num_6", desarquivamentoPesquisa.Ind_Num_6));
                }
                if (desarquivamentoPesquisa.Dic1ID != decimal.MinValue && desarquivamentoPesquisa.Dic1ID != 0)
                {
                    parameters.Add(new SqlParameter("@Dic1ID", desarquivamentoPesquisa.Dic1ID));
                }
                parameters.Add(new SqlParameter("@Ind_Asc_3", desarquivamentoPesquisa.Ind_Asc_3));
                parameters.Add(new SqlParameter("@Ind_Asc_4", desarquivamentoPesquisa.Ind_Asc_4));
                parameters.Add(new SqlParameter("@Ind_Asc_9", desarquivamentoPesquisa.Ind_Asc_9));
                if (desarquivamentoPesquisa.Dic2ID != decimal.MinValue && desarquivamentoPesquisa.Dic2ID != 0)
                {
                    parameters.Add(new SqlParameter("@Dic2ID", desarquivamentoPesquisa.Dic2ID));
                }
                parameters.Add(new SqlParameter("@Ind_Asc_1", desarquivamentoPesquisa.Ind_Asc_1));
                parameters.Add(new SqlParameter("@Ind_Asc_2", desarquivamentoPesquisa.Ind_Asc_2));
            }

            var itemList = this.databaseQueryCommand.Select<EFTJDesarquivamentoPesquisa>(Procedure, parameters);
            if (itemList != null && itemList.Count > 0)
            {
                var lstTmp = itemList.ToList();
                for (var i = 0; i < lstTmp.Count; i++)
                {
                    lstTmp[i].CreateUserCode = desarquivamentoPesquisa.CreateUserCode;
                    lstTmp[i].UserCode = desarquivamentoPesquisa.UserCode;
                    RecuperarPolos(lstTmp[i]);
                }

            }

            return itemList;
        }
        private void RecuperarPolos(EFTJDesarquivamentoPesquisa desarquivamentoPesquisa)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@veExecutor", 1));
            parameters.Add(new SqlParameter("@veParametro", 40));
            parameters.Add(new SqlParameter("@veItemCode", desarquivamentoPesquisa.ItemCode));
            parameters.Add(new SqlParameter("@veItemSeq", desarquivamentoPesquisa.ItemSeq));
            parameters.Add(new SqlParameter("@veUserCode", desarquivamentoPesquisa.UserCode));
            parameters.Add(new SqlParameter("@veCreateUserCode", desarquivamentoPesquisa.CreateUserCode));

            var itemList = this.databaseQueryCommand.Select<EFTJPolo>(ProcedureItem, parameters);
            if (itemList != null && itemList.Count > 0)
            {
                var lstItemList = itemList.ToList();
                for (var i = 0; i < lstItemList.Count; i++)
                    lstItemList[i].Advogados = AdvogadosFromXML(lstItemList[i].AdvogadosXML);

                desarquivamentoPesquisa.Polos = lstItemList;
            }
        }
        private List<EFTJPoloAdvogado> AdvogadosFromXML(string advogadoXML)
        {
            List<EFTJPoloAdvogado> poloAdvogados = new List<EFTJPoloAdvogado>();
            if (string.IsNullOrEmpty(advogadoXML))
                return poloAdvogados;

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(advogadoXML);

            var nodes = xmlDoc.SelectNodes("//poloAdv");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode nde in nodes)
                {
                    var nodesAdv = nde.SelectNodes("adv");
                    if (nodesAdv != null && nodesAdv.Count > 0)
                    {
                        foreach (XmlNode ndeAdv in nodesAdv)
                        {
                            var adv = new EFTJPoloAdvogado();
                            if (ndeAdv.SelectSingleNode("EFTJAdvogadoID") != null && ndeAdv.SelectSingleNode("EFTJAdvogadoID").InnerText != "")
                                adv.EFTJAdvogadoID = Convert.ToInt32(ndeAdv.SelectSingleNode("EFTJAdvogadoID").InnerText);

                            if (ndeAdv.SelectSingleNode("Codigo") != null && ndeAdv.SelectSingleNode("Codigo").InnerText != "")
                                adv.Codigo = ndeAdv.SelectSingleNode("Codigo").InnerText;

                            if (ndeAdv.SelectSingleNode("Nome") != null && ndeAdv.SelectSingleNode("Nome").InnerText != "")
                                adv.Nome = ndeAdv.SelectSingleNode("Nome").InnerText;

                            if (nde.SelectSingleNode("NaoHaInformacao") != null && nde.SelectSingleNode("NaoHaInformacao").InnerText != "")
                                adv.NaoHaInformacao = nde.SelectSingleNode("NaoHaInformacao").InnerText == "1";

                            poloAdvogados.Add(adv);
                        }
                    }
                }
            }

            return poloAdvogados;
        }
    }
}