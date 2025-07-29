using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace JohogoLegal
{
    public class Banco : MonoBehaviour  // Classe Banco que herda de MonoBehaviour
    {
        private int saldo;
        private const int VALOR_GANHO = 20; // Valor ganho ao vencer
        private const int VALOR_PERDIDO = 10;   // Valor perdido ao perder  
        private const int SALDO_INICIAL = 100; // Saldo inicial do banco

        public Banco() // Construtor da classe Banco
        {
            saldo = SALDO_INICIAL; // Inicializa o saldo com o valor definido
        }

        public void Adicionar(int valor) // Método para adicionar valor ao saldo
        {
            if (valor > 0) // Verifica se o valor é positivo
            {
                saldo += valor; // Adiciona o valor ao saldo atual
            }
        }

        public void Subtrair(int valor)  // Método para subtrair valor do saldo
        {
            if (valor > 0) // Verifica se o valor é positivo
            {
                saldo = Math.Max(0, saldo - valor); //  Garante que o saldo não fique negativo
            }
        }

        public int ObterSaldo() => saldo; // Método para obter o saldo atual

        public void ExibirSaldo() //    Método para exibir o saldo na tela
        {
            // Ajusta a posição para ficar dentro da área jogável do mapa
            int margemX = 3; // Um pouco mais de margem para não encostar na borda
            int margemY = 3; // Um pouco mais de margem para não encostar na borda
            Console.SetCursorPosition(2 + margemX, 1 + margemY); // Define a posição do cursor
            Console.ForegroundColor = ConsoleColor.Yellow; // Define a cor do texto
            Console.Write($"Saldo atual: {ObterSaldo()}"); // Exibe o saldo atual
            Console.ResetColor(); // Reseta a cor do texto
        }

        public void ProcessarResultado(bool ganhou) // Método para processar o resultado do jogo
        {
            if (ganhou) // Verifica se o jogador ganhou
            {
                Adicionar(VALOR_GANHO); //  Adiciona o valor ganho ao saldo
                ExibirMensagem($"Você ganhou! +{VALOR_GANHO} créditos", ConsoleColor.Green); // Exibe mensagem de vitória
            }
            else // Verifica se o jogador perdeu
            {
                Subtrair(VALOR_PERDIDO); // Subtrai o valor perdido do saldo
                ExibirMensagem($"Você perdeu! -{VALOR_PERDIDO} créditos", ConsoleColor.Red); // Exibe mensagem de derrota
            }
        }

        private void ExibirMensagem(string mensagem, ConsoleColor cor) //   Método para exibir mensagens com cor
        {
            Console.ForegroundColor = cor;  // Define a cor do texto
            Console.WriteLine($"{mensagem}. Novo saldo: {ObterSaldo()}"); //   Exibe a mensagem com o novo saldo
            Console.ResetColor();
        }

        public override void Draw()
        {
            ExibirSaldo();
        }
    }
}