

using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

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



        public static bool jogando = true; // Variável de controle do jogo

        public static  bool jogarNovamente; // Variável de controle para jogar novamente



        //Variáveis do Menu

        string Jogar = "";
        string Configuracao = "";
        string Historico = "";

       // public static bool jogando { get; private set; }

        static void Main()
        {


            Personagem p = new Personagem();
           
            Console.Clear();

            // Aqui vai entrar o menu de vocês
            /// Apresentação
            Console.WriteLine("Seja Bem Vindo ao Batatatola!!");

            Console.WriteLine("Aperte Enter");
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
            Console.WriteLine(" Insira seu primeiro nome:"); //inserção de nome

           p.nome = Console.ReadLine(); // Grava o nome digitado pelo usuário 
            Console.Clear();
            Console.WriteLine("Bem Vindo," + p.nome + "." + "Digite a opção de Menu desejada:"); // Imprime Nome digitado + solicitação pedindo opção de Menu

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
            
            Personagem p = new Personagem();
        
            while (jogando)
            {

                Console.Clear();
                DesenharMapa();
                p.escolhaUsuario = Console.ReadLine().ToLower();
                AtualizarPosicao();

                // Pergunta se quer jogar novamente
                Console.Write("\nDeseja jogar novamente? (s/n): ");
                Console.WriteLine("Digite sua ecolha:");

                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = (resposta == "s");








            }
        }
       /* static void IniciarMapa()
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



            Personagem p = new Personagem();



            // Sorteia uma cor

            if (Array.IndexOf(p.cores, p.escolhaUsuario) == -1)

            {

                Console.WriteLine("Escolha inválida!Tente novamente.");


            }
            else
            {

               


                //bool jogarNovamente = true;

                string corSorteada = p.cores[p.rand.Next(p.cores.Length)];

                Console.WriteLine($"\nA cor sorteada foi: {corSorteada}");



                // Verifica se acertou

                if (p.escolhaUsuario == corSorteada)
                    
                {
                    Console.WriteLine("Parabéns" + p.nome + "." + "Você acertou!");

                }

                else

                {

                    Console.WriteLine("Que pena!" + p.nome + "," + "Voçê errou:");

                }


              
    
    
    
    
    

            }


        }


    }

}



