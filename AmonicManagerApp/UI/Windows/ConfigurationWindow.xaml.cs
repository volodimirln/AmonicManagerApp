using AmonicManagerApp.Data;
using AmonicManagerApp.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        private string path;
        public ConfigurationWindow()
        {
            InitializeComponent();
            this.path = Configuration.path;
            if (File.Exists(path + "\\client.config"))
            {
                try
                {
                    Repository.SaveRepository();
                    AuthWindow window = new AuthWindow();
                    this.Close();
                    window.Show();
                }
                catch
                {
                    AuthWindow window = new AuthWindow();
                    this.Close();
                    window.Show();
                }
                   

                    
                
               
               
            }
    }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!File.Exists(path + "\\client.config"))
                {
                    File.Create(path + "\\client.config").Close();

                    using (FileStream fileStream = new FileStream(path + "\\client.config", FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            if (!string.IsNullOrEmpty(tbxServer.Text) && !string.IsNullOrEmpty(tbxUser.Text) && !string.IsNullOrEmpty(tbxPassword.Text))
                            {
                                writer.Write($"Server={tbxServer.Text};User={tbxUser.Text};Password={tbxPassword.Text}");
                                writer.Close();
                            }
                            if (string.IsNullOrEmpty(tbxUser.Text) && string.IsNullOrEmpty(tbxPassword.Text))
                            {
                                writer.Write($"Server={tbxServer.Text};Trusted_Connection=True; MultipleActiveResultSets=true");
                                writer.Close();
                                MessageBox.Show("Подключение через Windows authentication");
                            }
                            if (string.IsNullOrEmpty(tbxServer.Text) && string.IsNullOrEmpty(tbxUser.Text) && string.IsNullOrEmpty(tbxPassword.Text))
                            {
                                MessageBox.Show("Заполнены не все поля");
                            }
                        }
                    }
                    Repository.SaveRepository();
                    AuthWindow window = new AuthWindow();
                    this.Close();
                    window.Show();
                }
               
               
            }
            catch { }
        }
    }
}
