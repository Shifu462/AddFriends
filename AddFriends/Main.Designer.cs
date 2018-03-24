namespace AddFriends
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextFriendsList = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextFriendsList
            // 
            this.TextFriendsList.Location = new System.Drawing.Point(12, 12);
            this.TextFriendsList.Multiline = true;
            this.TextFriendsList.Name = "TextFriendsList";
            this.TextFriendsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextFriendsList.Size = new System.Drawing.Size(355, 413);
            this.TextFriendsList.TabIndex = 0;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonAdd.Location = new System.Drawing.Point(12, 431);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(355, 32);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "Добавить всех!";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 475);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.TextFriendsList);
            this.Name = "Main";
            this.Text = "Добавить друзей";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextFriendsList;
        private System.Windows.Forms.Button ButtonAdd;
    }
}

