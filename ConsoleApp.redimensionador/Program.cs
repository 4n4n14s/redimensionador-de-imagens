using System;
using System.Drawing;
using System.IO;
using System.Threading;


namespace ConsoleApp.redimensionador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("iniciando redimensionador ");
            Thread Th = new(Redimensionar);
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
            FileStream fileStream;
            FileInfo fileInfo;


            while (true)
            {
                //meu programa irá olhar para a pasta de entrada
                //se tiver arquivo, ele irá redimensionar
                var arquivosEntrada = Directory.EnumerateFiles(diretorio_entrada);

                //ler o tamanho que ira redimensionar
                int novaAltura = 200;

                foreach (var arquivo in arquivosEntrada)
                {
                    Console.WriteLine(arquivo);

                    fileStream  = new(arquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    fileInfo  = new(arquivo);


                    string caminho = Environment.CurrentDirectory +@"\" + diretorio_redimensionado 
                        + @"\" + fileInfo.Name + DateTime.Now.Millisecond.ToString() + "_"+ fileInfo.Name;
                    //redimenciona

                    Redimensionador(Image.FromStream(fileStream), novaAltura, caminho);


                    //fecha o arquivo
                    fileStream.Close();





                    //move o arquivo de entrada para a pasta de finalizados 
                    string caminhoFinalizado = Environment.CurrentDirectory + @"\" + diretorio_finalizado + @"\" + fileInfo.Name;
                    fileInfo.MoveTo(caminhoFinalizado);


                    

                }
                Thread.Sleep(new TimeSpan(0, 0, 5));
            }

            
           
            static void Redimensionador(Image imagem, int altura, string caminho)
            {

                double ratio = (double)altura / imagem.Height;
                int novaLargura = (int)(imagem.Width * ratio);
                int novaAltura = (int)(imagem.Height * ratio);

                Bitmap novaImage = new(novaLargura, novaAltura);

                using (Graphics g = Graphics.FromImage(novaImage))
                {
                    g.DrawImage(imagem, 0, 0, novaLargura, novaAltura );
                }
                novaImage.Save(caminho);
                imagem.Dispose();
            }

        }
    }
}
