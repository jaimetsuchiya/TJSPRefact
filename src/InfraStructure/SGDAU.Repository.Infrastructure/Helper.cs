using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace SGDAU.Repository.Infrastructure
{
    public class Helper
    {

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            try
            {
                var fieldNames = Enumerable.Range(0, dr.FieldCount).Select(i => dr.GetName(i)).ToArray();

                List<T> list = new List<T>();
                T obj = default(T);

                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {

                        if (fieldNames.Contains(prop.Name))
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, dr[prop.Name], null);
                            }
                        }

                    }
                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T DataReaderMapToEntity<T>(IDataReader dr)
        {

            try
            {
                var fieldNames = Enumerable.Range(0, dr.FieldCount).Select(i => dr.GetName(i)).ToArray();

                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {

                        if (fieldNames.Contains(prop.Name))
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, dr[prop.Name], null);
                            }
                        }

                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<T> DataReaderMapToListUpdateReader<T>(IDataReader dr)
        {
            try
            {
                var fieldNames = Enumerable.Range(0, dr.FieldCount).Select(i => dr.GetName(i)).ToArray();

                List<T> list = new List<T>();
                T obj = default(T);

                do
                {
                    while (dr.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {

                            if (fieldNames.Contains(prop.Name))
                            {
                                if (!object.Equals(dr[prop.Name], DBNull.Value))
                                {
                                    prop.SetValue(obj, dr[prop.Name], null);
                                }
                            }

                        }
                        list.Add(obj);
                    }
                }
                while (dr.NextResult());

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T DataReaderMapToEntityUpdateReader<T>(IDataReader dr)
        {

            try
            {
                var fieldNames = Enumerable.Range(0, dr.FieldCount).Select(i => dr.GetName(i)).ToArray();

                T obj = default(T);
                do
                {
                    while (dr.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {

                            if (fieldNames.Contains(prop.Name))
                            {
                                if (!object.Equals(dr[prop.Name], DBNull.Value))
                                {
                                    prop.SetValue(obj, dr[prop.Name], null);
                                }
                            }

                        }
                    }
                }
                while (dr.NextResult());

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<T> DataTableMapToList<T>(DataTable dt)
        {
            try
            {
                var fieldNames = Enumerable.Range(0, dt.Columns.Count).Select(i => dt.Columns[i].ColumnName).ToArray();

                List<T> list = new List<T>();
                T obj = default(T);
                if( dt.Rows.Count > 0)
                {
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {
                            if (fieldNames.Contains(prop.Name))
                            {
                                if (!object.Equals(dt.Rows[i][prop.Name], DBNull.Value))
                                {
                                    try
                                    {
                                        prop.SetValue(obj, dt.Rows[i][prop.Name], null);
                                    }
                                    catch (Exception err)
                                    {
                                        Console.WriteLine("Falha ao atribuir a propriedade [" + prop.Name + "]! Erro:" + err.Message);
                                    }

                                }
                            }
                        }
                        list.Add(obj);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T DataTableMapToEntity<T>(DataTable dt)
        {

            try
            {
                var fieldNames = Enumerable.Range(0, dt.Columns.Count).Select(i => dt.Columns[i].ColumnName).ToArray();

                T obj = default(T);
                if (dt.Rows.Count > 0)
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (fieldNames.Contains(prop.Name))
                        {
                            if (!object.Equals(dt.Rows[0][prop.Name], DBNull.Value) )
                            {
                                try
                                {
                                    prop.SetValue(obj, dt.Rows[0][prop.Name], null);
                                }
                                catch (Exception err)
                                {
                                    Console.WriteLine("Falha ao atribuir a propriedade [" + prop.Name + "]! Erro:" + err.Message);
                                }
                            }
                        }
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public static string GetXml(string source, string root, string identificador)
		{
			if(string.IsNullOrEmpty(source))
				return null;

			var str = source.Split(',');

			StringBuilder strLocalidade = new StringBuilder();

			strLocalidade.AppendLine(string.Format("<{0}>", root));

			for(int i = 0; i < str.Length; i++)
				strLocalidade.AppendFormat("<{0}><Id>{1}</Id></{2}>", identificador, str[i], identificador);

			strLocalidade.AppendLine(string.Format("</{0}>", root));


			return strLocalidade.ToString();

		}

		public static string GetXml(string source, string root, string identificador, string chave)
		{
			if(string.IsNullOrEmpty(source))
				return null;

			var str = source.Split(',');

			StringBuilder strLocalidade = new StringBuilder();

			strLocalidade.AppendLine(string.Format("<{0}>", root));

			for(int i = 0; i < str.Length; i++)
				strLocalidade.AppendFormat("<{0}><{1}>{2}</{3}></{4}>", identificador,chave, str[i], chave, identificador);			

			strLocalidade.AppendLine(string.Format("</{0}>", root));

			return strLocalidade.ToString();
		}

		public static string GetXml<T>(List<T> source, string root, string identificador)
		{
			if(source == null || source.Count == 0)	return null;		

			StringBuilder strLocalidade = new StringBuilder();

			strLocalidade.AppendLine(string.Format("<{0}>", root));

			source.ForEach(f=> strLocalidade.AppendFormat("<{0}><Id>{1}</Id></{2}>", identificador, f, identificador));

			strLocalidade.AppendLine(string.Format("</{0}>", root));

			return strLocalidade.ToString();
		}

		public static string GetXml<T>(List<T> source, string root, string identificador, string chave)
		{
			if(source == null || source.Count == 0) return null;

			StringBuilder strLocalidade = new StringBuilder();

			strLocalidade.AppendLine(string.Format("<{0}>", root));

			source.ForEach(f => strLocalidade.AppendFormat("<{0}><{1}>{2}</{3}></{4}>", identificador,chave, f, chave,identificador));

			strLocalidade.AppendLine(string.Format("</{0}>", root));

			return strLocalidade.ToString();
		}

    }
}
