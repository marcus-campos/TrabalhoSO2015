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
    }
}
