using System;
using System.IO;

namespace sistema_vendas
{
    public class Produto
    {
        public static void CadastrarProduto(){
            try
            {
                string codigoproduto;
                bool produtovalido;

                do{                   
                    Console.WriteLine("Digite o código do Produto");
                    codigoproduto = Console.ReadLine();
                    
                    produtovalido = VerificaProdutoCadastrado(codigoproduto);

                    if(!produtovalido)
                        Console.WriteLine("Código produto já cadastrado!");

                }while(produtovalido);

                Console.WriteLine("Digite o nome do produto");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite a descrição do produto");
                string descricao = Console.ReadLine();

                Console.WriteLine("Digite o preço do produto");
                decimal preco = Convert.ToDecimal(Console.ReadLine());

                StreamWriter sr = new StreamWriter("produtos.txt", true);
                sr.WriteLine(codigoproduto + ";" + nome + ";" + descricao + ";" + preco);
                sr.Close();

                Console.WriteLine(" Produto " + nome + " cadastrado");
            }
            catch (Exception e)
            {
                Log.GravarErro("CadastrarProduto", e.Message);
            } 
        }

        public static bool VerificaProdutoCadastrado(string codigoProduto){

            try
            {
                //Verifica se arquivo existe, caso não exista produto não cadastrado
                if (!File.Exists("produtos.txt"))
                {
                    return false;
                }

                //Caso arquivo exista obtem todos os produtos do arquivo
                string[] produtos = File.ReadAllLines("produtos.txt");
                string[] arrayproduto;
                //percorre o array de produtos
                foreach (var produto in produtos)
                {
                    //Split cria um array e atribui o mesmo a váriavel arrayproduto
                    arrayproduto = produto.Split(";");
                    //verifica se o produto já foi cadastrado
                    if (arrayproduto[0] == codigoProduto)
                    {
                        return true;
                        break;
                    }
                }

                return false;
            }
            catch (System.Exception e)
            {
                Log.GravarErro("VerificaProdutoCadastrado",e.Message );
                throw;
            }
        }

    }

}