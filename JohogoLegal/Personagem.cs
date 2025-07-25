using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    class Personagem:MonoBehaviour
    {
        // Lista com os nomes das cores
        public List<string> cores = new List<string> { "vermelho", "azul", "verde" };

        // Lista com as cores visuais equivalentes
        public List<ConsoleColor> caixa = new List<ConsoleColor>();

        // Nome do jogador
        public string nome = "";

        // Cor escolhida pelo jogador
        public string escolhaUsuario = "";

        // Gerador de números aleatórios
        public Random rand = new Random();

        // Construtor do personagem (inicia as cores visuais)
        public Personagem()
        {
            PreencherCores();
        }

        // Preenche a lista "caixa" com as cores correspondentes da lista "cores"
        private void PreencherCores()
        {
            caixa.Add(ConsoleColor.Red);
            caixa.Add(ConsoleColor.Blue);
            caixa.Add(ConsoleColor.Green);
        }

        // Retorna uma cor aleatória da lista
        public string SortearCor()
        {
            return cores[rand.Next(cores.Count)];
        }

        // Verifica se a escolha do usuário está dentro das opções válidas
        public bool EscolhaValida()
        {
            return cores.Contains(escolhaUsuario);
        }

        // Verifica se o usuário acertou a cor sorteada
        public bool Acertou(string corSorteada)
        {
            return escolhaUsuario == corSorteada;
        }

        // Retorna a cor visual (ConsoleColor) correspondente ao nome da cor
        public ConsoleColor ObterCorVisual(string corNome)
        {
            int index = cores.IndexOf(corNome);
            if (index >= 0 && index < caixa.Count)
                return caixa[index];
            return ConsoleColor.White; // Se não encontrada, cor padrão
        }

        public override void Draw()
        {
            if (mapa != null && mapa.visible) mapa.Draw();
            if (pl != null && pl.visible) pl.Draw();
            if (nemo != null && nemo.visible) nemo.Draw();
        }
    }


}
/// Minhas cores tem que virar uma Classe

