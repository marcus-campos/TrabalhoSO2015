using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO2015
{
    class Relatorio
    {
        private int[] produtos = new int[10];
        private int[] substituido = new int[10];
        private int maisVendido = 0;
        private int menosVendido = 0;
        private int falta = 0;
        
        #region Encapsuladores
        public int[] Produtos
        {
            get { return produtos; }
            set { produtos = value; }
        }

        public int[] Substituido
        {
            get { return substituido; }
            set { substituido = value; }
        }

        public int Mais_vendido
        {
            get { return maisVendido; }
            set { maisVendido = value; }
        }

        public int Menos_vendido
        {
            get { return menosVendido; }
            set { menosVendido = value; }
        }

        public int Falta
        {
            get { return falta; }
            set { falta = value; }
        }
        #endregion


        public void mmVendidos()
        {

            for (int x = 0; x < 10; x++)
            {               
                if (produtos[x] == produtos.Max()) //Verifica o maior valor
                    maisVendido = x;

                if (produtos[x] == produtos.Min()) //Verifica o menor valor
                    menosVendido = x;
            }
        }

        public string relatorio()
        {
            ArquivoDAL arquivoDAL = new ArquivoDAL();
            string relatorio = "";
            int totalSubstituidos = 0;
            mmVendidos();

            relatorio += "Produto mais vendido com " + produtos.Max() +" vendas:" + arquivoDAL.Produto[maisVendido] + "\n";
            relatorio += "Produto menos vendido com " + produtos.Min() +" vendas:"+ arquivoDAL.Produto[menosVendido] + "\n";
            relatorio += "Faltas de produtos na prateleira:" + falta + "\n";
            relatorio += "\nNumero de vezes que cada Produto foi substitudo:\n";

            for (int x = 0; x < 10; x++)
            {
                totalSubstituidos += substituido[x];
                relatorio += "   Produto " + arquivoDAL.Produto[x] + ": " + substituido[x] + "\n";                
            }
            relatorio += "Total: " +totalSubstituidos;

            if(Program.debug == true)
            {
                relatorio += "\n\nVenda por produto:\n";

                for (int x = 0; x < 10; x++)
                {                   
                    relatorio += "   Produto " + arquivoDAL.Produto[x] + ": " + produtos[x]  + "\n";                    
                }
                relatorio += "Total: " + produtos.Sum();
            }

            relatorio += "\n\nMedia de vendas de cada produto:\n";

            for (int x = 0; x < 10; x++)
            {
                if(produtos[x] > 0)
                    relatorio += "   Produto " + arquivoDAL.Produto[x] + ": " + produtos[x] / 2.000 + "\n";
                else
                    relatorio += "   Produto " + arquivoDAL.Produto[x] + ": " + produtos[x] + "\n";
            }
            relatorio += "Total: " + produtos.Sum();

            return relatorio;
        }
    }
}
