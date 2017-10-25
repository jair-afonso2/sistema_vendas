using System;
using System.IO;

namespace sistema_vendas
{
    public class Log
    {
        public static void GravarErro(string funcao, string erro)
        {
                try
                {
                    Console.WriteLine("Ocorreu um erro - Contacte o Administrador");
                    StreamWriter sr = new StreamWriter("logerro.txt", true);
                    sr.WriteLine(DateTime.Now + " - " + funcao + " - " + erro );
                    sr.Close();
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Ocorreu um erro - Contacte o Administrador");
                }
        }
    }
}