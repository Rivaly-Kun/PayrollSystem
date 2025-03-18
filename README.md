# PayrollSystem

📌 Features

🔹❌ Employee Management ➝ Add, update, and remove employee records.

🔹❌ Salary Calculation ➝ Compute salaries based on hours worked, overtime, and deductions.

🔹❌ Tax Management ➝ Automatically calculate and deduct taxes.

🔹❌ Payslip Generation ➝ Generate and print payslips for employees.

🔹❌ Leave Management ➝ Track employee leave and absences.

🔹✅ Login System ➝ Secure authentication for users.

📌 How to Set Up the Project in Visual Studio

1️⃣ Clone the Repository

Open Visual Studio.
Go to File > Clone Repository.
Enter the repository URL and choose a local directory.

2️⃣ Install SQLite in NuGet Package Manager

Open Tools > NuGet Package Manager > Manage NuGet Packages for Solution.

Search for System.Data.SQLite and install it.

Or use the Package Manager Console:

Install-Package System.Data.SQLite

3️⃣ Ensure the Database File Exists

The database file (payroll.db) should be inside the project folder.

If it's missing, create an SQLite database using sqlite3 and add necessary tables.

4️⃣ Update the Database Connection Path

Make sure the connection string in your C# code points to the correct location:

string dbPath = @"C:\Path\To\payroll.db"; // Update this to your actual path

string connectionString = $"Data Source={dbPath};Version=3;";

5️⃣ Build and Run the Project

Press Ctrl + Shift + B to build the solution.

Click Start (F5) to run the application.

