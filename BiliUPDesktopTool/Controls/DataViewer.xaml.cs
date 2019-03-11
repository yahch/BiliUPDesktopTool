﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BiliUPDesktopTool
{
    /// <summary>
    /// DataViewer.xaml 的交互逻辑
    /// </summary>
    public partial class DataViewer : UserControl
    {
        #region Public Constructors

        public DataViewer()
        {
            InitializeComponent();

            BindingInit();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// 初始化绑定
        /// </summary>
        private void BindingInit()
        {
            Binding bind_datatitle_color = new Binding()
            {
                Source = Bas.skin,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath("DesktopWnd_FontColor")
            };
            DataTitle.SetBinding(ForegroundProperty, bind_datatitle_color);
            DataNum.SetBinding(ForegroundProperty, bind_datatitle_color);
            DataIncr.SetBinding(ForegroundProperty, bind_datatitle_color);
        }

        #endregion Private Methods
    }
}