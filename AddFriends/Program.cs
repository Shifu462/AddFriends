using System;
using System.Windows.Forms;
using VkNet;

namespace AddFriends
{
    static class Program
    {
        public static VkApi VK = new VkApi();

        public static long?  LastCaptchaSid { get; set; }  = null;
        public static string LastCaptchaUri { get; set; } = null;
        public static string LastCaptcha { get; set; }    = null;
        
        public static void ClearCaptchaInfo()
        {
            LastCaptchaSid = null;
            LastCaptchaUri = null;
            LastCaptcha    = null;
        }

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
