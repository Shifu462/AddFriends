using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VkNet.Exception;

namespace AddFriends
{
    public partial class Main : Form
    {
        public Main() => InitializeComponent();

        private async void ButtonAdd_Click(object sender, EventArgs e)
        {
            // List of IDs or Domains.
            var FriendsList = TextFriendsList.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(p => p.Trim().Split('/').Last());

            var Users = Program.VK.Users.Get(FriendsList);

            /*
            var Users = await Program.VK.Groups.GetMembersAsync(new GroupsGetMembersParams
            {
                Count = 100,
                GroupId = "dayvinchik"
            });
            */

            var count = 0;
            var error = 0;
            foreach (var user in Users)
            {
                try
                {
                    await Program.VK.Friends.AddAsync(user.Id);
                    count++;
                }
                catch (CaptchaNeededException captcha)
                {
                    new Captcha(captcha.Img.AbsoluteUri).ShowDialog();
                    await Program.VK.Friends.AddAsync(user.Id, captchaSid:captcha.Sid, captchaKey:Program.LastCaptcha);
                    Program.LastCaptcha = "";
                    count++;
                }
                catch (Exception ex)
                {
                    error++;
                }

                ButtonAdd.Text = $"Добавлено: {count}/{Users.Count} | Пропущено: {error}";
            }
                
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Info.Auth();
        }
    }
}
