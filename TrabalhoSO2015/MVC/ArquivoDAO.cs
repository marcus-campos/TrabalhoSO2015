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
        Relatorio relatorioDAL;

        public Relatorio LerArquivo(string caminho)
        {
            StreamReader strR = new StreamReader(caminho);
            relatorioDAL = new Relatorio();

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
            bool existe = false;

            if(pos == 0)
                prateleira = new int [int.Parse(linha)];
            else
                if(linha != null)
                foreach(char c in linha.ToCharArray())
                {
                   

                    if (prateleira != null && Program.debug == true)
                        uiFila(pos,posV);
                    if(c != char.Parse("."))
                    {
                        for (int z = 0; z < prateleira.Length; z++)//Percorre todo o vetor prateleira e verifica se o valor ja existe
                        {
                            if (prateleira[z] == c)
                            {
                                existe = true;
                            }
                        }

                        if (existe == false)
                        {
                            if (prateleira[posV] != null)
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
            
        }

        public void uiFila(int pos, int posV)
        {
            string visualFila = "";
            for(int i = 0; i < prateleira.Length; i++)
            {
                visualFila += "[ "+prateleira[i]+" ] ";
            }
            Console.WriteLine("Linha: " +pos+ " ciclo " + (posV + 1) + ": " + visualFila);
        }
    }
}