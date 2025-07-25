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
    public abstract class MonoBehaviour
    {
        private Thread t;            // Thread que mantém o ciclo de vida
        private bool ativo = true;  // Controla se o loop deve continuar
        public bool input = false;


        // public bool visible = false;  // Marcius
        // public bool input = false; // Marcius

        // Inicia o ciclo de vida do objeto
        public void Run()
        {
            Awake(); // Antes da thread começar
            Start(); // Inicialização do objeto

            t = new Thread(() =>
            {
                while (ativo)
                {
                    UpDate();       // Atualização principal
                    LateUpdate();   // Atualização complementar
                    Thread.Sleep(800); // Intervalo de "frame"
                }

                OnDestroy(); // Finalização
            });

            t.Start();
        }

        // Encerra o ciclo
        public void Stop()
        {
            this.ativo = false;
            t.Join(); // Aguarda a thread encerrar
        }

        // Métodos virtuais que podem ser sobrescritos nas subclasses

        public virtual void Awake() { }         // Chamado antes do Start
        public virtual void Start() { }         // Inicialização
        public virtual void Update() { }        // Chamado em cada ciclo
        public virtual void LateUpdate() { }    // Após o Update
        public virtual void OnDestroy() { }     // Encerramento do ciclo

        public abstract void Draw();  // Marcius  mandou colocar


    }


}
