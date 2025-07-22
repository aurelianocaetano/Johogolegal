using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    internal class GameManager
    {

      private GameManager() {}
        
        static private GameManager instance;

        static public GameManager Instance => instance ??= new GameManager();



        private bool jogando = true;
        private bool jogarNovamente = false;
        private int altura = 15;
        private char[,] mapa;

        public void StartGame()
        {
            // Vector2 pos = new Vector2(1 ,1);

           

            Personagem p = new Personagem();
            IniciarMapa();

            //Console.Clear();
            MostrarTextoNaTela(1, 1, "Seja Bem-Vindo ao Batatatola!!");
            MostrarTextoNaTela(1, 2, "Aperte Enter para começar...");
            Console.ReadKey();

            Console.Clear();
            MostrarTextoNaTela(1, 1, "Insira seu primeiro nome:");
            Console.SetCursorPosition(2, 3);
            p.nome = Console.ReadLine();

            Console.Clear();
            MostrarTextoNaTela(1, 1, $"Bem-vindo, {p.nome}! Digite a opção de menu:");
            MostrarTextoNaTela(1, 3, "Jogar");
            MostrarTextoNaTela(1, 4, "Configurações");
            MostrarTextoNaTela(1, 5, "Histórico");
            Console.SetCursorPosition(2, 7);
            string escolha = Console.ReadLine().ToLower();

            if (escolha == "jogar")
            {
                Jogar(p);
            }
            else
            {
                MostrarTextoNaTela(1, 9, "Opção ainda não implementada.");
            }
        }

        private void Jogar(Personagem p)
        {
            while (jogando)
            {
                Console.Clear();
                IniciarMapa();
                MostrarTextoNaTela(1, 1, "Escolha uma cor: vermelho, azul, verde");
                Console.SetCursorPosition(2, 3);
                p.escolhaUsuario = Console.ReadLine().ToLower();

                AtualizarPosicao(p);

                MostrarTextoNaTela(1, 10, "Deseja jogar novamente? (s/n): ");
                Console.SetCursorPosition(33, 10);
                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = (resposta == "s");
                if (!jogarNovamente)
                {
                    jogando = false;
                }
            }
        }

        private void AtualizarPosicao(Personagem p)
        {   
            Console.Clear();
            IniciarMapa();

            if (!p.EscolhaValida())
            {
                MostrarTextoNaTela(1, 3, "Escolha inválida! Tente novamente.");
                Console.ReadKey();
                return;
            }

            string corSorteada = p.SortearCor();
            ConsoleColor corVisual = p.ObterCorVisual(corSorteada);

            MostrarTextoNaTela(1, 3, "A cor sorteada foi: ");
            Console.ForegroundColor = corVisual;
            Console.WriteLine(corSorteada);
            Console.ResetColor();

            if (p.Acertou(corSorteada))
            {
                MostrarTextoNaTela(1, 5, $"Parabéns, {p.nome}, você acertou!");
            }
            else
            {
                MostrarTextoNaTela(1, 5, $"Que pena, {p.nome}, você errou!");
            }

            Console.ReadKey();
        }

        private void IniciarMapa()
        {
            mapa = new char[largura, altura];
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    mapa[x, y] = (x == 0 || y == 0 || x == largura - 1 || y == altura - 1) ? '#' : ' ';
                }
            }

            Console.Clear();
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void MostrarTextoNaTela(int x, int y, string texto)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(texto);
        }


    }
    
}


