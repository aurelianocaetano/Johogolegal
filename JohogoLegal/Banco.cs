using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{


    internal class Banco
    {
        public int saldo;

        public Banco()
        {
            saldo = 100; // Inicializa o saldo do banco
        }

        public void Adicionar(int valor)
        {
            saldo += valor;  // Soma o valor ao saldo
        }

        public void Subtrair(int valor) // Função para subtrair um valor do saldo
        {
            saldo -= valor;                                                          

            if (saldo < 0)
            {
                saldo = 0; // Garante que o saldo não fique negativo
            }
        }

        public int ObterSaldo() // Função para obter o saldo atual do banco
        {
            return saldo;


        }

        public void ExibirSaldo() // Função para exibir o saldo na tela
        {

            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Yellow; // Atualiza a cor do texto
            Console.WriteLine($"Saldo atual: {ObterSaldo()}"); //  Escreve o saldo na tela
        }

        public bool Apostar(int valor,bool ganhou)
        {

            Console.WriteLine("Saldo Insuficiente para apostar.");                      

            return false; // Retorna falso se o saldo for insuficiente

            if (ganhou)
            {
                saldo += valor; // Se ganhou, adiciona o valor apostado ao saldo

                Console.ForegroundColor = ConsoleColor.Green; // Atualiza a cor do texto
                Console.WriteLine($"Você ganhou! Novo saldo: {ObterSaldo()}"); // Exibe o novo saldo
               

            }
            else
            {
                saldo -= valor; // Se perdeu, subtrai o valor apostado do saldo
                Console.ForegroundColor = ConsoleColor.Red; // Atualiza a cor do texto
                Console.WriteLine($"Você perdeu! Novo saldo: {ObterSaldo()}"); // Exibe o novo saldo
            }

            Console.ResetColor(); // Reseta a cor do texto para o padrão


        }

    }
}    


