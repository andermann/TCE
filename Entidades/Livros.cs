using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Livros
    {
        //1 public string NomeLivro { get; set; }
        //2 public string TituloLivro { get; set; }
        //3 public string NomedoAutor { get; set; }
        //4 public string AnoEdicao { get; set; }
        public string ISBN { get; set; }            //1
        public string Nome { get; set; }            //2
        public string Autor { get; set; }           //3
        public string Preco { get; set; }           //4
        public string DataPublicacao { get; set; }  //5
        public string ImagemdaCapa { get; set; }    //6
    }
}
