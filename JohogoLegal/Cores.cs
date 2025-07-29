using System;
using System.Collections.Generic;
using System.Linq;

namespace JohogoLegal
{
    public class Cores
    {
        private readonly Dictionary<string, ConsoleColor> mappedColors;

        public Cores()
        {
            mappedColors = new Dictionary<string, ConsoleColor>
            {
                { "vermelho", ConsoleColor.Red},
                { "azul", ConsoleColor.Blue},
                { "verde", ConsoleColor.Green}
            };
        }

        public List<string> ObterNomesCores() => mappedColors.Keys.ToList(); // Método para obter os nomes das cores disponíveis

        public ConsoleColor ObterCorVisual(string corNome) // Método para obter a cor visual correspondente ao nome da cor
        {
            return mappedColors.TryGetValue(corNome.ToLower(), out ConsoleColor cor) // Tenta obter a cor correspondente ao nome fornecido
                ? cor // Se a cor existir, retorna a cor correspondente
                : ConsoleColor.White; // Se a cor não existir, retorna branco como padrão
        }

        public bool CorExiste(string corNome) // Método para verificar se uma cor existe na lista de cores disponíveis
        {
            return mappedColors.ContainsKey(corNome.ToLower()); // Verifica se o dicionário contém a chave correspondente ao nome da cor fornecido
        }
    }
}