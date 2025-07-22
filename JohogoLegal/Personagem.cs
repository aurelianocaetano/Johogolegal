using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    class Personagem
    {
        public List<string> cores = new List<string> { "vermelho", "azul", "verde" };
        public List<ConsoleColor> caixa = new List<ConsoleColor>();
        public string nome = "";
        public string escolhaUsuario = "";
        public Random rand = new Random();

        public Personagem()
        {
            PreencherCores();
        }

        private void PreencherCores()
        {
            caixa.Add(ConsoleColor.Red);
            caixa.Add(ConsoleColor.Blue);
            caixa.Add(ConsoleColor.Green);
        }

        public string SortearCor()
        {
            return cores[rand.Next(cores.Count)];
        }

        // Função nova: sorteia e retorna nome + cor visual
        public (string nome, ConsoleColor visual) SortearCorComVisual()
        {
            int index = rand.Next(cores.Count);
            return (cores[index], caixa[index]);
        }

        public bool EscolhaValida()
        {
            return cores.Contains(escolhaUsuario);
        }

        public bool Acertou(string corSorteada)
        {
            return escolhaUsuario == corSorteada;
        }

        public ConsoleColor ObterCorVisual(string corNome)
        {
            int index = cores.IndexOf(corNome);
            if (index >= 0 && index < caixa.Count)
                return caixa[index];
            return ConsoleColor.White;
        }
    }

}
/// Minhas cores tem que virar uma Classe

