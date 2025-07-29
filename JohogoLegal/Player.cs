using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    public class Player : MonoBehaviour
    {
        // Posição atual do jogador (usando estrutura personalizada)
        private Vector2 pos = new Vector2(1, 1);

        public bool visible { get; internal set; } // Propriedade para controlar a visibilidade do jogador

        // Atualiza a posição do jogador conforme a tecla pressionada
        public void AtualizarPosicao(ConsoleKey tecla) // Método para atualizar a posição do jogador com base na tecla pressionada
        {
            // Salva a posição anterior
            int oldX = pos.x; // Posição x anterior do jogador
            int oldY = pos.y;

            // Cópias locais
            int x = pos.x; // Posição x do jogador
            int y = pos.y;

            // Verifica a tecla pressionada
            switch (tecla)
            {
                case ConsoleKey.A:   // Tecla A para mover para a esquerda
                    x = pos.x - 1;  //  Move o jogador para a esquerda
                    break;
                case ConsoleKey.D: // Tecla D para mover para a direita
                    x = pos.x + 1;
                    break;
                case ConsoleKey.W:
                    y = pos.y - 1;
                    break;
                case ConsoleKey.S:  
                    y = pos.y + 1;
                    break; 
            }

            // Impede o jogador de ultrapassar as bordas do mapa
            char[,] mapaAtual = Mapa.Instancia.GetMapa(); // Obtém o mapa atual
            if (mapaAtual[x, y] == '#')  // Verifica se a nova posição é uma parede
            {
                pos.x = oldX;   // Restaura a posição anterior se a nova posição for uma parede
                pos.y = oldY;  //  Restaura a posição anterior se a nova posição for uma parede
            }
            else
            {
                pos.x = x;  //   Atualiza a posição do jogador
                pos.y = y; //   Atualiza a posição do jogador
            }

            // Posiciona o cursor do console na nova posição
            Console.SetCursorPosition(pos.x, pos.y);  //    Define a posição do cursor no console
        }

        // Permite acessar a posição atual de fora
        public Vector2 ObterPosicao() // Método para obter a posição atual do jogador
        {
            return pos; // Retorna a posição atual do jogador
        }

        public override void Update()
        {

            if (!input) return;
            var tecla = Console.ReadKey(true).Key; // Lê a tecla pressionada sem exibir no console

            AtualizarPosicao(tecla); // Atualiza a posição do jogador com base na tecla pressionada

        }


        public override void LateUpdate()  /// Marcius mandou colocar
        {

        }

        public override void Draw() // Desenha o jogador na posição atual
        {
            Console.SetCursorPosition(pos.x, pos.y);   //   Define a posição do cursor no console
            Console.Write("@"); // Desenha o jogador como um símbolo "@" na posição atual
        }
    }




}
