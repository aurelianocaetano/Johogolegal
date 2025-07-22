using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    internal class Player
    {

        Vector2 pos = new Vector2(1, 1);

       

        public void AtualizarPosicao(ConsoleKey tecla)
        {
            int oldX = pos.x;
            int oldY = pos.y;
            int x = pos.x;
            int y = pos.y;

            switch (tecla)
            {

                case ConsoleKey.A:
                    x = pos.Left;
                    break;
                case ConsoleKey.W:
                    x = pos.Right;
                    break;
                case ConsoleKey.D:
                    y = pos.Up;
                    break;
                case ConsoleKey.S:
                    y = pos.Down;
                    break;

                    if (Mapa.Instancia.mapa[x, y] == '#')
                    {
                        pos.x = oldX;
                        pos.y = oldY;
                    }
           


            }
        }
    }
    
}
