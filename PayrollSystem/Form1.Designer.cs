using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;

namespace PayrollSystem
{
    partial class Form1
    {
        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;

            // ✅ Set Form to Fullscreen
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Text = "Payroll";

            // ✅ Create Controls
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();

            SuspendLayout();

            // ✅ Username Label
            label1.AutoSize = true;
            label1.Text = "Username:";

            // ✅ Password Label
            label2.AutoSize = true;
            label2.Text = "Password:";

            // ✅ Username TextBox
            txtUsername.Size = new Size(200, 27);

            // ✅ Password TextBox
            txtPassword.Size = new Size(200, 27);
            txtPassword.PasswordChar = '*';

            // ✅ Login Button
            btnLogin.Size = new Size(100, 30);
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;

            // ✅ Add Controls to Form
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);

            // ✅ Center Controls Dynamically
            Resize += (sender, e) => CenterControls();

            ResumeLayout(false);
            PerformLayout();
        }

        // ✅ Function to Center Controls
        private void CenterControls()
        {
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 2;

            label1.Location = new Point(centerX - 150, centerY - 80);
            txtUsername.Location = new Point(centerX - 50, centerY - 80);

            label2.Location = new Point(centerX - 150, centerY - 40);
            txtPassword.Location = new Point(centerX - 50, centerY - 40);

            btnLogin.Location = new Point(centerX - 50, centerY + 10);
        }


        #endregion
    }
}
