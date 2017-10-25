using System;
using System.IO;

namespace sistema_vendas
{
    public class Vendas
    {
        public static void RealizarVenda(){
            string opcaopfpj = "";

                do{
                    
                    Console.WriteLine("Digite 1 para pessoa física  e 2 para pessoa jurídica");
                    opcaopfpj = Console.ReadLine();
                    if(opcaopfpj != "1" && opcaopfpj != "2"){
                        Console.WriteLine("Opção invalida");
                    }

                }while(opcaopfpj != "1" && opcaopfpj != "2");

                string documento;
                bool documentovalido = false;

                do{
                    if(opcaopfpj == "1"){
                        Console.WriteLine("Digite seu CPF");
                        documento = Console.ReadLine();
                        documentovalido = Validar.ValidarCPF(documento);

                        if(!documentovalido)
                            Console.WriteLine("CPF Inválido");
                    }
                    else{
                        Console.WriteLine("Digite seu CNPJ");
                        documento = Console.ReadLine();

                        documentovalido = Validar.ValidarCNPJ(documento);

                        if(!documentovalido)
                            Console.WriteLine("CNPJ Inválido");
    	            }
                }while(!documentovalido);

                bool clientecadastrado = Cliente.VerificaClienteCadastrado(documento);

                if(!clientecadastrado)
                {
                    Console.WriteLine("Cliente não cadastrado, cadastre um novo cliente");
                    Cliente.CadastrarCliente();
                }

                #region Busca dados Cliente
                    string[] clientes = File.ReadAllLines("clientes.txt");
                    string[] cliente = null;
                    foreach (var item in clientes)
                    {
                        cliente = item.Split(";");
                        if(cliente[0] == documento)
                        {
                            Console.WriteLine("Documento: " + cliente[0]);
                            Console.WriteLine("Nome: " + cliente[1]);
                            Console.WriteLine("Email: " + cliente[2]);
                            break;
                        }
                    }
                #endregion

                #region Lista Produtos
                    string[] produtos = File.ReadAllLines("produtos.txt");
                    string[] produto = null;
                    foreach (var item in produtos)
                    {
                        produto = item.Split(";");
                        Console.WriteLine(produto[0].PadRight(15) + produto[1].PadRight(25) + produto[2].PadRight(35) + produto[3].PadRight(20));
                    }
                #endregion

                string codigoproduto;
                bool produtoencontrado = false;

                do{
                    Console.WriteLine("Digite o código do produto");
                    codigoproduto  = Console.ReadLine();

                    produtoencontrado = Produto.VerificaProdutoCadastrado(codigoproduto);

                    if(!produtoencontrado)
                        Console.WriteLine("Código não encontrado, informe um código válido");

                }while(!produtoencontrado);

                #region Encontra produto
                   foreach (var item in produtos)
                    {
                        produto = item.Split(";");
                        if(produto[0] == codigoproduto){
                            Console.WriteLine("Produto escolhido " + produto[0].PadRight(15) + produto[1].PadRight(25) + produto[2].PadRight(35) + produto[3].PadRight(20));
                            break;
                        }
                        
                    }
                #endregion

                StreamWriter sw = new StreamWriter("vendas.txt", true);
                sw.WriteLine(cliente[0] + ";" + cliente[1] + ";" + produto[0]+ ";" + produto[1]+ ";" + produto[2]+ ";" + produto[3] );
                sw.Close();
        }
    }

}