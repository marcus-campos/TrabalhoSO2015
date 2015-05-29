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
        ArquivoDAL arquivoDAL = new ArquivoDAL();
        Relatorio relatorioDAL;
        int posV = 0;
        int cont = 0;

        

        public Relatorio LerArquivo(string caminho)
        {
            StreamReader strR = new StreamReader(caminho);
            relatorioDAL = new Relatorio();

            string texto = "";
            string txtLine = null;
            
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
            
            

            if (pos == 0)
            {
                prateleira = new int[int.Parse(linha)];
                //relatorioDAL.Falta = int.Parse(linha);
            }
            else
                if (linha != null)
                    foreach (char c in linha.ToCharArray())
                    {
                        bool existe = false;
                        int valorAtual;
                        if (prateleira != null && Program.debug == true)
                            uiFila(pos, posV);
                        

                        if (c != char.Parse("."))
                        {
                            valorAtual = int.Parse(c.ToString());


                            for (int z = 0; z < prateleira.Length; z++)//Percorre todo o vetor prateleira e verifica se o valor ja existe
                            {
                                if (prateleira[z] == int.Parse(c.ToString()))
                                {
                                    existe = true;
                                }
                            }

                            
                            if (existe == false)
                            {
                                //if (prateleira[posV] != null)
                                // relatorioDAL.Substituido[posV]++;

                                prateleira[posV] = valorAtual;
                                relatorioDAL.Produtos[valorAtual]++;

                                if (posV + 1 == prateleira.Length)
                                {
                                    posV = 0;
                                    continue;
                                }
                                relatorioDAL.Falta++;
                                posV++;
                            }
                            else
                            {
                                relatorioDAL.Produtos[valorAtual]++;                               
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