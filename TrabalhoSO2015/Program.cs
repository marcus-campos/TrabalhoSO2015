/*
 * Autores: Marcus Vinicius Campos e Pedro Henrique Lima Pinheiro
 * GitHub: https://github.com/marcus210/TrabalhoSO2015/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoSO2015
{
    class Program
    {
        public static bool debug = false;

        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio();
            string caminho = "";
            ArquivoBLL arquivoBLL = new ArquivoBLL();
            Console.Write("Ativar modo debug (S ou N)?  ");
            if (Console.ReadLine().ToUpper() == "S")
                debug = true;
            else
                debug = false;

            if (debug == false)
            {
                Console.Write("Digite o caminho do arquivo: ");
               
                caminho = Console.ReadLine().Replace(@"/", "//");
                if(caminho == "")
                {
                    Console.WriteLine("Valor incorreto!!!");
                    Console.ReadKey();                    
                }

            }
            else
            {
                caminho = @"C:\Users\Marcus\Desktop\Arquivo.txt";
            }
         
            Console.Write("<Menu> \n\n01: FIFO.\n02: LRU.\n03: Second chance\nOpção: ");
            string valorConsole = Console.ReadLine();
            int opcao = 0;

            if (valorConsole != "")
            {
                opcao = int.Parse(valorConsole);
            }
            else
            {
                Console.WriteLine("Valor incorreto!!!");
                Console.ReadKey();
                Application.Exit();
            }


            switch(opcao)
            {
                case 1:
                    relatorio = arquivoBLL.lerArquivo(caminho,1);
                break;
                case 2:
                    relatorio = arquivoBLL.lerArquivo(caminho, 2);
                break;
                case 3:
                    relatorio = arquivoBLL.lerArquivo(caminho, 3);
                break;
            }

            Console.WriteLine("#------------------RELATORIO------------------#\n");
            Console.WriteLine(relatorio.relatorio());
            Console.ReadKey();
        }
    }
}
