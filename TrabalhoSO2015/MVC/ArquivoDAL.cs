/*
 * Autores: Marcus Vinicius Campos e Pedro Henrique Lima Pinheiro
 * GitHub: https://github.com/marcus210/TrabalhoSO2015/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO2015
{
    class ArquivoDAL
    {
        private string[] produto = new string[10];

        public string[] Produto
        {
            get { return produto; }
            set { produto = value; }
        }

         public ArquivoDAL()
         {
             produto[0] = "PAPEL";
             produto[1] = "BISCOITO";
             produto[2] = "ISOTONICO";
             produto[3] = "PIZZA";
             produto[4] = "REFRIGERANTE";
             produto[5] = "CAFE";
             produto[6] = "SHAMPOO";
             produto[7] = "CHOCOLATE";
             produto[8] = "ARROZ";
             produto[9] = "DORITOS";
         }
    }
}
