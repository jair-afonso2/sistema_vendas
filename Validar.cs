using System;
using System.IO;

namespace sistema_vendas
{
    public class Validar
    {
        public static bool ValidarCPF(string cpf)
        {
            //Retira os pontos e traços
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            //Verifica se tem 11 digitos o parametro passado, caso não tenha retorna falso
            if (cpf.Length != 11)
            {
                return false;
            }

            //Verifica se o cpf digitado não possui a sequência de números informada
            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222"
             || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555"
             || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
            {
                return false;
            }

            //cria um array de int para validar o primeiro digito
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            //cria um array de int para validar o segundo digito
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };


            string tempCpf, digito;
            int soma = 0, resto = 0;

            //armazena na váriavel tempCpf os 9 primeiros digitos do cpf passado como parametro
            tempCpf = cpf.Substring(0, 9);

            //percorre o array multiplicando os digitos do cpf com a posição do array e soma
            for (int i = 0; i < 9; i++)
            {
                soma += Convert.ToInt16(tempCpf[i].ToString()) * multiplicador1[i];
            }

            //armazena o resto da divisão da soma por 11
            resto = soma % 11;

            //Caso o resto seja menor que 2 atribui 0, caso contrário atribui 11 - resto para obter primeiro número
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            //atribui a digito o resto
            digito = resto.ToString();
            //concatena o tempCpf com o digito
            tempCpf = tempCpf + digito;

            soma = 0;
            //Percorre o tempcpf contatenado e multiplica pelos valores do array
            for (int i = 0; i < 10; i++)
            {
                soma += Convert.ToInt16(tempCpf[i].ToString()) * multiplicador2[i];
            }

            //armazena o resto da divisão da soma por 11
            resto = soma % 11;

            //concatena o tempCpf com o digito
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            //Verifica se os ultimos 2 digitos obtidos são iguais aos do cpf passado
            return cpf.EndsWith(digito);
        }

        //CNPJ ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public static bool ValidarCNPJ(string cnpj)
        {
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj, digito;
            int soma = 0, resto = 0;

            tempCnpj = cnpj.Substring(0, 12);

            for (int i = 0; i < 12; i++)
            {
                soma += Convert.ToInt16(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;

            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += Convert.ToInt16(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            return cnpj.EndsWith(digito);
        }

    }
}