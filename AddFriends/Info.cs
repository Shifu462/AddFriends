using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows.Forms;
using VkNet;

namespace AddFriends
{
    public struct Info
    {
        public static int AppID { get; } = 0; // Your AppID.
        public static string AppSecret { get; } = ""; // Your AppSecret.

        public static string AccessToken { get; set; }
        public static string Code { get; set; }
        public static string Scope { get; } = "friends,users";
        public const int С = 2000000000; // Const for chats

        public static string Auth()
        {
            System.Diagnostics.Process.Start(
                  string.Format("http://api.vk.com/oauth/authorize?client_id={0}&scope={1}", Info.AppID, Info.Scope));

            new Code().ShowDialog();

            string lnkToken = string.Format("https://api.vk.com/oauth/access_token?client_id={0}&client_secret={1}&code={2}", 
                Info.AppID, Info.AppSecret, Info.Code);

            try
            {
                var webClient = new WebClient();
                string response = webClient.DownloadString(lnkToken);
                var jsonResponse = JsonConvert.DeserializeObject<VkJsonTokenResponse>(response);

                Info.AccessToken = jsonResponse.access_token;
                Program.VK.Authorize(new ApiAuthParams { AccessToken = Info.AccessToken });

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            if (!Program.VK.IsAuthorized)
            {
                MessageBox.Show("Ошибка! Попробуйте снова.");
                Application.Exit();
            }

            return Info.AccessToken;
        }



    }

    // Класс для десериализации ответа
    public class VkJsonTokenResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string user_id { get; set; }
    }
}
