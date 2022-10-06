using System;
using ClassProdutos.entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace ClassProdutos.entities
{
    public class Produtos
    {
        public List<Produto> ProdutosLista { get; set; }
        public void AdicionarProduto(Produto p)

        {
            ProdutosLista.Add(p);
        }
        public int RemoverProduto(int CodigoRemover)
        {
            string NomeArquivo = RetornaNomeArquivo();
            string xml = File.ReadAllText(NomeArquivo);
            int ContaProduto = 1;
            string TagProd = "Prod" + ContaProduto;
            string TagProduto = LerTag(TagProd, xml);
            int IndexCodigo = 0;

            while (TagProduto != "")
            {
                Produto prod = new Produto();
                prod.pCodigo = int.Parse(LerTag("Codigo", TagProduto));
                if (prod.pCodigo == CodigoRemover)
                {
                    IndexCodigo = ContaProduto;
                }
                ContaProduto++;
                TagProd = "Prod" + ContaProduto;
                TagProduto = LerTag(TagProd, xml);
            }
            return IndexCodigo;
        }
        public Produtos()
        {
            ProdutosLista = new List<Produto>();
        }
        public string RetornaNomeArquivo()
        {
            string NomeArquivo = "dados";
            string Diretorio = Directory.GetCurrentDirectory();

            string ArquivoComCaminho = Diretorio + @"\" + NomeArquivo + ".xml";
            return ArquivoComCaminho;
        }
        public string GravarProduto()
        {
            string NomeArquivo = RetornaNomeArquivo();

            if (File.Exists(NomeArquivo) == true)
            {
                File.Delete(NomeArquivo);
            }

            StreamWriter sw = new StreamWriter(NomeArquivo);
            sw.WriteLine("<XML>");
            sw.WriteLine("    <Produtos>");

            int contaproduto = 1;

            foreach (Produto prod in ProdutosLista)
            {
                sw.WriteLine("        <Prod" + contaproduto + ">");
                sw.WriteLine("            <Nome>" + prod.pNome + "</Nome>");
                sw.WriteLine("            <Codigo>" + prod.pCodigo + "</Codigo>");
                sw.WriteLine("            <Custo>" + prod.pCusto.ToString("F2") + "</Custo>");
                sw.WriteLine("            <Venda>" + prod.pVenda.ToString("F2") + "</Venda>");
                sw.WriteLine("        </Prod" + contaproduto + ">");
                contaproduto++;
            }
            sw.WriteLine("    </Produtos>");
            sw.WriteLine("</XML>");
            sw.Close();
            return "";
        }
        public void CarregarXml(string xmls)
        {
            string xml = File.ReadAllText(xmls);
            int ContaProduto = 1;
            string TagProd = "Prod" + ContaProduto;
            string TagProduto = LerTag(TagProd, xml);

            while (TagProduto != "")
            {
                Produto products = new Produto();
                products.pNome = LerTag("Nome", TagProduto);
                products.pCodigo = int.Parse(LerTag("Codigo", TagProduto));
                products.pCusto = double.Parse(LerTag("Custo", TagProduto));
                products.pVenda = double.Parse(LerTag("Venda", TagProduto));

                AdicionarProduto(products);

                ContaProduto++;
                TagProd = "Prod" + ContaProduto;
                TagProduto = LerTag(TagProd, xml);
            }
        }
        private string LerTag(string Tag, string xml)
        {
            int piTag = xml.IndexOf(Tag);
            int pfTag = xml.IndexOf("/" + Tag);
            piTag += Tag.Length + 1;
            pfTag = pfTag - 1;
            int comprimento = pfTag - piTag;
            string retorno = "";
            if (comprimento > 0)
            {
                retorno = xml.Substring(piTag, comprimento);
            }
            else
            {
                retorno = "";
            }
            return retorno;
        }

    }
}