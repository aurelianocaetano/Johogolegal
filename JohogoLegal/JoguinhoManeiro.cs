using System;
using System.Security.Permissions;


namespace JohogoLegal
{
     class JoguinhoManeiro
    {
        string nome = "";
        string Jogar = "";
        string Configuracao = "";
        string Historico = "";

        static void Main ()
        {
            /// Apresentação
            Console.WriteLine("Seja Bem Vindo ao Batatinha!!");
            
            Console.WriteLine("Aperte Enter");
            Console.WriteLine("---------------------------------------");
            Console.ReadKey();
            Console.WriteLine(" Insira seu primeiro nome:"); //inserção de nome






            string nome = Console.ReadLine(); // Grava o nome digitado pelo usuário 
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
            
            




















            /*
            Console.WriteLine(" Insira seu primeiro nome:"); // inserção de nome
           

            string nome = Console.ReadLine(); // Grava o nome digitado pelo usuário 
            Console.WriteLine( "Bem Vindo," + nome +"." +  "Digite a opção de Menu desejada:"); // Imprime Nome digitado + solicitação pedindo opção de Menu
            




            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Jogar");


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Configurações");
            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Historico");
            



            string Jogar = Console.ReadLine();
            Console.WriteLine("Loading.......");
            Console.WriteLine("---------------------------------------");
            

            string Configuracao = Console.ReadLine();
            Console.WriteLine(nome + ", " + "ecolha uma opção de configuração:");
            

            
            Console.WriteLine("Dificuldade");
            Console.WriteLine("---------------------------------------");

            string Historico = Console.ReadLine();

            Console.WriteLine("Escolha uma opção de Historico");
            Console.WriteLine("Jogadas");
            Console.WriteLine("Pontuação");
            Console.WriteLine("Classificação");
            Console.WriteLine("---------------------------------------"); */




            // Console.WriteLine("Configurações"); Console.WriteLine("Selecione a opção desejada");



            string tecla;
            do  {
                 tecla = Console.ReadLine();

                 switch (tecla){

                        case "a":
                            Console.WriteLine("Para Trás");
                            break;
                        case "w":
                            Console.WriteLine("Pra Cima");
                            break;
                        case "s":
                            Console.WriteLine("Pra Baixo");
                            break;
                        case "d":
                            Console.WriteLine("Pra Frente");
                            break;
                    
                }
            } while (tecla != "X");




        }


    }
}
