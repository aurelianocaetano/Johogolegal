using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{

    internal class  Banco: MonoBehaviour
    {
        // Armazena o saldo atual do jogador
        private int saldo;

        // Valor ganho por acerto
        private const int valorGanho = 20;

        // Valor perdido por erro
        private const int valorPerdido = 10;

        // Construtor: saldo inicial definido em 100
        public Banco()
        {
            saldo = 100;
        }

        // Método para adicionar saldo (em caso de vitória)
        public void Adicionar(int valor)
        {
            saldo += valor;
        }

        // Método para subtrair saldo (em caso de derrota)
        public void Subtrair(int valor)
        {
            saldo -= valor;
            if (saldo < 0)
                saldo = 0;
        }

        // Retorna o valor atual do saldo
        public int ObterSaldo()
        {
            return saldo;
        }

        // Mostra o saldo atual no topo esquerdo da tela
        public void ExibirSaldo()
        {
            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Saldo atual: {ObterSaldo()}");
            Console.ResetColor();
        }

        // Realiza uma aposta: se ganhar, adiciona; se perder, subtrai
        public void Apostar(bool ganhou)
        {
            if (ganhou)
            {
                Adicionar(valorGanho);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Você ganhou! +{valorGanho} créditos. Novo saldo: {ObterSaldo()}");
            }
            else
            {
                Subtrair(valorPerdido);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Você perdeu! -{valorPerdido} créditos. Novo saldo: {ObterSaldo()}");
            }

            Console.ResetColor();
        }

        public override void Draw()
        {
            // Inicialização do jogo
            GameManager.Instance.mapa = new Mapa();
            GameManager.Instance.pl = new Player();
            GameManager.Instance.nemo = new Menu();
        }
    }

    internal class Mapa : MonoBehaviour
    {
        private static Mapa instancia;
        public static Mapa Instancia { get; }
        public bool visible { get; internal set; }
        private int largura;
        private int altura;
        public char[,] mapa;
        public override void Update();
        public override void Draw();
    }


}


