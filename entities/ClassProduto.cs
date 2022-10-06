using System;
using System.Globalization;
namespace ClassProdutos.entities
{
    public class Produto
    {
        public string pNome { get; set; }
        public int pCodigo { get; set; }
        public double pCusto { get; set; }
        public double pVenda { get; set; }



        public override string ToString()   // to string de formatar os atributos 
        {
            return String.Format("{0,10}{1,25}{2,25}{3,23}", pNome, pCodigo, pCusto.ToString("F2", CultureInfo.InvariantCulture), pVenda.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}