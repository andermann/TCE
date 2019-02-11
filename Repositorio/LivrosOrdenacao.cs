using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
   public class LivrosOrdenacao
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="livros"></param>
        /// <param name="strRegra"></param>
        /// <returns></returns>
        public string RetornaListaLivrosOrdenado(List<Livros> livros, string strRegra)
        {
            DataTable dtLivros = ConvertListToDataTable(livros);

            var objOrdenacao = ListaOrdenacao(dtLivros, strRegra);

            string retorno = "";

            if (objOrdenacao.Count != 0)
            {
                retorno = "Livros ";
                int cont = 0;

                foreach (Livros item in objOrdenacao)
                {
                    if (cont == 0)
                        retorno = string.Concat(retorno, item.ISBN);
                    else
                        retorno = string.Concat(retorno, ",", item.ISBN);

                    cont++;
                }
            }

            return retorno;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtLivros"></param>
        /// <param name="strRegra"></param>
        /// <returns></returns>
        private List<Livros> ListaOrdenacao(DataTable dtLivros, string strRegra)
        {
            List<Livros> ListaOrdenada = new List<Livros>();

            //if (ConfigurationManager.AppSettings[string.Concat("Regra", strRegra)].ToString() != "")
            //{

            //NameValueCollection teste = new NameValueCollection();
                
            var teste = ConfigurationManager.AppSettings[string.Concat("Regra", strRegra)];
            
            if (teste != null) { 
                dtLivros.DefaultView.Sort = ConfigurationManager.AppSettings[string.Concat("Regra", strRegra)];
                dtLivros = dtLivros.DefaultView.ToTable();
                ListaOrdenada = ConvertDataTableToList<Livros>(dtLivros);
            }
           

            return ListaOrdenada;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private DataTable ConvertListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            System.Reflection.PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    if (item != null)
                    {
                        values[i] = Props[i].GetValue(item, null);

                    }
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();

            var properties = typeof(T).GetProperties();

            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                        pro.SetValue(objT, row[pro.Name]);
                }
                return objT;
            }).ToList();
        }
    }
}
