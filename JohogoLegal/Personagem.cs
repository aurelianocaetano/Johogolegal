using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace JohogoLegal
{
    public class Personagem : MonoBehaviour // Classe Personagem que herda de MonoBehaviour
    {
        private readonly Cores coresDisponiveis; //     Instância da classe Cores para gerenciar as cores disponíveis
        private readonly Random rand; // Instância da classe Random para sortear cores

        public string Nome { get; set; }  //    Propriedade para armazenar o nome do personagem
        public string EscolhaUsuario { get; set; }  //   Propriedade para armazenar a escolha do usuário

        public Personagem() //  Construtor da Classe Personagem
        {
            coresDisponiveis = new Cores();  // Instancia a classe Cores para obter as cores disponíveis
            rand = new Random();  //    Instancia a classe Random para sortear cores
            Nome = "";  //  Inicializa o nome do personagem como uma string vazia
            EscolhaUsuario = ""; //     Inicializa a escolha do usuário como uma string vazia
        }

        public List<string> ObterCoresDisponiveis()  //     Método para obter as cores disponíveis
        {
            return coresDisponiveis.ObterNomesCores(); // Retorna a lista de nomes de cores disponíveis da classe Cores     
        }

        public string SortearCor() //     Método para sortear uma cor aleatória
        {
            var cores = ObterCoresDisponiveis(); // Obtém a lista de cores disponíveis
            return cores[rand.Next(cores.Count)]; // Retorna uma cor aleatória da lista usando o gerador de números aleatórios
        }

        public bool EscolhaValida()  //    Método para verificar se a escolha do usuário é válida
        {
            return coresDisponiveis.CorExiste(EscolhaUsuario); // Verifica se a cor escolhida pelo usuário existe na lista de cores disponíveis
        }

        public bool Acertou(string corSorteada) //    Método para verificar se o usuário acertou a cor sorteada
        {
            return string.Equals(EscolhaUsuario, corSorteada, StringComparison.OrdinalIgnoreCase); // Compara a escolha do usuário com a cor sorteada, ignorando diferenças de maiúsculas e minúsculas
        }

        public ConsoleColor ObterCorVisual(string corNome) // Método para obter a cor visual correspondente ao nome da cor
        {
            return coresDisponiveis.ObterCorVisual(corNome); // Retorna a cor visual correspondente ao nome da cor usando a classe Cores
        }

        public override void Draw() // Método Draw que é chamado para desenhar o personagem
        {
            
        }
    }
}