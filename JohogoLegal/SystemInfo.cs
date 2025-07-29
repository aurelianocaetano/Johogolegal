using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading;

namespace JohogoLegal
{
    public static class SystemInfo
    {
        // Constantes para formato de data e hora
        private const string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss"; // Formato de data e hora UTC

        // Armazena informações do sistema
        private static readonly DateTime SystemStartTime = DateTime.UtcNow; // Hora de início do sistema (UTC)
        private static readonly string CurrentUser = "aurelianocaetano"; // Usuário atual do sistema (pode ser dinâmico se necessário)

        // Métodos para obter informações do sistema
        public static string GetFormattedDateTime()
        {
            return DateTime.UtcNow.ToString(DATE_TIME_FORMAT); // Formata a data e hora atual em UTC
        }

        public static string GetCurrentUser()  //   Método para obter o usuário atual do sistema
        {
            return CurrentUser; // Retorna o usuário atual do sistema
        }

        public static TimeSpan GetSystemUptime() // Método para obter o tempo de atividade do sistema
        {
            return DateTime.UtcNow - SystemStartTime;  // Calcula o tempo de atividade subtraindo o tempo de início do sistema da data e hora atual em UTC
        }

        // Método para exibir todas as informações do sistema
        public static void LogSystemInfo()  // Método para registrar informações do sistema
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=== System Information ===");
            Console.WriteLine($"Current Date and Time (UTC): {GetFormattedDateTime()}");
            Console.WriteLine($"Current User's Login: {GetCurrentUser()}");
            Console.WriteLine($"System Uptime: {GetSystemUptime().ToString(@"hh\:mm\:ss")}");
            Console.WriteLine("=======================");

            Console.ResetColor();
            Thread.Sleep(2000); // Mostra as informações por 2 segundos
        }

        // Método para registrar início de sessão
        public static void LogSessionStart() // Método para registrar o início de uma sessão
        {
            string currentTime = GetFormattedDateTime();  // Obtém a data e hora atual formatada
            string user = GetCurrentUser();  // Obtém o usuário atual do sistema
            TimeSpan uptime = GetSystemUptime();  // Obtém o tempo de atividade do sistema

            Console.WriteLine("\n=== Session Started ===");  // Exibe mensagem de início de sessão
            Console.WriteLine($"Time: {currentTime}"); // Exibe a data e hora atual
            Console.WriteLine($"User: {user}"); // Exibe o usuário atual
            Console.WriteLine($"System Uptime: {uptime.ToString(@"hh\:mm\:ss")}"); // Exibe o tempo de atividade do sistema
            Console.WriteLine("====================\n"); // Exibe linha de separação
        }

        // Método para registrar fim de sessão
        public static void LogSessionEnd()
        {
            string currentTime = GetFormattedDateTime();
            TimeSpan uptime = GetSystemUptime();

            Console.WriteLine("\n=== Session Ended ===");
            Console.WriteLine($"Time: {currentTime}");
            Console.WriteLine($"Total Duration: {uptime.ToString(@"hh\:mm\:ss")}");
            Console.WriteLine("==================\n");
        }
    }
}