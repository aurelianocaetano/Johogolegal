using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{

    internal class GameManager : MonoBehaviour
    {
        private Thread t;
        private bool ativo = true; // Controla se o loop deve continuar

        public bool visible = false; // Marcius mandou colocar
        public bool input = false;


        private GameManager() { }

        private static GameManager instance;


        public static GameManager Instance => instance ??= new GameManager();

        public Mapa mapa;
        public  Player pl;
        public  Menu nemo;

        private bool jogando = true;
        private bool jogarNovamente = false;
        

        public void StartGame()
        {
            Personagem p = new Personagem();
            Banco banco = new Banco();                             ///  ESTA PARTE SAÍRA

            // Menu começa aqui 
            Console.Clear();
            MostrarTextoNaTela(1, 1, "Seja Bem-Vindo ao Batatatola!!");
            MostrarTextoNaTela(1, 2, "Aperte Enter para começar...");
            Console.ReadKey(); // Aguarda apertar um botão para continuar

            Console.Clear(); // Limpa a tela antes de solicitar o nome do jogador
            MostrarTextoNaTela(1, 1, "Insira seu primeiro nome:");
            Console.SetCursorPosition(2, 3); // Posiciona o cursor para entrada do nome
            p.nome = Console.ReadLine(); // Lê o nome do jogador e Guarda essa merda!

            MostrarMenuPrincipal(p, banco); // Este trecho chama o menu principal do jogo a parte de consutar o Banco
                                            // Marcius pediu uma consulta ao saldo
        }
        ///  ESTA PARTE SAÍRA
        private void MostrarMenuPrincipal(Personagem p, Banco banco)  // Função que mostra o menu principal do jogo personagem, e acessado no  switch
        {                                                            // Acessa a class Internal e depois a Varivel banco
            string[] opcoes = { "Jogar", "Banco", "Histórico" }; // Vetor com as opções do menu
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do   // Executa ao menos uma vez antes de checar a condição
            {
                Console.Clear();
                MostrarTextoNaTela(2, 1, $"Bem-vindo, {p.nome}!"); // Exibe o nome do jogador no menu,usando orientação de tela posição 2,1

                for (int i = 0; i < opcoes.Length; i++)  // Verifica o tamanho do vetor de opsções 
                {
                    string prefixo = (i == indiceSelecionado) ? ">" : " ";
                    MostrarTextoNaTela(5, 3 + i, $"{prefixo} {opcoes[i]}");
                }

                tecla = Console.ReadKey(true).Key;  

                if (tecla == ConsoleKey.W && indiceSelecionado > 0)
                    indiceSelecionado--;
                else if (tecla == ConsoleKey.S && indiceSelecionado < opcoes.Length - 1) // Se a tecla S for selecionada e o índice selecionado for menor que o tamanho do vetor de opções menos 1, incrementa o índice selecionado
                    indiceSelecionado++;                                                //

            } while (tecla != ConsoleKey.Enter);

            switch (opcoes[indiceSelecionado].ToLower()) 
            {
                case "jogar":
                    Jogar(p, banco);
                    break;
                case "banco":
                    MostrarTelaDoBanco(banco);
                    break;                                             ///  ESTA PARTE SAÍRA ATÉ AQUI
                default:
                    MostrarTextoNaTela(2, 10, "Opção ainda não implementada.");
                    Console.ReadKey();
                    break;
            }
        }
              
        private void MostrarTelaDoBanco(Banco banco)  // Função Banco Exibe o Saldo do apostador 
        {
            Console.Clear(); // Limpa 
            banco.ExibirSaldo(); // Exibe
            MostrarTextoNaTela(2, 5, "Pressione qualquer tecla para voltar ao menu..."); // imprime na tela com orientação de tela posição 2,5
            Console.ReadKey();


        }
        /// <summary>
      
       
        private void Jogar(Personagem p, Banco banco)
        {
            while (jogando)
            {
                Console.Clear();
               
                SelecionarCorComEsferas(p);

                AtualizarPosicao(p, banco);

                MostrarTextoNaTela(1, 10, "Deseja jogar novamente? (s/n): ");
                Console.SetCursorPosition(33, 10);
                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = (resposta == "s");
                if (!jogarNovamente)
                    jogando = false;
            }
        }

        private void AtualizarPosicao(Personagem p, Banco banco)
        {
            Console.Clear();
            
            if (!p.EscolhaValida())
            {
                MostrarTextoNaTela(1, 3, "Escolha inválida! Tente novamente.");
                Console.ReadKey();
                return;
            }

            string corSorteada = p.SortearCor();
            ConsoleColor corVisual = p.ObterCorVisual(corSorteada);

            MostrarTextoNaTela(1, 3, "A cor sorteada foi: ");
            Console.ForegroundColor = corVisual;
            Console.WriteLine(corSorteada);
            Console.ResetColor();

            bool acertou = p.Acertou(corSorteada);
            if (acertou)
            {
                banco.Adicionar(20);
                MostrarTextoNaTela(1, 5, $"Parabéns, {p.nome}, você acertou!");
            }
            else
            {
                banco.Subtrair(10);
                MostrarTextoNaTela(1, 5, $"Que pena, {p.nome}, você errou!");
            }

            MostrarTextoNaTela(1, 7, $"Saldo atual: {banco.ObterSaldo()}");
            Console.ReadKey();
        }

        private void SelecionarCorComEsferas(Personagem p)
        {
            List<string> opcoes = p.cores;
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do
            {
                Console.Clear();
                MostrarTextoNaTela(2, 1, "Use A/D para mover. Enter para escolher.");

                for (int i = 0; i < opcoes.Count; i++)
                {
                    int x = 5 + i * 6;
                    int y = 5;

                    Console.SetCursorPosition(x, y);
                    if (i == indiceSelecionado)
                        Console.Write(">");

                    Console.SetCursorPosition(x, y + 1);
                    Console.ForegroundColor = p.ObterCorVisual(opcoes[i]);
                    Console.Write("●");
                    Console.ResetColor();

                    Console.SetCursorPosition(x, y + 2);
                    Console.Write(opcoes[i]); // opcional
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.A && indiceSelecionado > 0)
                    indiceSelecionado--;
                else if (tecla == ConsoleKey.D && indiceSelecionado < opcoes.Count - 1)
                    indiceSelecionado++;

            } while (tecla != ConsoleKey.Enter);

            p.escolhaUsuario = opcoes[indiceSelecionado];
        }

        private void MostrarTextoNaTela(int x, int y, string texto)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(texto);
        }

        public override void Draw() /// Marcius mandou colocar
        {
            
            


                if ( mapa != null && mapa.visible)mapa.Draw();
                if (pl != null && pl.visible) pl.Draw();
                if (nemo != null && nemo.visible) nemo.Draw();
            // banco também pode ser desenhado aqui, se necessário




        }
    }
      
    

}


