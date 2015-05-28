using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO2015
{
    class ArquivoDAO
    {
        int[] prateleira;
        RelatorioDAL relatorioDAL;

        public RelatorioDAL LerArquivo(string caminho)
        {
            StreamReader strR = new StreamReader(caminho);
            relatorioDAL = new RelatorioDAL();

            string texto = "";
            string txtLine = null;
            int cont = 0;
            do
            {
                txtLine = strR.ReadLine();               
                Fifo(txtLine, cont);
                texto += txtLine;
                cont++;
            }
            while (txtLine != null);           

            return relatorioDAL;
        }

        public void Fifo(string linha, int pos)
        {
            int posV = 0;        

            if(pos == 0)
                prateleira = new int [int.Parse(linha)];
            else
                if(linha != null)
                foreach(char c in linha.ToCharArray())
                {
                    if (prateleira != null)
                        uiFila(posV);
                    if(c != char.Parse("."))
                    {
                        if(prateleira[posV] != null)
                             relatorioDAL.Substituido[posV] = prateleira[posV];

                        prateleira[posV] = int.Parse(c.ToString());
                        relatorioDAL.Produtos[posV]++;
                        
                        if (posV + 1 == prateleira.Length)
                        {
                            posV = 0;
                            continue;
                        }

                        posV++;
                    }                    
                }
            
        }

        public void uiFila(int pos)
        {
            string visualFila = "";
            for(int i = 0; i < prateleira.Length; i++)
            {
                visualFila += "[ "+prateleira[i]+" ] ";
            }
            Console.WriteLine("Ciclo "+ pos + ": " + visualFila);
        }
    }
}