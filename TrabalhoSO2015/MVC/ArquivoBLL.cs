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
    class ArquivoBLL
    {
        public Relatorio lerArquivo(string caminho, int algoritimo)
        {
            ArquivoDAO arquivoDAO = new ArquivoDAO();
            //return null;
            return arquivoDAO.LerArquivo(caminho, algoritimo);
        }        
    }
}
