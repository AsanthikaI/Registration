using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Registration
{
    public partial class Form1 : Form
    {
        private string _dbFile = Path.Combine(
            Application.StartupPath,// gives you the exe location (bin\Debug\) folder
            "Users", // folder name
            "users.txt"); // file name


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User(textBox1.Text, textBox2.Text, textBox3.Text);

                bool ok = user.Register(_dbFile);

                if (ok)
                {
                    MessageBox.Show("Registered successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Please fill all fields.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing file:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
