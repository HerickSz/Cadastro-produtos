using System;
using ClassProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ClassProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Produtos produto = new Produtos();
            string NomeArquivo = produto.RetornaNomeArquivo();

            if (File.Exists(NomeArquivo) == true)
            {
                produto.CarregarXml(NomeArquivo);
            }
            int itemMenu = 0;
            while (itemMenu != 4)
            {
                switch (itemMenu)
                {
                    case 0:
                        Mostrar.Menu();
                        itemMenu = int.Parse(System.Console.ReadLine());
                        break;
                    case 1:
                        Produto prod = Mostrar.CadastrarProduto();

                        produto.AdicionarProduto(prod);
                        Console.Write("Deseja cadastrar outro produto? S (Sim) e N (Não) : ");
                        string NovoProduto = Console.ReadLine();
                        if (NovoProduto == "s" || NovoProduto == "S")
                        {
                            itemMenu = 1;
                        }
                        else
                        {
                            itemMenu = 0;
                        }
                        break;
                    case 2:
                        Mostrar.RemoverProduto(produto);
                        itemMenu = 0;
                        break;
                    case 3:
                        Mostrar.ListaProdutos(produto);
                        itemMenu = 0;
                        break;
                }
            }
            string retorno = produto.GravarProduto();

            if (retorno != "")
            {
                Console.WriteLine(retorno);
                Console.WriteLine("Você está saindo do sistema e seus dados não serão gravados :(");
                Console.ReadLine();
            }
        }
    }
}
