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

namespace TV_Соснина
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();

        public MainWindow()
        {
            InitializeComponent();

            VideoPlayer.Source = new Uri(TV.AllChanells[0].Src);
            VideoPlayer.Play();
        }

        private void BackChannel(object sender, RoutedEventArgs e) =>
            TV.BackChanell(VideoPlayer, NameChannel);

        private void NextChannel(object sender, RoutedEventArgs e) =>
            TV.NextChanell(VideoPlayer, NameChannel);
    }
}
