using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Livraria 
    {

        public string LivrosOrdenacao(List<Livros> livros, string regra)
        {

            var objLivros = new LivrosOrdenacao();
            return objLivros.RetornaListaLivrosOrdenado(livros, regra);

        }

    }
}
