﻿using System;
using System.Threading;
using System.Windows;

namespace BiliUPDesktopTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Fields

        private int i;

        #endregion Private Fields

        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();

            
        }

        #endregion Public Constructors

        #region Private Methods

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //num1.ChangeNum(i++);
            nums1.ChangeNum(1234.56);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide();
            DesktopWindow dw = new DesktopWindow();
            dw.Show();
            //DesktopWindowSetter dws = new DesktopWindowSetter();
            //dws.Show();
            Thread t = new Thread(DesktopWnd_Monitor);
            t.Start(dw);
            //LoginWindow lw = new LoginWindow();
            //lw.ShowDialog();
            //DesktopEmbeddedWindowHelper.DesktopEmbedWindow(this);
        }

        private void DesktopWnd_Monitor(object e)
        {
            DesktopWindow dw = e as DesktopWindow;

            while (true)
            {
                if(dw == null || !dw.IsVisible)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        dw = new DesktopWindow();
                        dw.Show();
                    });
                }
            }
        }

        #endregion Private Methods
    }
}