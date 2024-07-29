using AmonicManagerApp.Data;
using AmonicManagerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AmonicManagerApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public static string CreateMD5(string s)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(pbxPassword.Password) && !string.IsNullOrEmpty(tbxLogin.Text)) {
                    User user = Model.GetContext().Users.FirstOrDefault(p => p.Login == tbxLogin.Text);
                    if (user != null)
                    {

                    
                       Password  password = user.Passwords.FirstOrDefault(p => p.Active == true && p.HashPassword == CreateMD5("6ZhM60" + pbxPassword.Password));

                        if (password != null)
                        {
                            StartViewModel.ViewModel.User = user;
                            if (user.RoleId != 2)
                            {
                                MessageBox.Show("Добро пожаловать, " + user.Name + " " + user.Patronymic + " (" + user.Role.Title + ")");
                                HomeWindow homeWindow = new HomeWindow();
                                homeWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Недостаточно прав для доступа");
                            }
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Указаны неверные пароль или логин");
                    }
                }
                else
                {
                    MessageBox.Show("Указаны не все данные");
                }
            
            }catch (Exception ex) { MessageBox.Show("Ошибка"); }
        }
    }
}
