using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Runtime.Serialization;

namespace JohogoLegal
{
     public class MonoBehaviour
    {

         private Thread t;

         private bool ativo = true;


        public void Run()
        {
            Awake();
            Start();

            t = new Thread(
                () =>
                {

                    while (ativo)
                    {


                        UpDate();
                        LateUpdate();
                        Thread.Sleep(800); // Simula o tempo de atualização

                    }

                    OnDestroy();
                }      
            );

            t.Start();
        }
            
       
         
           
          
            
            public void Stop()
        {
            this.ativo = false;
            t.Join(); // Aguarda a thread terminar
        }

        public virtual void Awake() {}
        public virtual void Start() { }
        public virtual void UpDate() { }
        public virtual void LateUpdate(){ }
        public virtual void OnDestroy() { }












    }
}
