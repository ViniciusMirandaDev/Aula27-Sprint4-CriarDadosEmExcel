using System;
using System.Collections.Generic;

namespace Aula27_Sprint4_CriarDadosEmExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 5;
            p1.Nome = "Tagima";
            p1.Preco = 5500f;
            
            p1.Cadastrar(p1);
            p1.Remover("Tagima");

            List<Produto> lista = lista = p1.Ler();
            
            

            foreach( Produto item in lista)
            {
                System.Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }
            

        }
    }
}
