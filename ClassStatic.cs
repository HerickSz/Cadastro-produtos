using System;
using ClassProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace ClassProdutos
{

    class Mostrar
    {

        public static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|---------------------------------------------------------------------------------|");
            Console.WriteLine("|                                                                                 |");
            Console.WriteLine("|                                   MENU PRODUTOS                                 |");
            Console.WriteLine("|                                                                                 |");
            Console.WriteLine("|---------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|1 - Cadastrar Produto                                                            |");
            Console.WriteLine("|2 - Remover Produto                                                              |");
            Console.WriteLine("|3 - Listar Produtos                                                              |");
            Console.WriteLine("|4 - Sair                                                                         |");
            Console.WriteLine("|---------------------------------------------------------------------------------|");
        }
        public static Produto CadastrarProduto()
        {


            Console.Clear();
            Produto products = new Produto();
            Console.WriteLine("|---------------------------------------------------------------------------------|");
            Console.WriteLine("|                                                                                 |");
            Console.WriteLine("|                                CADASTRO DE PRODUTO                              |");
            Console.WriteLine("|                                                                                 |");
            Console.WriteLine("|---------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nInforme o Código: \t");
            products.pCodigo = int.Parse(Console.ReadLine());
            Console.Write("\nInfome o Nome: \t");
            products.pNome = Console.ReadLine();
            Console.Write("\nInforme o Custo: R$\t");
            products.pCusto = double.Parse(Console.ReadLine());
            Console.Write("\nInforme a Venda: R$\t");
            products.pVenda = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nProduto Adicionado!\n");

            return products;
        }
        public static void RemoverProduto(Produtos p)
        {
            Console.Clear();
            int i = 0;
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                                                                        |");
            Console.WriteLine("|                                REMOVER PRODUTO                                         |");
            Console.WriteLine("|                                                                                        |");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("|      Nome          |        Codigo       |        Custo        |        Venda           ");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            foreach (Produto prod in p.ProdutosLista)
            {
                Console.WriteLine(prod.ToString());
                i++;
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
            }
            if (i >= 1)
            {
                Console.WriteLine("\nDigite o codigo do produto que deseja remover: ");
                int CodigoRemover = int.Parse(Console.ReadLine());
                int RetornoRemover = p.RemoverProduto(CodigoRemover);
                if (RetornoRemover > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    p.ProdutosLista.RemoveAt(RetornoRemover - 1);
                    Console.WriteLine("Produto removido com sucesso");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCodigo não encontrado");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNenhum Produto encontrado");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aperte qualquer TECLA para voltar");
            Console.ReadLine();

        }
        public static void ListaProdutos(Produtos p)
        {
            Console.Clear();
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                                                                        |");
            Console.WriteLine("|                                LISTAR  PRODUTO                                         |");
            Console.WriteLine("|                                                                                        |");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("|      Nome          |        Codigo       |        Custo        |        Venda           ");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            foreach (Produto prod in p.ProdutosLista)
            {
                Console.WriteLine(prod.ToString());
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aperte qualquer TECLA para voltar");
            Console.ReadLine();
        }
    }
}