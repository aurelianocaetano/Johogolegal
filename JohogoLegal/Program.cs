

using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace JohogoLegal
{

    public class Program: MonoBehaviour
    {

        static void Main()
        {
            GameManager.Instance.StartGame();
      
        
        }

        public override void Draw()
        {
            if (mapa != null && mapa.visible) mapa.Draw();
            if (pl != null && pl.visible) pl.Draw();
            if (nemo != null && nemo.visible) nemo.Draw();
        }
    }



}
