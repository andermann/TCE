using Entidades;
using Domain;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesOrdenacao
{
    public class Teste_Ordenacao
    {
          
        [TestFixture]
        public class ServiceTesteOrdenacao
        {
            List<Livros> lstLivros = new List<Livros>();

            /// <summary>
            /// 
            /// </summary>
            [Test]
             public void DTOrdenacaoNomeAsc()
             {

                 var teste = new Livraria();

                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }
                string retorno = teste.LivrosOrdenacao(lstLivros, "1");
                Assert.That(retorno, Is.EqualTo("Livros 3,4,1,2,5"));
            }

            /// <summary>
            /// 
            /// </summary>
            [Test]
             public void DTOrdenacaoAutorAscPrecoDsc()
             {

                 var teste = new Livraria();

                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }
                string retorno = teste.LivrosOrdenacao(lstLivros, "2");
                Assert.That(retorno, Is.EqualTo("Livros 4,5,1,3,2"));
            }

            /// <summary>
            /// 
            /// </summary>
            [Test]
             public void DTOrdenacaoDataPublicacaoDscNomeDscAutorAsc()
             {

                 var teste = new Livraria();

                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }
                string retorno = teste.LivrosOrdenacao(lstLivros, "3");
                 Assert.That(retorno, Is.EqualTo("Livros 5,1,4,3,2"));
            }

            [Test]
            public void DTOrdenacaoTodos()
            {

                var teste = new Livraria();

                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }
                string retorno = teste.LivrosOrdenacao(lstLivros, "4");
                Assert.That(retorno, Is.EqualTo("Livros 1,2,3,4,5"));
            }

            /// <summary>
            /// 
            /// </summary>
            [Test]
             public void DTOrdenacaoEmpty()
             {

                 var teste = new Livraria();

                 //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }
                 string retorno = teste.LivrosOrdenacao(lstLivros, "");
                 Assert.That(retorno, Is.Empty);

             }


            [Test]
            public void DTEncontrarLivro1()
            {
                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }

                var find = new Livros();

                find.ISBN = "1";
                find.Nome = "Java How to Program";

                List<Livros> pesquisa = PesquisarLivros(find);

                int qtdRegs = pesquisa.Count;

                Assert.That(qtdRegs, Is.EqualTo(1) );
            }

            [Test]
            public void DTEncontrarLivro2()
            {
                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }

                var find = new Livros();

                find.Autor = "Martin Fowler";

                List<Livros> pesquisa = PesquisarLivros(find);

                int qtdRegs = pesquisa.Count;

                Assert.That(qtdRegs, Is.EqualTo(1));
            }

            [Test]
            public void DTEncontrarLivro3()
            {
                //List<Livros> lstLivros =  CarregarLivros();
                if (lstLivros.Count.Equals(0))
                {
                    CarregarLivros();
                }

                var find = new Livros();

                find.ISBN = "1";
                find.Nome = "Java How to Program";
                find.Autor = "Martin Fowler";
                find.Preco = "10.13";
                //find.DataPublicacao = DataPublicacao;
                //find.ImagemdaCapa = ImagemdaCapa;

                List<Livros> pesquisa = PesquisarLivros(find);

                int qtdRegs = pesquisa.Count;

                Assert.That(qtdRegs, Is.EqualTo(3));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="livro"></param>
            /// <returns></returns>
            public List<Livros> PesquisarLivros(Livros livro)
            {
                List<Livros> retorno = new List<Livros>();
                bool ok = false;

                foreach (var item in lstLivros)
                {
                    if (item.ISBN == livro.ISBN){
                        ok = true;
                    }
                    if (item.Nome == livro.Nome){
                        ok = true;
                    }
                    if (item.Autor == livro.Autor){
                        ok = true;
                    }
                    if (item.Preco == livro.Preco){
                        ok = true;
                    }
                    if (item.DataPublicacao == livro.DataPublicacao){
                        ok = true;
                    }
                    if (ok)
                    {
                        retorno.Add(item);
                    }
                    ok = false;
                }

                return retorno;
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
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
                if (VerificaLivros(livro5)){
                    lstLivros.Add(livro5);
                }

                //lstLivros = livros;

                return lstLivros;


             }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="livro"></param>
            /// <returns></returns>
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ISBN"></param>
            /// <param name="Nome"></param>
            /// <param name="Autor"></param>
            /// <param name="Preco"></param>
            /// <param name="DataPublicacao"></param>
            /// <param name="ImagemdaCapa"></param>
            /// <returns></returns>
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


        }

    }
}
