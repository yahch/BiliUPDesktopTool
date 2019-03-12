﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace BiliUPDesktopTool
{
    /// <summary>
    /// DataViewerPanel.xaml 的交互逻辑
    /// </summary>
    public partial class DataViewerPanel : UserControl
    {
        #region Public Constructors

        public DataViewerPanel()
        {
            InitializeComponent();

            BindingInit();

            //初始化数据
            ChangeView();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// 更新展示
        /// </summary>
        public void ChangeView()
        {
            DataViewer[] viewers = new DataViewer[4] { ViewerLT, ViewerRT, ViewerLB, ViewerRB };
            for (int i = 0; i < viewers.Length; i++)
            {
                Binding binding_num, binding_incr;
                viewers[i].Title = GetDataTile(Bas.settings.DataViewSelected[i]);
                switch (Bas.settings.DataViewSelected[i][0])
                {
                    case "video":
                        binding_num = new Binding()
                        {
                            Source = Bas.biliupdata.video,
                            Mode = BindingMode.TwoWay,
                            Path = new PropertyPath(Bas.settings.DataViewSelected[i][1])
                        };
                        binding_incr = new Binding()
                        {
                            Source = Bas.biliupdata.video,
                            Mode = BindingMode.TwoWay,
                            Path = new PropertyPath(Bas.settings.DataViewSelected[i][2])
                        };
                        BindingOperations.SetBinding(viewers[i].num, RollingNums.numProperty, binding_num);
                        BindingOperations.SetBinding(viewers[i].incr, RollingNums.numProperty, binding_incr);
                        break;

                    case "article":
                        binding_num = new Binding()
                        {
                            Source = Bas.biliupdata.article,
                            Mode = BindingMode.TwoWay,
                            Path = new PropertyPath(Bas.settings.DataViewSelected[i][1])
                        };
                        binding_incr = new Binding()
                        {
                            Source = Bas.biliupdata.article,
                            Mode = BindingMode.TwoWay,
                            Path = new PropertyPath(Bas.settings.DataViewSelected[i][2])
                        };
                        BindingOperations.SetBinding(viewers[i].num, RollingNums.numProperty, binding_num);
                        BindingOperations.SetBinding(viewers[i].incr, RollingNums.numProperty, binding_incr);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// 初始化绑定
        /// </summary>
        private void BindingInit()
        {
            Binding bind_R_color = new Binding()
            {
                Source = Bas.skin,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath("DesktopWnd_FontColor")
            };
            BindingOperations.SetBinding(Rx, Shape.StrokeProperty, bind_R_color);
            BindingOperations.SetBinding(Ry, Shape.StrokeProperty, bind_R_color);
        }

        /// <summary>
        /// 获取数据标题
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private string GetDataTile(string[] v)
        {
            string title = "";
            switch (v[0])
            {
                case "video":
                    title += "视频";
                    break;

                case "article":
                    title += "专栏";
                    break;

                default:
                    break;
            }

            switch (v[1])
            {
                case "coin":
                    title += "硬币";
                    break;

                case "fav":
                    title += "收藏";
                    break;

                case "like":
                    title += "点赞";
                    break;

                case "reply":
                case "comment":
                    title += "评论";
                    break;

                case "share":
                    title += "分享";
                    break;

                case "view":
                    title += "点击";
                    break;

                case "dm":
                    title += "弹幕";
                    break;

                case "elec":
                    title = "电池";
                    break;

                case "fan":
                    title = "粉丝";
                    break;

                case "growup":
                    title = "创作激励";
                    break;

                case "play":
                    title += "播放";
                    break;

                default:
                    break;
            }
            return title;
        }

        #endregion Private Methods
    }
}