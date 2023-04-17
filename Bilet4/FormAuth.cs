using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet4
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            using (ConnectDB db = new ConnectDB())
            {
                DataTable users = db.ExecuteSql($"select * from [USERS] where login = '{login}' and password = '{password}'");

                if (users.Rows.Count > 0)
                {
                    User.Login = login;
                    FormMain Main = new FormMain();
                    Main.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль! Проверьте корректность введенных данных.");
                }
            }
        }
    }
}
