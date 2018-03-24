using System;
using System.Windows.Forms;

namespace AddFriends
{
    public partial class Code : Form
    {
        public Code()
        {
            InitializeComponent();
        }

        private void ButtonCode_Click(object sender, EventArgs e)
        {
            string Code;

            try
            {
                Code = TextCode.Text.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверьте правильность введённых данных. \n\n(Ошибка:{ex.Message})");
                Application.Exit();
                return;
            }

            Info.Code = Code;
            this.Close();
        }

        private void TextCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ButtonCode_Click(this, new EventArgs());
        }
    }
}
