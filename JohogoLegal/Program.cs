

using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;





namespace JohogoLegal
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "Batatatola";
            Console.CursorVisible = false;

            // Exibe informações do sistema ao iniciar
            /*SystemInfo.LogSystemInfo();
            SystemInfo.LogSessionStart();
            
            Console.WriteLine("\nPressione qualquer tecla para começar...");
            Console.ReadKey(true);*/
            Console.Clear();

            GameManager gm =  GameManager.Instance; // Obtém a instância do GameManager

        }
    }
}