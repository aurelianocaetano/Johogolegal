
namespace JohogoLegal {

    class ProgramCopia

    {

        static void copia()

        {

            string[] cores = { "vermelho", "azul", "verde" };

            Random rand = new Random();

            bool jogarNovamente = true;

            while (jogarNovamente)

            {

                Console.Clear();

                Console.WriteLine("Bem-vindo ao jogo das cores!");

                Console.WriteLine("Escolha uma cor: vermelho, azul ou verde");

                Console.Write("Sua escolha: ");

                string escolhaUsuario = Console.ReadLine().ToLower(); // ToLower corverte todos os caracteres de uma string para minuscula

                // Verifica se a escolha é válida

                if (Array.IndexOf(cores, escolhaUsuario) == -1)

                {

                    Console.WriteLine("Escolha inválida! Tente novamente.");

                    continue;

                }

                // Sorteia uma cor

                string corSorteada = cores[rand.Next(cores.Length)];

                Console.WriteLine($"\nA cor sorteada foi: {corSorteada}");

                // Verifica se acertou

                if (escolhaUsuario == corSorteada)

                {

                    Console.WriteLine("Parabéns! Você acertou!");

                }

                else

                {

                    Console.WriteLine("Que pena! Você errou.");

                }

                // Pergunta se quer jogar novamente

                Console.Write("\nDeseja jogar novamente? (s/n): ");

                string resposta = Console.ReadLine().ToLower();

                jogarNovamente = (resposta == "s");

            }

            Console.WriteLine("Obrigado por jogar!");

        }


        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////
        /// </summary>


        static void Batatatinha()
        {
            // See https://aka.ms/new-console-template for more information


            /* comentario de bloco
             * 
             *  TIPO NÚMERICO 





             */



            //Console.WriteLine("Hello, World!");

            //uso para inteiro
            int pontos = 12;
            int vida = 0;
            float velocidade = 10f; // esse é menor 
            double dano = 16.5;



            /*  TIPOS DE TEXTO */

            string nome;
            char letra;


            /*   TIPO BOLEANO  */

            bool playing = false;
            string titulo = "lool";

            ///////////////////////////////////////////////////////



            string[] cores = { "vermelho", "azul", "verde" };
            Console.WriteLine("vermelho, azul, verde");

            Console.Write("Sua escolha: ");

            string escolhaUsuario = Console.ReadLine().ToLower(); // ToLower corverte todos os caracteres de uma
                                                                  // string para minuscula

            // Sorteia uma cor
            Random rand = new Random();

            string corSorteada = cores[rand.Next(cores.Length)]; // retorna o numero de caracteres

            Console.WriteLine($"\nA cor sorteada foi: {corSorteada}");


            // Verifica se acertou

            if (escolhaUsuario == corSorteada)

            {

                Console.WriteLine("Parabéns! Você acertou!");

            }

            else

            {

                Console.WriteLine("Que pena! Você errou.");

            }

        }


    }


}


