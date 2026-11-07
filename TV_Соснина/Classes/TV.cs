using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TV_Соснина.Classes
{
    public class TV
    {
        private int activeChanell;
        private int activeVolume;

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
            AllChanells.Add(new Chanell()
            {
                Name = "Эдит Том Холланд",
                Src = @"D:\3 курс\МДК 01.01 Ощепков\Том.mp4"
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Эдит Тоби Магуайр",
                Src = @"D:\3 курс\МДК 01.01 Ощепков\Тоби.mp4"
            });
            AllChanells.Add(new Chanell()
            {
                Name = "Эдит Эндрю Гарфилд",
                Src = @"D:\3 курс\МДК 01.01 Ощепков\Эндрю.mp4"
            });
        }

        public void SwapChanell (MediaElement mediaElement, Label nameChanell)
        {
            DoubleAnimation startAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            startAnimation.Completed += delegate
            {
                mediaElement.Source = new Uri(AllChanells[activeChanell].Src);
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
            SwapChanell(mediaElement, nameChanell);
        }
        public void BackChanell(MediaElement mediaElement, Label nameChanell)
        {
            activeChanell--;
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

