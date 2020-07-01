using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula27_Sprint4_CriarDadosEmExcel
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH ="Database/produto.csv";

        public Produto()
        {
            if(!File.Exists(PATH))
            {
                Directory.CreateDirectory("Database");
                File.Create(PATH).Close();
            }
        }
        /// <summary>
        /// Cadastrar produtos
        /// </summary>
        /// <param name="prod">Obejeto Produto</param>
        public void Cadastrar(Produto prod)
        {
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Lê o csv
        /// </summary>
        /// <returns>Lista de produtos</returns>
        public List<Produto> Ler()
        { 
            //Criamos uma lista que servirá como nosso retorno
            List<Produto>Produtos = new List<Produto>();

            //Lemos o arquivo e trasformamos em um array de linhas
            //[0]codigo=2;nome=Gibson;preco=7500
            //[1]codigo=3;nome=Fender;preco=4500
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){

                // Separamos os dados de cada linha com split
                // [0]codigo=2
                // [1]nome=Gibson
                // [2]preco=7500
                string[] dado =  linha.Split(";");

                //Criamos instâncias de produtos para serem colocados nas lista
                Produto p   = new Produto();
                p.Codigo    = Int32.Parse ( Separar(dado[0]));
                p.Nome      = ( Separar  (dado[1]));
                p.Preco     = float.Parse ( Separar (dado[2]) );

                Produtos.Add(p);
                
            }

            Produtos = Produtos.OrderBy( y => y.Nome).ToList();

            return Produtos;
        }

        /// <summary>
        /// Remove uma ou mais linhas que contenham o termo
        /// </summary>
        /// <param name="_termo">termo para ser buscado</param>
        public void Remover(string _termo){

            // Criamos uma lista que servirá como uma espécie de backup para as linhas do csv
            List<string> linhas = new List<string>();

            // Utilizamos a biblioteca StreamReader para ler nosso .csv
            //Using serve para não sobrecarregar o sistema(Ele abre e fecha)
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) !=null)
                {
                    linhas.Add(linha);
                }
            }

            // Removemos as linhas que tiverem o termo passado como argumento
            linhas.RemoveAll(l => l.Contains(_termo));

            // Reescrevemos nosso csv do zero
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in linhas)
                {
                    output.Write( ln + "\n");
                }
            }
        }

        /// <summary>
        /// Irá filtrar o nome
        /// </summary>
        /// <param name="_nome">Objeto nome</param>
        /// <returns>Retornará o nome procurado</returns>
        public List<Produto> Filtrar(string _nome){
            return Ler().FindAll(x=> x.Nome == _nome);
        }

        /// <summary>
        /// Separa o csv em colunas
        /// </summary>
        /// <param name="_coluna">Objeto coluna</param>
        /// <returns>Coluna separada</returns>
        private string Separar(string _coluna){
            return _coluna.Split("=")[1];
        }


        //1;Celular;600
        /// <summary>
        /// Prepara a linha no csv
        /// </summary>
        /// <param name="p">Objeto p</param>
        /// <returns>Codigo, nome e preço do produto</returns>
        private string PrepararLinha(Produto p)
        {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}