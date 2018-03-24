using System;
using System.Windows.Forms;
using VkNet;

namespace AddFriends
{
    static class Program
    {
        public static VkApi VK = new VkApi();
        public static string LastCaptcha { get; set; } = "";
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
