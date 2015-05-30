/*
 * Autores: Marcus Vinicius Campos e Pedro Henrique Lima Pinheiro
 * GitHub: https://github.com/marcus210/TrabalhoSO2015/
 */
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
        int[] filaImaginaria;
        ArquivoDAL arquivoDAL = new ArquivoDAL();
        Relatorio relatorioDAL;
        int posV = 0;
        int cont = 0;
        int[] bitAssoc;
        bool execF = false;
        int dotCont = 0;
       

        public Relatorio LerArquivo(string caminho, int algoritimo)
        {
            StreamReader strR = new StreamReader(caminho);
            relatorioDAL = new Relatorio();

            string texto = "";
            string txtLine = null;
            
            do
            {
                txtLine = strR.ReadLine();     
                switch(algoritimo)
                {
                    case 1:
                        Fifo(txtLine, cont);
                        break;
                    case 2:
                        LRU(txtLine, cont);
                        break;
                    case 3:
                        SC(txtLine, cont);
                        break;
                    default:
                        break;
                }

                
                texto += txtLine;
                cont++;
            }
            while (txtLine != null);
            relatorioDAL.NumTotalCaracteres += texto.Length;
            return relatorioDAL;
        }

        public void Fifo(string linha, int pos) //First IN first OUT
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
                                if (prateleira[posV] != null)
                                 relatorioDAL.Substituido[posV]++;

                                prateleira[posV] = valorAtual;
                                relatorioDAL.Produtos[valorAtual]++;
                                relatorioDAL.Falta++;

                                if (posV + 1 == prateleira.Length) //Verifica se chegou ao final da fila
                                {
                                    posV = 0; //Volta ao inicio da fila, ou seja, no primeiro que entrou
                                    continue; //Pula a proxima etapa e reinicia o foreach
                                }                               
                                posV++;//Muda o seletor para o proximo da fila
                            }
                            else
                            {
                                relatorioDAL.Produtos[valorAtual]++;                               
                            }
                        }
                    }
            
        }      

        public void LRU(string linha, int pos)
        {
            if (pos == 0)//Verifica se e a primeira linha
            {
                prateleira = new int[int.Parse(linha)]; //Adiciona o tamanho da prateleira
                filaImaginaria = new int[int.Parse(linha)];//Adiciona o mesmo tamanho da prateleira no vetor imaginario
                //relatorioDAL.Falta = int.Parse(linha);
            }
            else
                if (linha != null) //Verifica se a linha nao esta vazia
                    foreach (char c in linha.ToCharArray()) //Estrutura para percorrer caractere por caractere da linha
                    {
                        bool existe = false; //Variavel para verificacoes futuras se existe o elemento que sera adicionado a prateleira
                        int valorAtual; //Valor do caractere atual

                        if (prateleira != null && Program.debug == true) //Mostra os LOGS
                        {
                            uiFila(pos, posV);
                            iuiFila(pos, posV);
                        }


                        if (c != char.Parse(".")) //Verifica se o caractere atual nao e um ponto
                        {
                            valorAtual = int.Parse(c.ToString());

                            for (int z = 0; z < prateleira.Length; z++)//Percorre todo o vetor prateleira e verifica se o valor ja existe
                            {
                                if (prateleira[z] == int.Parse(c.ToString())) //Se o valor da prateleira na posicao Z for igual ao caractere atual
                                {
                                    existe = true; //Muda o valor da variavel existe para true
                                }                                
                            }


                            if (existe == false) //Se o caractere atual nao existir na prateleira
                            {
                                if (prateleira[posV] != null)
                                    relatorioDAL.Substituido[posV]++; //Contabiliza os produtos substituidos

                                //prateleira[posV] = valorAtual;
                                for (int v = 0; v < prateleira.Length; v++)//Percorre todo o vetor prateleira e verifica se o valor ja existe
                                {
                                    int[] copiaFila = new int[prateleira.Length];
                                    filaImaginaria.CopyTo(copiaFila, 0); //Clona a fila imaginaria

                                    if (prateleira[v] == filaImaginaria[(prateleira.Length - 1)]) //Se o valor da prateleira na posicao atual for igual ao valor que devera sair da fila imaginaria
                                    {
                                        prateleira[v] = valorAtual;//Adicina o caractere atual a prateleira                      
               
                                        filaImaginaria[0] = int.Parse(c.ToString()); //Adiciona o caractere ao primeiro da fila
                                      
                                        for(int n = 0; n < (filaImaginaria.Length - 1); n++) //Realoca todos o restante da fila
                                        {                                            
                                            filaImaginaria[n + 1] = copiaFila[n];
                                        }
                                        break;
                                    }
                                   
                                }

                                relatorioDAL.Produtos[valorAtual]++;
                                relatorioDAL.Falta++;
                                
                                if (posV + 1 == prateleira.Length) //Verifica se chegou ao final da fila
                                {
                                    posV = 0; //Volta ao inicio da fila, ou seja, no primeiro que entrou
                                    continue; //Pula a proxima etapa e reinicia o foreach
                                }
                                posV++;//Muda o seletor para o proximo da fila
                            }
                            else
                            {
                                relatorioDAL.Produtos[valorAtual]++;
                            }
                        }
                    }
        }

        public void SC(string linha, int pos)
        {
            if (pos == 0)//Verifica se e a primeira linha
            {
                prateleira = new int[int.Parse(linha)]; //Adiciona o tamanho da prateleira
                filaImaginaria = new int[int.Parse(linha)];//Adiciona o mesmo tamanho da prateleira no vetor imaginario
                //relatorioDAL.Falta = int.Parse(linha);
            }
            else
                if (linha != null) //Verifica se a linha nao esta vazia
                    foreach (char c in linha.ToCharArray()) //Estrutura para percorrer caractere por caractere da linha
                    {
                        bool existe = false; //Variavel para verificacoes futuras se existe o elemento que sera adicionado a prateleira
                        int valorAtual; //Valor do caractere atual

                        if (prateleira != null && Program.debug == true) //Mostra os LOGS
                        {
                            uiFila(pos, posV);
                            iuiFila(pos, posV);
                        }
                        
                        if (c != char.Parse(".")) //Verifica se o caractere atual nao e um ponto
                        {
                            valorAtual = int.Parse(c.ToString());

                            for (int z = 0; z < prateleira.Length; z++)//Percorre todo o vetor prateleira e verifica se o valor ja existe
                            {
                                if (prateleira[z] == int.Parse(c.ToString())) //Se o valor da prateleira na posicao Z for igual ao caractere atual
                                {
                                    existe = true; //Muda o valor da variavel existe para true
                                }
                            }
                            
                            if (existe == false) //Se o caractere atual nao existir na prateleira
                            {
                                if (prateleira[posV] != null)
                                    relatorioDAL.Substituido[posV]++; //Contabiliza os produtos substituidos
                                
                                int[] copiaFila = new int[prateleira.Length];
                                filaImaginaria.CopyTo(copiaFila, 0); //Clona a fila imaginaria

                                if(prateleira[posV] == valorAtual && filaImaginaria[posV] == 0)
                                {
                                    filaImaginaria[posV] = 1;  
                                }

                                if (filaImaginaria[posV] == 0) //Se o valor da prateleira na posicao atual for igual ao valor que devera sair da fila imaginaria
                                {
                                    prateleira[posV] = valorAtual;//Adicina o caractere atual a prateleira                      
                                    filaImaginaria[posV] = 1;                                   
                                }
                                else
                                {
                                    filaImaginaria[posV] = 0;      
                                }
                                
                                relatorioDAL.Produtos[valorAtual]++;
                                relatorioDAL.Falta++;

                                if (posV + 1 == prateleira.Length) //Verifica se chegou ao final da fila
                                {
                                    posV = 0; //Volta ao inicio da fila, ou seja, no primeiro que entrou
                                    if (execF == false)
                                    {
                                        for (int t = 0; t < filaImaginaria.Length; t++)
                                        {
                                            filaImaginaria[t] = 0;
                                        }
                                        execF = true;
                                    }
                                        continue; //Pula a proxima etapa e reinicia o foreach
                                }
                                posV++;//Muda o seletor para o proximo da fila
                            }
                            else
                            {
                                relatorioDAL.Produtos[valorAtual]++;
                            }
                        }
                        else
                        {
                            dotCont++;
                        }
                        
                    }

        }

        public void uiFila(int pos, int posV) //Prateleira
        {            
            string visualFila = "";
            for(int i = 0; i < prateleira.Length; i++)
            {                
                if(posV != i)                    
                    visualFila += "[ "+prateleira[i]+" ] ";
                else
                    visualFila += "{[" + prateleira[i] + "]} ";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Linha: " +pos+ " ciclo " + (posV + 1) + ": " + visualFila);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void iuiFila(int pos, int posV) //Fila Imaginaria
        {
            string visualFila = "";
            for (int i = 0; i < filaImaginaria.Length; i++)
            {            
                 visualFila += "[ " + filaImaginaria[i] + " ] ";                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Linha: " + pos + " ciclo " + (posV + 1) + ": " + visualFila);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}