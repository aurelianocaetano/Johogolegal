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
        private Thread t;
        private bool ativo = true;
        public bool input = false;
        protected Mapa mapa;
        protected Player pl;
        protected Menu nemo;

        // Adicionando informações de sistema
        protected readonly string currentUser;
        protected readonly DateTime startTime;

        public MonoBehaviour()
        {
            // Inicializa as informações do sistema
            currentUser = "aurelianocaetano"; // Você pode tornar isso dinâmico se necessário
            startTime = DateTime.UtcNow;
        }

        public virtual void Initialize()
        {
            mapa = Mapa.Instancia;
            pl = new Player();
            nemo = new Menu();
            LogInitialization();
        }

        private void LogInitialization()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Initialized at: {startTime:yyyy-MM-dd HH:mm:ss} UTC");
            Console.WriteLine($"User: {currentUser}");
            Console.ResetColor();
            Thread.Sleep(1000); // Mostra a informação por 1 segundo
        }

        public void Run()
        {
            
            Awake();
            Start();

            t = new Thread(() =>
            {
                while (ativo)
                {
                    Update();
                    LateUpdate();
                    Thread.Sleep(800);
                }
                OnDestroy();
            });

            t.Start();
        }

        public void Stop()
        {
            this.ativo = false;
            t?.Join();
        }

        // Métodos para obter informações do sistema
        protected string GetCurrentDateTime()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected string GetCurrentUser()
        {
            return currentUser;
        }

        protected TimeSpan GetUptime()
        {
            return DateTime.UtcNow - startTime;
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }

        public virtual void OnDestroy()
        {
            Console.WriteLine($"Session ended at: {GetCurrentDateTime()}");
            Console.WriteLine($"Total uptime: {GetUptime().ToString(@"hh\:mm\:ss")}");
        }

        public abstract void Draw();
    }
}