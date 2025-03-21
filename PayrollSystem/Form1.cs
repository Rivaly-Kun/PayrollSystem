using System.Data.SQLite;

namespace PayrollSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         Admin pass ni:
            Username: 'admin', Pass: '1234'
        */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                MainForm dashboard = new MainForm();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            string dbPath = @"C:\Users\gabri\source\repos\AdmissionSys\AdmissionSys\admission.db";
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file NOT found at: " + dbPath);
                return false;
            }


            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
