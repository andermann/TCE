using Entidades;
using Domain;
using Repositorio;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Configuration;

namespace front_end
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        public static List<Livros> lstLivros = new List<Livros>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //var teste = new Livraria();

            if (lstLivros.Count.Equals(0))
            {
                CarregarLivros();
            }
            //string retorno = teste.LivrosOrdenacao(lstLivros, "4");

            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            GridView1.DataSource = lstLivros;
            GridView1.DataBind();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string nome = (row.FindControl("txtNome") as TextBox).Text;
            string autor = (row.FindControl("txtAutor") as TextBox).Text;
            string preco = (row.FindControl("txtPreco") as TextBox).Text;
            string dataPublicacao = (row.FindControl("txtDataPublicacao") as TextBox).Text;
            #region old code
            //string query = "UPDATE Customers SET Name=@Name, Country=@Country WHERE CustomerId=@CustomerId";
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Parameters.AddWithValue("@CustomerId", customerId);
            //        cmd.Parameters.AddWithValue("@Name", name);
            //        cmd.Parameters.AddWithValue("@Country", country);
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            #endregion
            Livros livro = CarregarRegistro(
                customerId.ToString()
                , nome
                , autor
                , preco
                , dataPublicacao
                , "");
            if (VerificaLivros(livro))
            {
                lstLivros.Add(livro);
            }

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            //int ISBN = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string ISBN = GridView1.DataKeys[e.NewEditIndex].Values[0].ToString();

            //carrego campos txt
            foreach (var item in lstLivros)
            {
                if (item.ISBN == ISBN.ToString())
                {
                    txtISBN.Text = item.ISBN;
                    txtNome.Text = item.Nome;
                    txtAutor.Text = item.Autor;
                    txtPreco.Text = item.Preco;
                    txtDataPublicacao.Text = item.DataPublicacao;
                    break;
                }
            }

            txtNome.Focus();
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            LimpaCampos(sender, e);
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void LimpaCampos(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtAutor.Text = "";
            txtPreco.Text = "";
            txtDataPublicacao.Text = "";
        }

        protected void Insert(object sender, EventArgs e)
        {
            int customerId = lstLivros.Count() + 1;

            //string ISBN = txtISBN.Text;
            if (txtISBN.Text != "")
            {
                customerId =int.Parse( txtISBN.Text);
            }
            
            string nome = txtNome.Text;
            txtNome.Text = "";
            string autor = txtAutor.Text;
            txtAutor.Text = "";
            string preco = txtPreco.Text;
            txtPreco.Text = "";
            string dataPublicacao = txtDataPublicacao.Text;
            txtDataPublicacao.Text = "";
            #region old code
            //string query = "INSERT INTO Customers VALUES(@Name, @Country)";
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Parameters.AddWithValue("@Name", name);
            //        cmd.Parameters.AddWithValue("@Country", country);
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            #endregion

            //verificar se é atualizar
            if (txtISBN.Text != "")
            {
                //alterar registro
                List<Livros> livrosEditado = new List<Livros>();
                foreach (var item in lstLivros)
                {
                    Livros livroEditado = new Livros();
                    string idTemp = item.ISBN;
                    if (txtISBN.Text == item.ISBN)
                    {
                        idTemp = txtISBN.Text;
                        livroEditado = CarregarRegistro(
                            idTemp, nome, autor, preco, dataPublicacao, "");
                    }
                    else
                    {
                        livroEditado = CarregarRegistro(
                        idTemp, item.Nome, item.Autor, item.Preco, item.DataPublicacao, "");
                    }
                    
                    livrosEditado.Add(livroEditado);
                }
                lstLivros = livrosEditado;
            }
            else
            {
                Livros livro = CarregarRegistro(
                customerId.ToString(), nome, autor, preco, dataPublicacao, "");
                lstLivros.Add(livro);
            }

            txtISBN.Text = "";

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            #region old code
            //string query = "DELETE FROM Customers WHERE CustomerId=@CustomerId";
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Parameters.AddWithValue("@CustomerId", customerId);
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            #endregion

            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[4].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Deseja mesmo excluir este registro?');";
            }
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == GridView1.EditIndex)
            {
                (e.Row.Cells[4].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Deseja mesmo editar esse registro?');";
            }

        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        public List<Livros> CarregarLivros()
        {

        Livros livro1 = CarregarRegistro("1", "Java How to Program", "Deitel & Deitel", "10.11", "01-01-2007", "");
        if (VerificaLivros(livro1))
        {
            lstLivros.Add(livro1);
        }
        Livros livro2 = CarregarRegistro("2", "Patterns of Enterprise Application Architecture", "Martin Fowler", "10.12", "01-01-2002", "");
        if (VerificaLivros(livro2))
        {
            lstLivros.Add(livro2);
        }
        Livros livro3 = CarregarRegistro("3", "Head First Design Patterns", "Elisabeth Freeman", "10.13", "01-01-2004", "");
        if (VerificaLivros(livro3))
        {
            lstLivros.Add(livro3);
        }
        Livros livro4 = CarregarRegistro("4", "Internet & World Wide Web: How to Program", "Deitel & Deitel", "10.14", "01-01-2007", "");
        if (VerificaLivros(livro4))
        {
            lstLivros.Add(livro4);
        }

        Livros livro5 = CarregarRegistro("5", "XXX Internet & World Wide Web: How to Program", "Deitel & Deitel", "10.14", "01-01-2007", "");
        if (VerificaLivros(livro5))
        {
            lstLivros.Add(livro5);
        }

        return lstLivros;
    }

        public Livros CarregarRegistro(string ISBN, string Nome, string Autor
                                                , string Preco, string DataPublicacao, string ImagemdaCapa)
        {
            var retorno = new Livros();

            retorno.ISBN = ISBN;
            retorno.Nome = Nome;
            retorno.Autor = Autor;
            retorno.Preco = Preco;
            retorno.DataPublicacao = DataPublicacao;
            retorno.ImagemdaCapa = ImagemdaCapa;
            return retorno;

        }

        public bool VerificaLivros(Livros livro)
        {
            bool retorno = true;
            // O usuário poderá fazer uma busca ordenada por qualquer atributo do livro;

            foreach (var item in lstLivros)
            {
                if (item.ISBN == livro.ISBN)
                {
                    return false;
                }
            }

            return retorno;
        }


    }
}