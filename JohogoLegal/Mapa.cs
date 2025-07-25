using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    internal class Mapa : MonoBehaviour
    {
        // Singleton - garante uma única instância
        private static Mapa instancia;

        private Mapa() { Run(); }

        public static Mapa Instancia => instancia ??= new Mapa(); // Cria uma nova instância se não existir Padrão Singleton

        public bool visible { get; internal set; } // permite controlar a visibilidade do mapa 

        private int largura = 40;
        private int altura = 15;

        // Representa o mapa
        public char[,] mapa;

        public override void Update()
        {
            Draw(); // Chama o método Draw para atualizar a visualização do mapa
        }

        // Desenha o mapa com bordas '#' e espaço interno vazio
        public override void Draw()
        {
            mapa = new char[largura, altura]; // Inicializa a matriz do mapa com as dimensões especificadas

            for (int y = 0; y < altura; y++) // Verifica se y é menor que altura
            {
                for (int x = 0; x < largura; x++) // Verifica se x é menor que largura
                {
                    // Borda com '#', interior com espaço
                    if (y == 0 || y == altura - 1 || x == 0 || x == largura - 1) // Verifica se y é 0 ou altura-1 ou se x é 0 ou largura-1
                        mapa[x, y] = '#'; // Borda do mapa
                    else
                        mapa[x, y] = ' '; // Espaço vazio dentro do mapa
                }
            }

            Console.Clear();

            // Imprime  na tela
            for (int y = 0; y < altura; y++) // Verifica se y é menor que altura
            {
                for (int x = 0; x < largura; x++) // Verifica se x é menor que largura
                {
                    Console.Write(mapa[x, y]); // Imprime o caractere do mapa na posição (x, y)
                }
                Console.WriteLine(); // Pula para a próxima linha após imprimir uma linha completa do mapa
            }
        }

        // Atualiza o mapa a cada ciclo de execução da thread (se necessário)
        

        

    }
}
