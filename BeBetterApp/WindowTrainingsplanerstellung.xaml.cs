﻿using System;
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
using System.Windows.Shapes;

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for WindowTrainingsplanerstellung.xaml
    /// </summary>
    public partial class WindowTrainingsplanerstellung : Window
    {
        public WindowTrainingsplanerstellung()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            KIKlasse kI = new KIKlasse();
            kI.Ki(Ausgabe);

        }
    }
}
