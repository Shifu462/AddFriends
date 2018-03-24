using System;
using System.Windows.Forms;

namespace AddFriends
{
    public partial class Captcha : Form
    {
        public Captcha(string CaptchaUrl)
        {
            InitializeComponent();

            PictureCaptcha.ImageLocation = CaptchaUrl;
        }

        private void ButtonCaptcha_Click(object sender, EventArgs e)
        {
            Program.LastCaptcha = TextCaptcha.Text.Trim();
            this.Close();
        }

        private void TextCaptcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ButtonCaptcha_Click(this, new EventArgs());
        }
    }
}
