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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Diagnostics;

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

        public int posVerticaleWrestler1 = 203;
        public int posVerticaleWrestler2 = 203;
        public int posOrizzontaleWrestler1 = 196;
        public int posOrizzontaleWrestler2 = 442;

        Random r1=new Random();
        Random r2 = new Random();
        public int giaVinto = 0;
        public MainWindow()
        {

            InitializeComponent();

            Thread t1 = new Thread(new ThreadStart(MuoviWrestler1));
            ImageSource imm1 = new BitmapImage(uriWrestler1);
            Wrestler_Sinistra.Source = imm1;

            Thread t2 = new Thread(new ThreadStart(MuoviWrestler2));
            ImageSource imm2 = new BitmapImage(uriWrestler2);
            Wrestler_Destra.Source = imm2;

            t1.Start();
            t2.Start();

           
        }

        public void MuoviWrestler1()
        {
            while (posVerticaleWrestler1 > 75)
            {
                posVerticaleWrestler1 -= r1.Next(1,5);
                posOrizzontaleWrestler1 += 1;
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Wrestler_Sinistra.Margin = new Thickness(posOrizzontaleWrestler1, posVerticaleWrestler1, 0, 0);

                }));
               
            }
            if (giaVinto == 0)
            {
                giaVinto = 1;
                MessageBox.Show("Ha vinto il Wrestler 1");
                
            }
           
        }

        public void MuoviWrestler2()
        {
            while (posVerticaleWrestler2 > 75)
            {
                posVerticaleWrestler2 -= r2.Next(1,5);
                posOrizzontaleWrestler2 -= 1;
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Wrestler_Destra.Margin = new Thickness(posOrizzontaleWrestler2, posVerticaleWrestler2, 0, 0);

                }));
               
            }
            if (giaVinto == 0)
            {
                giaVinto = 1;
                MessageBox.Show("Ha vinto il Wrestler 2");
                
            }
            
        }
    }
}
