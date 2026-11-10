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

            TV.StartTimer(VideoPlayer, NameChannel);
        }

        private void BackChannel(object sender, RoutedEventArgs e) =>
            TV.BackChanell(VideoPlayer, NameChannel);

        private void NextChannel(object sender, RoutedEventArgs e) =>
            TV.NextChanell(VideoPlayer, NameChannel);

        private void GoTo(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ChannelNumber.Text, out int number))
            {
                TV.GoChanell(number, VideoPlayer, NameChannel);
            }
            else
            {
                MessageBox.Show("Введите номер канала числом!");
            }
        }

        private void BackProgramClick(object sender, RoutedEventArgs e) => 
            TV.BackVideo(VideoPlayer, NameChannel);

        private void NextProgramClick(object sender, RoutedEventArgs e) => 
            TV.NextVideo(VideoPlayer, NameChannel);
    }
}
