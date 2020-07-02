using System.Collections.Generic;

namespace Aula27_Sprint4_CriarDadosEmExcel
{
    public interface IProduto
    {
        void Cadastrar(Produto prod);
        List<Produto> Ler();
        void Alterar(Produto _produtoAlterado);
        void Remover(string _termo);
         

    }
}