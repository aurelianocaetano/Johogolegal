using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace JohogoLegal
{
    public class Menu : MonoBehaviour  // Classe Menu que herda de MonoBehaviour
    {
      

        public bool visible { get; internal set; } // Propriedade para controlar a visibilidade do menu
        private Personagem personagem; // Instância do personagem
        private Banco banco; // Instância do banco
        private bool jogando = false; //Indica se o jogo está em andamento
        private bool jogarNovamente = false; // Indica se o jogador deseja jogar novamente

        public Menu() // Contrututor da Classe Menu
        {
            Run(); // Inicia o menu chamando o método Run
        }

        public  override void Start() // Método Start que é chamado quando o menu é iniciado
        {
            personagem = new Personagem();
            banco = new Banco();
            mapa = Mapa.Instancia;
            mapa.Visible = true;

            MostrarTelaBoasVindas();
            SolicitarNomeJogador();
            MostrarMenuPrincipal();
        }

        private void MostrarTelaBoasVindas()
        {
            Console.Clear();
            Mapa.Instancia.Draw(); // Desenha o mapa primeiro
            MostrarTextoNaTela(1, 1, "Seja Bem-Vindo ao Batatatola!!");
            MostrarTextoNaTela(1, 2, "Aperte Enter para começar...");
            MostrarTextoNaTela(1, 4, "Proibido para menores de 18 Anos...");
            Console.ReadKey();
        }

        private void SolicitarNomeJogador() // Método para solicitar o nome do jogador
        {
            Console.Clear();
            Mapa.Instancia.Draw(); // Desenha o mapa primeiro
            MostrarTextoNaTela(1, 1, "Insira seu primeiro nome:");
            Console.SetCursorPosition(29, 4); // Ajustado para ficar na frente dos dois pontos
            personagem.Nome = Console.ReadLine();
        }

        private void MostrarMenuPrincipal()
        {
            string[] opcoes = { "Jogar", "Banco", "Histórico" };
            int indiceSelecionado = 0;
            ConsoleKey tecla;

            do  // Loop para exibir o menu e capturar a entrada do usuário
            {
                Console.Clear();
                Mapa.Instancia.Draw(); // Desenha o mapa primeiro
                MostrarTextoNaTela(2, 1, $"Bem-vindo, {personagem.Nome}!"); // Exibe o nome do jogador

                for (int i = 0; i < opcoes.Length; i++) // Loop para exibir as opções do menu
                {
                    string prefixo = (i == indiceSelecionado) ? ">" : " "; // Define o prefixo para a opção selecionada
                    MostrarTextoNaTela(5, 3 + i, $"{prefixo} {opcoes[i]}"); // Exibe a opção do menu na tela, com o prefixo de seleção
                    
                }


                tecla = Console.ReadKey(true).Key; // Lê a tecla pressionada sem exibir no console

                if (tecla == ConsoleKey.W && indiceSelecionado > 0) // Se a tecla W for pressionada e o índice não for o primeiro
                    indiceSelecionado--;  // Move para a opção anterior
                else if (tecla == ConsoleKey.S && indiceSelecionado < opcoes.Length - 1) // Se a tecla S for pressionada e o índice não for o último
                    indiceSelecionado++; // Move para a próxima opção

            } while (tecla != ConsoleKey.Enter); // Continua até que a tecla Enter seja pressionada

            ProcessarOpcaoSelecionada(opcoes[indiceSelecionado]); // Processa a opção selecionada pelo usuário
        }

        private void ProcessarOpcaoSelecionada(string opcao) // Método para processar a opção selecionada pelo usuário
        {
            switch (opcao.ToLower()) // Converte a opção selecionada para minúsculas para comparação
            {
                case "jogar": // Opção "Jogar"
                    jogando = true; // Define que o jogo está em andamento
                    break;
                case "banco": // Opção "Banco"
                    MostrarTelaDoBanco(); // Exibe a tela do banco
                    break;
                default:    // Opção "Histórico" ou qualquer outra opção não implementada
                    MostrarTextoNaTela(2, 10, "Não há registro positivo para esta atividade!");
                    MostrarTextoNaTela(2, 12, "Tecle Enter para voltar ao Menu");
                    Console.ReadKey();
                    break;
            }
        }

        private void MostrarTelaDoBanco()
        {
            Console.Clear();
            Mapa.Instancia.Draw(); // Desenha o mapa primeiro
            banco.ExibirSaldo();
            MostrarTextoNaTela(2, 3, $"Invista seu dinheiro {personagem.Nome}");
            MostrarTextoNaTela(2, 5, "Tecle Enter para voltar ao Menu");
            Console.ReadKey();
            MostrarMenuPrincipal();
        }

        public  override void Update()
        {
            if (jogando)
            {

                Console.Clear();
                // Desenha o mapa
                Mapa.Instancia.Draw();
                SelecionarCorComEsferas();
                AtualizarPosicao();

                MostrarTextoNaTela(1, 11, "Escolha (s/Sim/ n/Não) e confirme enter:");
                Console.SetCursorPosition(44, 14); // Ajustado para ficar logo após os dois pontos
                string resposta = Console.ReadLine().ToLower();
                jogarNovamente = (resposta == "s");
                if (!jogarNovamente)
                {
                    jogando = false;
                }
            }
            else
            {
                MostrarMenuPrincipal();

            }
           
        }

        private void AtualizarPosicao()
        {
            Console.Clear();
            Mapa.Instancia.Draw(); // Mantém o mapa visível

            if (!personagem.EscolhaValida())
            {
                MostrarTextoNaTela(1, 3, "Escolha inválida! Tente novamente.");
                Console.ReadKey();
                return;
            }

            string corSorteada = personagem.SortearCor();
            ConsoleColor corVisual = personagem.ObterCorVisual(corSorteada);

            MostrarTextoNaTela(1, 3, "A cor sorteada foi: ");
            Console.SetCursorPosition(20, 6); // Posição ajustada para a cor sorteada
            Console.ForegroundColor = corVisual;
            Console.Write(corSorteada);
            Console.ResetColor();

            bool acertou = personagem.Acertou(corSorteada);
            banco.ProcessarResultado(acertou);

            Console.Clear();
            Mapa.Instancia.Draw(); // Redesenha o mapa antes de mostrar o resultado

            if (acertou)
            {
                MostrarTextoNaTela(14, 1, $"Jogue com responsabilidade");

                MostrarTextoNaTela(1, 5, $"Parabéns,{personagem.Nome}, você acertou!"); // Mensagem de sucesso
                MostrarTextoNaTela(1, 9, $"Aperte qualquer tecla para Continuar");      // Mensagem de continuação
            }
            else
            {
                MostrarTextoNaTela(1, 3, $"Cassino não é Renda");
                MostrarTextoNaTela(1, 5, $"Que pena {personagem.Nome},você errou!");  // Mensagem de erro
                MostrarTextoNaTela(1, 9, $"Aperte Enter continuar");    // Mensagem de continuação

            }

           
            MostrarTextoNaTela(1, 7, $"Saldo atual:{banco.ObterSaldo()}"); // Exibe o saldo atual
            Console.ReadKey();
        }

        private void SelecionarCorComEsferas() // Método para selecionar a cor com esferas
        {
            List<string> opcoes = personagem.ObterCoresDisponiveis(); // Obtém as cores disponíveis
            int indiceSelecionado = 0; // Índice do item selecionado
            ConsoleKey tecla; // Variável para armazenar a tecla pressionada

            do  // Loop para exibir as opções e capturar a entrada do usuário
            {
                Console.Clear(); // Limpa o console
                Mapa.Instancia.Draw(); // Desenha o mapa primeiro
                MostrarTextoNaTela(2, 1, "Use A/D para mover. Enter para escolher."); // Instruções para o usuário

                for (int i = 0; i < opcoes.Count; i++) // Loop para exibir as opções de cores
                {
                    int x = 5 + i * 10; // Posição horizontal para cada opção
                    int y = 5; // Posição vertical fixa para todas as opções

                    Console.SetCursorPosition(x, y); // Define a posição do cursor
                    if (i == indiceSelecionado)  // Se a opção estiver selecionada
                        Console.Write(">"); // Exibe o símbolo de seleção

                    Console.SetCursorPosition(x, y + 1); // Define a posição do cursor para a esfera
                    Console.ForegroundColor = personagem.ObterCorVisual(opcoes[i]); // Obtém a cor visual da esfera
                    Console.Write("●"); // Exibe a esfera colorida
                    Console.ResetColor(); // Reseta a cor do console

                    Console.SetCursorPosition(x, y + 2); // Define a posição do cursor para o nome da cor
                    Console.Write(opcoes[i]); // Exibe o nome da cor
                }

                tecla = Console.ReadKey(true).Key; // Lê a tecla pressionada sem exibir no console

                if (tecla == ConsoleKey.A && indiceSelecionado > 0) // Se a tecla A for pressionada e o índice não for o primeiro
                    indiceSelecionado--;  // Move para a opção anterior
                else if (tecla == ConsoleKey.D && indiceSelecionado < opcoes.Count - 1)  // Se a tecla D for pressionada e o índice não for o último
                    indiceSelecionado++; // Move para a próxima opção

            } while (tecla != ConsoleKey.Enter); // Continua até que a tecla Enter seja pressionada

            personagem.EscolhaUsuario = opcoes[indiceSelecionado];  // Define a escolha do usuário com base no índice selecionado
        }

        private void MostrarTextoNaTela(int x, int y, string texto) // Método para mostrar texto na tela em uma posição específica
        {
            // Ajusta a posição para ficar dentro da área jogável do mapa
            int margemX = 3; // Um pouco mais de margem para não encostar na borda
            int margemY = 3;  
            Console.SetCursorPosition(x + margemX, y + margemY); // Define a posição do cursor
            Console.Write(texto); // Exibe o texto na tela
        }

        public override void Draw() // Método para desenhar o menu
        {
            if (visible)  // Verifica se o menu está visível
            {
                if (jogando)  // Se o jogo esta em andamento ou se é verdadeiro
                {
                    Mapa.Instancia.Draw(); // Desenha o mapa
                }
            }
        }
    }
}