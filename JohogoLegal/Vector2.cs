using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    public class Vector2: MonoBehaviour
    {
        public int x;
        public int y;

        // Construtor que define posição inicial
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Propriedades que alteram a posição — cuidado: modificam diretamente
        public int Up => this.y - 1;       // Move para cima (y - 1)
        public int Down => this.y + 1;     // Move para baixo (y + 1)
        public int Left => this.x - 1;     // Move para esquerda (x - 1)
        public int Right => this.x + 1;    // Move para direita (x + 1)

        // Calcula a distância entre dois pontos (usado para lógica espacial se necessário)
        public static int Distance(Vector2 a, Vector2 b)
        {
            if (a == null || b == null) return -1;

            return (int)Math.Sqrt(
                (a.x - b.x) * (a.x - b.x) +
                (a.y - b.y) * (a.y - b.y)
            );
        }
    }


}
