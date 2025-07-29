
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JohogoLegal
{
    public class Mapa : MonoBehaviour
    {
        private static readonly Lazy<Mapa> instancia = new Lazy<Mapa>(() => new Mapa()); // Instância única do mapa usando Lazy para garantir que seja criado apenas quando necessário

        private readonly int largura;
        private readonly int altura; // Atributos para armazenar a largura e altura do mapa
        private char[,] mapaAtual; // Matriz 2D para armazenar o mapa atual

        public static Mapa Instancia => instancia.Value;  // Propriedade estática para acessar a instância única do mapa
        public bool visible { get; set; } = true; // Propriedade para controlar a visibilidade do mapa
        public bool Visible { get; set; } // Propriedade para controlar a visibilidade do mapa, usada no método Update

        public char[,] GetMapa()  // Método para obter o mapa atual
        {
            return mapaAtual;   // Retorna o mapa atual
        }

        private Mapa() // Construtor privado para garantir que a classe seja um Singleton
        {
            largura = 60;  // Aumentei a largura para ter mais espaço
            altura = 20;  // Aumentei a altura para ter mais espaço
            mapaAtual = new char[largura, altura]; // Cria uma matriz 2D para armazenar o mapa atual
            InicializarMapa(); // Chama o método para inicializar o mapa
        }

        private void InicializarMapa() // Método para inicializar o mapa
        {
            // Preenche todo o mapa com #
            for (int y = 0; y < altura; y++) // percorre as linhas do mapa
            {
                for (int x = 0; x < largura; x++) // percorre as colunas do mapa
                {
                    mapaAtual[x, y] = '#'; // Preenche o mapa com paredes representadas por '#'
                }
            }

            // Cria uma área jogável no centro (limpa o centro)

            // Definindo margens para a área jogável
            int margemX = 2;  // Margem de 2 caracteres em cada lado
            int margemY = 2;  // Margem de 2 caracteres em cima e embaixo

            for (int y = margemY; y < altura - margemY; y++) // percorre as linhas do mapa
            {
                for (int x = margemX; x < largura - margemX; x++) // percorre as colunas do mapa
                {
                    mapaAtual[x, y] = ' '; // Preenche o espaço vazio dentro da área jogável
                }
            }
        }

        public override void Update() // Método Update que é chamado para atualizar o mapa
        {
            if (Visible) // Verifica se o mapa está visível antes de atualizar
            {
                Draw();  // Chama o método Draw para desenhar o mapa atualizado
            }
        }

        public override void Draw() // Método Draw que é chamado para desenhar o mapa
        {
            if (!Visible) return; // Verifica se o mapa está visível antes de desenhar

            Console.Clear(); // Limpa o console antes de desenhar o mapa
            Console.ForegroundColor = ConsoleColor.White; // Define a cor do texto como branco

            // Desenha o mapa com bordas mais visíveis
            for (int y = 0; y < altura; y++) // percorre cada linha do mapa
            {
                for (int x = 0; x < largura; x++) // percorre cada coluna do mapa
                {
                    if (mapaAtual[x, y] == '#') // se o caractere for uma parede
                    {
                        Console.Write('#'); // desenha a parede
                    }
                    else  // se for um espaço vazio
                    {
                        Console.Write(mapaAtual[x, y]); // desenha o espaço vazio
                    }
                }
                Console.WriteLine(); // pula para a próxima linha após desenhar uma linha completa do mapa
            }
        }
    }
}