using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace JohogoLegal
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private GameManager()
        {
            
           // player = new Player();
            //gameStartTime = DateTime.UtcNow;

            // Registra informações atuais do sistema
            /*string currentTime = SystemInfo.GetFormattedDateTime();
            string user = SystemInfo.GetCurrentUser();
            TimeSpan uptime = SystemInfo.GetSystemUptime();

            Console.WriteLine($"Game initialized at: {currentTime}");
            Console.WriteLine($"Current user: {user}");
            Console.WriteLine($"System uptime: {uptime.ToString(@"hh\:mm\:ss")}");*/

            Run();
        }

        public static GameManager Instance => instance ??= new GameManager(); // Singleton instance


        private Menu menu;
        //private Player player;
        //private readonly DateTime gameStartTime;

        public override void Start()
        {
            Console.Clear();
           // Mapa.Instancia.Visible = true;
            
           // player.visible = true;

            menu = new Menu();
            menu.visible = true;
        }

        /*public TimeSpan GetGameTime()
        {
            return DateTime.UtcNow - gameStartTime;
        }*/

        public override void Update()
        {
            
            Draw(); 
        }

        public override void Draw()
        {
           if( menu != null && menu.visible) menu.Draw();
        }
    }
}