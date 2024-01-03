﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users) { str += "Login: " + user.login + " | "; }
            exampleText.Text = str;
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин слишком короткий!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length < 5)
            {
                passBox.ToolTip = "Пароль слишком короткий!";
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Пароли не совпадают!";
                passBox_2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
            {
                textBoxEmail.ToolTip = "Emeil неверный!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Всё хорошо!");

                User user = new User(login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}