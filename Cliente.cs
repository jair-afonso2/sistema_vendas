using System;
using System.IO;

namespace sistema_vendas
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public static void CadastrarCliente()
        {
            try
            {
                Console.WriteLine("Digite o nome do cliente");
                string Nome = Console.ReadLine();

                Console.WriteLine("Digite o email do cliente");
                string Email = Console.ReadLine();

                string opcaopfpj = "";

                do
                {

                    Console.WriteLine("Digite 1 para pessoa física  e 2 para pessoa jurídica");
                    opcaopfpj = Console.ReadLine();
                    if (opcaopfpj != "1" && opcaopfpj != "2")
                    {
                        Console.WriteLine("Opção invalida");
                    }

                } while (opcaopfpj != "1" && opcaopfpj != "2");

                string documento;
                bool documentovalido = false;

                do
                {
                    if (opcaopfpj == "1")
                    {
                        Console.WriteLine("Digite seu CPF");
                        documento = Console.ReadLine();
                        documentovalido = Validar.ValidarCPF(documento);

                        if (!documentovalido)
                            Console.WriteLine("CPF Inválido");
                    }
                    else
                    {
                        Console.WriteLine("Digite seu CNPJ");
                        documento = Console.ReadLine();

                        documentovalido = Validar.ValidarCNPJ(documento);

                        if (!documentovalido)
                            Console.WriteLine("CNPJ Inválido");
                    }
                } while (!documentovalido);

                StreamWriter sr = new StreamWriter("clientes.txt", true);
                sr.WriteLine(documento + ";" + Nome + ";" + Email);
                sr.Close();

                Console.WriteLine(" Cliente " + Nome + " cadastrado");
            }

            catch (Exception e)
            {
                Log.GravarErro("CadastrarCliente", e.Message);
            }

        }

        public static bool VerificaClienteCadastrado(string documento)
        {

            try
            {
                if (!File.Exists("clientes.txt"))
                {
                    return false;
                }

                string[] produtos = File.ReadAllLines("clientes.txt");
                string[] arrayproduto;
                foreach (var produto in produtos)
                {
                    arrayproduto = produto.Split(";");
                    if (arrayproduto[0] == documento)
                    {
                        return true;
                        break;
                    }
                }

                return false;
            }
            catch (System.Exception e)
            {
                Log.GravarErro("VerificaClienteCadastrado", e.Message);
                throw;
            }
        }

        public static void ExtratoCliente()
        {
            String opcaopfpj = "";

            do
            {

                Console.WriteLine("Digite 1 para pessoa física  e 2 para pessoa jurídica");
                opcaopfpj = Console.ReadLine();
                if (opcaopfpj != "1" && opcaopfpj != "2")
                {
                    Console.WriteLine("Opção invalida");
                }

            } while (opcaopfpj != "1" && opcaopfpj != "2");

            string documento;
            bool documentovalido = false;

            do
            {
                if (opcaopfpj == "1")
                {
                    Console.WriteLine("Digite seu CPF");
                    documento = Console.ReadLine();
                    documentovalido = Validar.ValidarCPF(documento);

                    if (!documentovalido)
                        Console.WriteLine("CPF Inválido");
                }
                else
                {
                    Console.WriteLine("Digite seu CNPJ");
                    documento = Console.ReadLine();

                    documentovalido = Validar.ValidarCNPJ(documento);

                    if (!documentovalido)
                        Console.WriteLine("CNPJ Inválido");
                }
            } while (!documentovalido);

            if (!File.Exists("vendas.txt"))
            {
                Console.WriteLine("Não foram efetuadas vendas!!!");
            }
            else
            {
                string[] vendas = File.ReadAllLines("vendas.txt");
                string[] arrayvenda;
                foreach (var produto in vendas)
                {
                    arrayvenda = produto.Split(";");
                    if (arrayvenda[0] == documento)
                    {
                        Console.WriteLine(arrayvenda[0].PadRight(15) + arrayvenda[1].PadRight(15) + arrayvenda[2].PadRight(25) + arrayvenda[4].PadRight(25));
                    }
                }
            }


        }
    }
}
