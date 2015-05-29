using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO2015
{
    class Program
    {
        public static bool debug = true;

        static void Main(string[] args)
        {
            Relatorio relatorio = new Relatorio();
            string caminho = @"C:\Users\Marcus\Desktop\Arquivo.txt";
            ArquivoBLL arquivoBLL = new ArquivoBLL();

            //Console.Write("Digite o caminho do arquivo: ");
            //caminho = Console.ReadLine().Replace(@"/", "//");
            

            Console.Write("<Menu> \n\n01: FIFO.\nOpção: ");
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                        relatorio = arquivoBLL.lerArquivo(caminho);
                break;
            }

            Console.WriteLine("#------------------RELATORIO------------------#\n");
            Console.WriteLine(relatorio.relatorio());
            Console.ReadKey();
        }

      

      
    }
}
