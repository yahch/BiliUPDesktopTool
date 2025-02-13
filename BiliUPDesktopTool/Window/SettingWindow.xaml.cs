﻿using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BiliUPDesktopTool
{
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : Window
    {
        #region Private Fields

        private DesktopWindowSetter dws;

        #endregion Private Fields

        #region Public Constructors

        public SettingWindow()
        {
            InitializeComponent();

            setBinding();
        }

        #endregion Public Constructors

        #region Private Methods

        private void BTN_AutoRun_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (key != null && key.GetValue("BiliUPDesktopTool") != null)
            {
                key.DeleteValue("BiliUPDesktopTool");
            }
            else
            {
                key.SetValue("BiliUPDesktopTool", "\"" + Process.GetCurrentProcess().MainModule.FileName + "\" -s");
            }
            SetAutoRunShow();
        }

        private void BTN_SetDesktopWndPos_Click(object sender, RoutedEventArgs e)
        {
            dws = (dws == null || dws.IsVisible == false) ? new DesktopWindowSetter() : dws;
            dws.Show();
        }

        private void SetAutoRunShow()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (key != null && key.GetValue("BiliUPDesktopTool") != null)
            {
                BTN_AutoRun.Content = "取消开机启动";
            }
            else
            {
                BTN_AutoRun.Content = "设置为开机启动";
            }
        }

        private void setBinding()
        {
            Binding bindAutoCheckUpdate = new Binding()
            {
                Source = Bas.settings,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath("IsAutoCheckUpdate")
            };
            CB_IsAutoCheckUpdate.SetBinding(CheckBox.IsCheckedProperty, bindAutoCheckUpdate);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetAutoRunShow();
        }

        #endregion Private Methods
    }
}