using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace TV_Соснина.Classes
{
    public class TV
    {
        private int activeChanell;

        private int activeVideo = 0;

        private DispatcherTimer timer;
        private MediaElement mediaElement;
        private Label nameChanell;


        public int ActiveChanell
        {
            get { return activeChanell; }
            set {
                if (activeChanell < AllChanells.Count - 1)
                    activeChanell = value;
                else
                    activeChanell = 0;

                if (activeChanell < 0)
                    activeChanell = AllChanells.Count - 1;
            }
        }
        
        public List<Chanell> AllChanells = new List<Chanell>();

        public TV()
        {
            Chanell ch1 = new Chanell() { Name = "Канал: Человек-паук" };
            ch1.Videos.Add(@"D:\3 курс\МДК 01.01 Ощепков\video6\Том.mp4");
            ch1.Videos.Add(@"D:\3 курс\МДК 01.01 Ощепков\video6\Тоби.mp4");
            ch1.Videos.Add(@"D:\3 курс\МДК 01.01 Ощепков\video6\Эндрю.mp4");
            AllChanells.Add(ch1);

            Chanell ch2 = new Chanell() { Name = "Канал: Гарри Поттер" };
            ch2.Videos.Add(@"D:\3 курс\МДК 01.01 Ощепков\video6\Гарри.mp4");
            ch2.Videos.Add(@"D:\3 курс\МДК 01.01 Ощепков\video6\Драко.mp4");
            ch2.Videos.Add(@"D:\3 курс\МДК 01.01 Ощепков\video6\Гермиона.mp4");
            AllChanells.Add(ch2);



            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(11);
            timer.Tick += TimerTick;
        }



        private void TimerTick(object sender, EventArgs e)
        {
            NextChanell(mediaElement, nameChanell);
        }

        public void StartTimer(MediaElement media, Label label)
        {
            mediaElement = media;
            nameChanell = label;
            //timer.Start();
        }




        public void SwapChanell (MediaElement mediaElement, Label nameChanell)
        {
            if (activeChanell >= AllChanells.Count)
                activeChanell = 0;
            if (activeChanell < 0)
                activeChanell = AllChanells.Count - 1;
            DoubleAnimation startAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            startAnimation.Completed += delegate
            {
                string videoPath = AllChanells[activeChanell].Videos[activeVideo];
                mediaElement.Source = new Uri(videoPath);
                mediaElement.Play();

                DoubleAnimation endAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.6)
                };
                mediaElement.BeginAnimation(MediaElement.OpacityProperty, endAnimation);
            };
            mediaElement.BeginAnimation(MediaElement.OpacityProperty, startAnimation);
            nameChanell.Content = AllChanells[activeChanell].Name;
        }

        public void NextChanell(MediaElement mediaElement, Label nameChanell)
        {
            activeChanell++;
            activeVideo = 0;
            SwapChanell(mediaElement, nameChanell);
        }
        public void BackChanell(MediaElement mediaElement, Label nameChanell)
        {
            activeChanell--;
            activeVideo = 0;
            SwapChanell(mediaElement, nameChanell);
        }


        public void GoChanell(int channelNumber, MediaElement mediaElement, Label nameChanell)
        {
            if (channelNumber >= 1 && channelNumber <= AllChanells.Count)
            {
                activeChanell = channelNumber - 1;
                activeVideo = 0;
                SwapChanell(mediaElement, nameChanell);
            }
        }

        public void NextVideo(MediaElement mediaElement, Label nameChanell)
        {
            activeVideo++;
            if(activeVideo >= AllChanells[activeChanell].Videos.Count)
                activeVideo = 0;
            SwapChanell(mediaElement, nameChanell);
        }

        public void BackVideo(MediaElement mediaElement, Label nameChanell)
        {
            activeVideo--;
            if (activeVideo < 0)
                activeVideo = AllChanells[activeChanell].Videos.Count - 1;
            SwapChanell(mediaElement, nameChanell);
        }

        public void UpSound()
        {

        }
        public void DownSound()
        {

        }
    }
}

