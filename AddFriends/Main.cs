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

            var count = 0;
            var error = 0;
            foreach (var user in Users)
            {
                while (true)
                {
                    try
                    {
                        await Program.VK.Friends.AddAsync(user.Id, captchaSid: Program.LastCaptchaSid, 
                            captchaKey: Program.LastCaptcha);

                        Program.ClearCaptchaInfo();
                        count++;
                        break;
                    }
                    catch (CaptchaNeededException captcha)
                    {
                        Program.LastCaptchaSid = captcha.Sid;
                        Program.LastCaptchaUri = captcha.Img.AbsoluteUri;

                        // Program.LastCaptcha = Form Result;
                        using (var captchaForm = new Captcha(captcha.Img.AbsoluteUri))
                            captchaForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        error++;
                    }
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
