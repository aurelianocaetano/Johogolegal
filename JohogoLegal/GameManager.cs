using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    internal class GameManager
    {

      private GameManager() {}
        
        static private GameManager instance;

        static public GameManager Instance => instance ??= new GameManager();

        // Funções e atributos de gerenciamento do jogo

        public void StartGame()
        {
            // Lógica para iniciar o jogo
            Console.WriteLine("O jogo começou!");
        }
    }
}


