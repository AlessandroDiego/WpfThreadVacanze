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
using System.Threading;

namespace EsLadder
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        readonly Uri uriWrestler1 = new Uri("Wrestler 1.png", UriKind.Relative);
        readonly Uri uriWrestler2 = new Uri("Wrestler 2.png", UriKind.Relative);

        public int posWrestler1 = 100;
        public int posWrestler2 = 100;
        public MainWindow()
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(MuoviWrestler1));
            ImageSource imm1 = new BitmapImage(uriWrestler1);
            Wrestler_Sinistra.Source = imm1;

            Thread t2 = new Thread(new ThreadStart(MuoviWrestler2));
            ImageSource imm2 = new BitmapImage(uriWrestler2);
            Wrestler_Destra.Source = imm2;

            t2.Start();
            t1.Start();
        
        }

        public void MuoviWrestler1()
        {
            while (posWrestler1 < 300)
            {
                posWrestler1 += 50;
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Wrestler_Sinistra.Margin = new Thickness(201, posWrestler1, 0, 0);

                }));
            }
        }

        public void MuoviWrestler2()
        {
            while (posWrestler2 < 300)
            {
                posWrestler2 += 50;
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Wrestler_Destra.Margin = new Thickness(454, posWrestler2, 0, 0);

                }));
            }
        }
    }
}
