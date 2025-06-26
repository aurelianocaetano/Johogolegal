

using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

namespace JohogoLegal
{ 
    class Program
    {
        //Variaveis de desenho de tela
        static char[,] mapa;
        static int largura = 20;
        static int altura = 10;
        static int playerX = 1;
        static int playerY = 1;
        
        static bool jogando = true;

        public static string escolhaUsuario = "";
        public static bool jogarNovamente;

        //Variáveis do Menu
        static string nome = "";
        string Jogar = "";
        string Configuracao = "";
        string Historico = "";




        static void Main()
        {
          

            Console.Clear();

             // Aqui vai entrar o menu de vocês
            /// Apresentação
            Console.WriteLine("Seja Bem Vindo ao Batatatola!!");

            Console.WriteLine("Aperte Enter");
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
            Console.WriteLine(" Insira seu primeiro nome:"); //inserção de nome

            nome = Console.ReadLine(); // Grava o nome digitado pelo usuário 
            Console.Clear();
            Console.WriteLine("Bem Vindo," + nome + "." + "Digite a opção de Menu desejada:"); // Imprime Nome digitado + solicitação pedindo opção de Menu

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Jogar");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Configurações");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Historico");

            string Jogar = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Loading.......");
            Console.WriteLine("---------------------------------------");


            if (jogando)
            {

                jogar();

            }


        }


        static void jogar()

        {
           // IniciarMapa(); // Chama a Função

            while (jogando)
            {
                Console.Clear();
                DesenharMapa();
                escolhaUsuario = Console.ReadLine().ToLower();
                AtualizarPosicao();

                // Pergunta se quer jogar novamente
                Console.Write("\nDeseja jogar novamente? (s/n): ");
                Console.WriteLine("Digite sua ecolha:");
                
                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = (resposta == "s");





               


            }
        }
        /*static void IniciarMapa()
        {
            mapa = new char[largura, altura];

            for (int x = 0; x < largura; x++)
            {

                for (int y = 0; y < altura; y++)
                {
                    // Ultima Posição do vetor é tamanho -1
                    if (x == 0 || y == 0 || x == largura - 1 || y == altura - 1)
                    {
                        mapa[x, y] = '#';
                    }
                    else
                    {
                        mapa[x, y] = ' ';

                    }
                }
            
            }
            mapa[playerX, playerY] = '@';
        }*/ // Declaração da função

       

        static void DesenharMapa()
        {
            Console.WriteLine("Escolha uma cor : vermelho, azul, verde ");
        }



        static void AtualizarPosicao()


        {

            


            // Variáveis jogo das cores
            string[] cores = { "vermelho", "azul", "verde" };



            // Sorteia uma cor

            if (Array.IndexOf(cores, escolhaUsuario) == -1)

            {

                Console.WriteLine("Escolha inválida!Tente novamente.");
                

            }
            else
            {

                // Variaveis do Jogo das Cores
                Random rand = new Random();
                //bool jogarNovamente = true;

                string corSorteada = cores[rand.Next(cores.Length)];

                Console.WriteLine($"\nA cor sorteada foi: {corSorteada}");



                // Verifica se acertou

                if (escolhaUsuario == corSorteada)

                {

                    Console.WriteLine("Parabéns" + nome + "." + "Você acertou!");

                }

                else

                {

                    Console.WriteLine("Que pena!" + nome + "," + "Voçê errou:");

                }



            }


        }


    }

}



