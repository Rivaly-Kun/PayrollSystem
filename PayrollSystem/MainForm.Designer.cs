using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO; // Required for MemoryStream

namespace PayrollSystem
{
    partial class MainForm
    {
        private Panel sidebar;
        private Panel header;
        private Panel contentPanel;
        private Panel summaryPanel;
        private Panel notificationsPanel;
        private ListView employeeList;
        private PictureBox logoBox;
        private Button btnDashboard, btnEmployees, btnSalary, btnTax, btnPayslip, btnLeave, btnSettings;
        private Label lblTotalEmployees, lblPayrollCost, lblPendingLeaves, lblTaxDeductions;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ✅ Set Form to Fullscreen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "Payroll Dashboard";

            // ✅ Sidebar Navigation Panel
            this.sidebar = new Panel
            {
                BackColor = Color.DarkSlateGray,
                Size = new Size(250, Screen.PrimaryScreen.Bounds.Height),
                Dock = DockStyle.Left
            };

            // ✅ Logo at the top of the sidebar
            logoBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(200, 100),
                Location = new Point(25, 20) // Centered horizontally
            };

            // Assign Image Separately (Fix for Syntax Issue)
            logoBox.Image = ByteArrayToImage(Properties.Resources.logo);
            sidebar.Controls.Add(logoBox);

            // Sidebar Buttons (Placed Below the Logo)
            btnDashboard = CreateSidebarButton("Dashboard", 140);
            btnEmployees = CreateSidebarButton("Employee Management", 190);
            btnSalary = CreateSidebarButton("Salary Calculation", 240);
            btnTax = CreateSidebarButton("Tax Management", 290);
            btnPayslip = CreateSidebarButton("Payslip Generation", 340);
            btnLeave = CreateSidebarButton("Leave Management", 390);
            btnSettings = CreateSidebarButton("Settings", 440);

            // Add buttons to sidebar
            sidebar.Controls.AddRange(new Control[] { btnDashboard, btnEmployees, btnSalary, btnTax, btnPayslip, btnLeave, btnSettings });

            // ✅ Header Panel
            this.header = new Panel
            {
                BackColor = Color.Teal,
                Height = 60,
                Dock = DockStyle.Top
            };

            // ✅ Summary Panel (Cards)
            this.summaryPanel = new Panel
            {
                Height = 120,
                Dock = DockStyle.Top,
                BackColor = Color.LightGray
            };

            lblTotalEmployees = CreateSummaryLabel("Total Employees: 0");
            lblPayrollCost = CreateSummaryLabel("Total Payroll Cost: $0.00");
            lblPendingLeaves = CreateSummaryLabel("Pending Leaves: 0");
            lblTaxDeductions = CreateSummaryLabel("Tax Deductions: $0.00");

            // Add summary labels
            summaryPanel.Controls.AddRange(new Control[] { lblTotalEmployees, lblPayrollCost, lblPendingLeaves, lblTaxDeductions });

            // ✅ Content Panel (Main Area)
            this.contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // ✅ Employee List Table
            employeeList = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true
            };
            employeeList.Columns.Add("ID", 50);
            employeeList.Columns.Add("Name", 150);
            employeeList.Columns.Add("Position", 150);
            employeeList.Columns.Add("Salary", 100);
            employeeList.Columns.Add("Status", 100);
            contentPanel.Controls.Add(employeeList);

            // ✅ Notifications Panel
            this.notificationsPanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 250,
                BackColor = Color.LightYellow
            };

            Label lblNotifications = new Label
            {
                Text = "🔔 Notifications",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Dock = DockStyle.Top
            };
            notificationsPanel.Controls.Add(lblNotifications);

            // ✅ Add controls to the form
            this.Controls.Add(contentPanel);
            this.Controls.Add(summaryPanel);
            this.Controls.Add(notificationsPanel);
            this.Controls.Add(header);
            this.Controls.Add(sidebar);

            this.ResumeLayout(false);
        }

        // ✅ Convert Byte Array to Image
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        // ✅ Helper method to create sidebar buttons
        private Button CreateSidebarButton(string text, int yPos)
        {
            return new Button
            {
                Text = text,
                Location = new Point(25, yPos),
                Width = 200,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.DarkSlateGray,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        // ✅ Helper method to create summary labels
        private Label CreateSummaryLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(200, 30),
                Margin = new Padding(20)
            };
        }
    }
}
