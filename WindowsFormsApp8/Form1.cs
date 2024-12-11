using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        string email_Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        string password_Pattern = @"\d{8}";

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // проверка авторизации, правильно ли  введен логин и пароль,если нет то выводит ошибку попробуйте еще раз.
        {
            string log = textBox1.Text;
            string pass = textBox2.Text;
            Match k = Regex.Match(log, email_Pattern);
            Match f = Regex.Match(pass, password_Pattern);
            Form2 fr2 = new Form2();

            if (k.Success && f.Success)
            {
                fr2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный! Введите еще раз....");
            }
        }
    }
}
