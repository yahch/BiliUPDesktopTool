﻿using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BiliUPDesktopTool
{
    internal class Update : INotifyPropertyChanged
    {
        #region Private Fields

        private bool _IsFinished;
        private string _Status;
        private string _UpdateText;
        private UpdateWindow uw;

        #endregion Private Fields

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// 是否已完成
        /// </summary>
        public bool IsFinished
        {
            get { return _IsFinished; }
            set
            {
                _IsFinished = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFinished"));
            }
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        public string Status
        {
            get { return "状态：" + _Status; }
            set
            {
                _Status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }

        /// <summary>
        /// 更新内容
        /// </summary>
        public string UpdateText
        {
            get { return _UpdateText; }
            private set
            {
                _UpdateText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpdateText"));
            }
        }

        #endregion Public Properties

        #region Private Properties

        private JObject jobj { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void CheckUpdate(bool IsGUI = true)
        {
            IsFinished = false;
            string str = Bas.GetHTTPBody("https://cloud.api.zhangbudademao.com/117/Update");
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    jobj = JObject.Parse(str);

                    if ((int)jobj["code"] == 0)
                    {
                        if (jobj["data"]["version"].ToString() == System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString())
                        {
                            if (IsGUI) MessageBox.Show("当前版本已是最新");
                            return;
                        }
                        else
                        {
                            if (IsGUI)
                            {
                                UpdateText = "当前版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\r\n最新版本：" + jobj["data"]["version"].ToString() + "(" + jobj["data"]["updatetime"].ToString() + "更新)\r\n\r\n更新内容：\r\n" + jobj["data"]["content"].ToString();
                                uw = (uw == null || uw.IsVisible == false) ? new UpdateWindow() : uw;
                                uw.Show();
                            }
                            else
                            {
                                Bas.notifyIcon.ShowToolTip("检查到新版本！请通过“检查更新”屏幕更新。");
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public void DoUpdate()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\");

            WebClient Downloader = new WebClient();
            Downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
            Downloader.DownloadFileCompleted += Downloader_DownloadFileCompleted;
            Downloader.DownloadFileAsync(new Uri(jobj["data"]["url"].ToString()), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\update.zip");
        }

        #endregion Public Methods

        #region Private Methods

        private void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Status = "正在校验...";
            if (Bas.GetFileHash(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\update.zip") == jobj["data"]["hash"].ToString())
            {
                Status = "正在解压...";
                if (Bas.UnZip(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\update.zip", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\UpdateTemp\\", ""))
                {
                    Status = "正在安装...";
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\update.zip");
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\update.bat", "@echo off\r\n" +
                                    "choice /t 5 /d y /n >nul\r\n" +                                                                                   //等待5s开始
                                    "xcopy \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\UpdateTemp" + "\" \"" + Application.StartupPath + "\" /s /e /y\r\n" +     //覆盖程序
                                    "rmdir /s /q \"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\UpdateTemp\\" + "\"\r\n" +                                                //删除更新缓存
                                    "start \"\" \"" + Application.ExecutablePath + "\"\r\n" +                                                                     //启动程序
                                    "del %0", Encoding.Default);
                    Process p = new Process();
                    p.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\zhangbudademao.com\\BiliUPDesktopTool\\update.bat";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.Verb = "runas";//管理员启动
                    p.Start();
                    Environment.Exit(2);
                }
            }
            else
            {
                MessageBox.Show("校验错误，请稍后再试！");
                IsFinished = true;
            }
        }

        private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Status = "正在下载（" + e.ProgressPercentage + "%)...";
        }

        #endregion Private Methods
    }
}