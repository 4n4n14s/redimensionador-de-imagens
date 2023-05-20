using System;
using System.IO;
using System.Threading;

namespace ConsoleApp.redimensionador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("iniciando redimensionador ");
            Thread Th = new Thread(Redimensionar);
            Th.Start();
           
        }
        static void Redimensionar()
        {
            #region diretorios

            string diretorio_entrada = "Arquivo_Entrada";
            string diretorio_finalizado = "Arquivo_finalizado";
            string diretorio_redimensionado = "Arquivo_redimensionado";
            
            if (!Directory.Exists(diretorio_entrada))
            {
                Directory.CreateDirectory(diretorio_entrada);
            }
            if (!Directory.Exists(diretorio_redimensionado))
            {
                Directory.CreateDirectory(diretorio_redimensionado);
            }
            if (!Directory.Exists(diretorio_finalizado))
            {
                Directory.CreateDirectory(diretorio_finalizado);
            }
            #endregion

            while (true)
            {
                //meu programa irá olhar para a pasta de entrada
                //se tiver arquivo, ele irá redimensionar

                //ler o tamanho que ira redimensionar


                //redimenciona

                //copia o arquivos redimencionado para a pasta redimencionado

                //move o arquivo de entrada para a pasta de finalizados 


                Thread.Sleep(new TimeSpan(0, 0, 3));
            }

        }
    }
}
