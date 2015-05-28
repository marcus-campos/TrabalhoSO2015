using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO2015
{
    class RelatorioDAL
    {
        private int[] produtos = new int[10];
        private int[] substituido = new int[10];
        
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
    }
}
