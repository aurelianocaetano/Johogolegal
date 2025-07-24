using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohogoLegal
{
    internal class Mapa : MonoBehaviour
    {

        private static Mapa instancia { get; set; }

        private Mapa(){
        }

        public static Mapa Instancia => instancia ??= new Mapa();

        private int largura = 40;
        private int altura = 15;
        public char[,] mapa;





        public void DesenharMapa()  
        {

            mapa = new char[largura, altura];

            for (int y = 0; y < largura; y++)
            {
                for (int x = 0; x < altura; x++)
                {
                    if (y == 0 || y == altura - 1 || x == 0 || x == largura - 1)
                    {
                        mapa[x, y] = '#'; // Paredes do mapa
                    }
                    else
                    {
                        mapa[x, y] = ' '; // Espaços vazios
                    }
                }

                }
        }


        public override void UpDate()
        {
            DesenharMapa();
        }

        public virtual void Start() 
        
        {


            
        }



    }
}
