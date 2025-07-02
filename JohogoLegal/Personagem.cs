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


        List<ConsoleColor> caixa = new List<ConsoleColor>();// Lista de cores do jogo  


        update()
        {



            caixa.Add(ConsoleColor.Red);
            caixa.Add(ConsoleColor.Blue);
            caixa.Add(ConsoleColor.Green);
            
        }

        
        public string[] cores = { "vermelho", "azul", "verde" };  // Variáveis jogo das cores

        // Variável de randomização
        public Random rand = new Random(); 
        
        public string escolhaUsuario = ""; // Variável de escolha do usuário
       
        public string nome = ""; // Variável de nome do usuário



        public Personagem() 
        {
            

        }
    }
}


/// Minhas cores tem que virar uma Classe