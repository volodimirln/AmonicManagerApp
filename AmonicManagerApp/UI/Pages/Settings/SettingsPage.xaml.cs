﻿using AmonicManagerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmonicManagerApp.UI.Pages.Settings
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = StartViewModel.ViewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnActive_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInActive_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
