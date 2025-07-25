using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    internal class Player : MonoBehaviour
    {
        // Posição atual do jogador (usando estrutura personalizada)
        private Vector2 pos = new Vector2(1, 1);

        public bool visible { get; internal set; }

        // Atualiza a posição do jogador conforme a tecla pressionada
        public void AtualizarPosicao(ConsoleKey tecla)
        {
            // Salva a posição anterior
            int oldX = pos.x;
            int oldY = pos.y;

            // Cópias locais
            int x = pos.x;
            int y = pos.y;

            // Verifica a tecla pressionada
            switch (tecla)
            {
                case ConsoleKey.A:
                    x = pos.Left;
                    break;
                case ConsoleKey.D:
                    x = pos.Right;
                    break;
                case ConsoleKey.W:
                    y = pos.Up;
                    break;
                case ConsoleKey.S:
                    y = pos.Down;
                    break;
            }

            // Impede o jogador de ultrapassar as bordas do mapa
            if (Mapa.Instancia.mapa[x, y] == '#')
            {
                pos.x = oldX;
                pos.y = oldY;
            }
            else
            {
                pos.x = x;
                pos.y = y;
            }

            // Posiciona o cursor do console na nova posição
            Console.SetCursorPosition(pos.x, pos.y);
        }

        // Permite acessar a posição atual de fora
        public Vector2 ObterPosicao()
        {
            return pos;
        }

        public override void UpDate()  /// Marcius mandou colocar
        {
            
             if  (!input) return;
             var tecla = Console.ReadKey(true).Key; // Lê a tecla pressionada sem exibir no console
            
             AtualizarPosicao(tecla); // Atualiza a posição do jogador com base na tecla pressionada

        }


        public override void LateUpdate()  /// Marcius mandou colocar
        {
            
        }

        public override void Draw()
        {
            if (mapa != null && mapa.visible) mapa.Draw();
            if (pl != null && pl.visible) pl.Draw();
            if (nemo != null && Menu.visible) Menu.Draw();
        }
    }

  


}
