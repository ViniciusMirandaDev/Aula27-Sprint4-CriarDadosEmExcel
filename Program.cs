using System;

namespace Aula27_Sprint4_CriarDadosEmExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 2;
            p1.Nome = "Gibson";
            p1.Preco = 7500f;
            p1.Cadastrar(p1);


        }
    }
}
