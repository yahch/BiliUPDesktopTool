﻿using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace BiliUPDesktopTool
{
    /// <summary>
    /// B站UP主数据
    /// </summary>
    internal class BiliUPData
    {
        #region Public Fields

        /// <summary>
        /// 专栏数据
        /// </summary>
        public Article article;

        /// <summary>
        /// 视频数据
        /// </summary>
        public Video video;

        #endregion Public Fields

        #region Public Constructors

        /// <summary>
        /// 初始化up主数据
        /// </summary>
        public BiliUPData()
        {
            article = new Article();
            video = new Video();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <returns>刷新后的实例</returns>
        public BiliUPData Refresh()
        {
            article.Refresh();
            video.Refresh();
            return this;
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// 专栏类
        /// </summary>
        public class Article : INotifyPropertyChanged
        {
            #region Public Constructors

            /// <summary>
            /// 初始化专栏数据
            /// </summary>
            public Article()
            {
                Refresh();
            }

            #endregion Public Constructors

            #region Public Events

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion Public Events

            #region Public Properties

            /// <summary>
            /// 硬币
            /// </summary>
            public int coin { get; private set; }

            /// <summary>
            /// 硬币增量
            /// </summary>
            public int coin_incr { get; private set; }

            /// <summary>
            /// 收藏
            /// </summary>
            public int fav { get; private set; }

            /// <summary>
            /// 收藏增量
            /// </summary>
            public int fav_incr { get; private set; }

            /// <summary>
            /// 点赞
            /// </summary>
            public int like { get; private set; }

            /// <summary>
            /// 点赞增量
            /// </summary>
            public int like_incr { get; private set; }

            /// <summary>
            /// 评论
            /// </summary>
            public int reply { get; private set; }

            /// <summary>
            /// 评论增量
            /// </summary>
            public int reply_incr { get; private set; }

            /// <summary>
            /// 分享
            /// </summary>
            public int share { get; private set; }

            /// <summary>
            /// 分享增量
            /// </summary>
            public int share_incr { get; private set; }

            /// <summary>
            /// 点击
            /// </summary>
            public int view { get; private set; }

            /// <summary>
            /// 点击增量
            /// </summary>
            public int view_incr { get; private set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// 刷新数据
            /// </summary>
            /// <returns>刷新数据后的实例</returns>
            public Article Refresh()
            {
                string str = Bas.GetHTTPBody("https://member.bilibili.com/x/h5/data/article", Bas.account.Cookies, "https://member.bilibili.com/studio/gabriel/data-center/overview");
                if (!string.IsNullOrEmpty(str))
                {
                    JObject obj = JObject.Parse(str);
                    if ((int)obj["code"] == 0)
                    {
                        coin = (int)obj["data"]["stat"]["coin"];
                        coin_incr = (int)obj["data"]["stat"]["incr_coin"];
                        fav = (int)obj["data"]["stat"]["fav"];
                        fav_incr = (int)obj["data"]["stat"]["incr_fav"];
                        like = (int)obj["data"]["stat"]["like"];
                        like_incr = (int)obj["data"]["stat"]["incr_like"];
                        reply = (int)obj["data"]["stat"]["reply"];
                        reply_incr = (int)obj["data"]["stat"]["incr_reply"];
                        share = (int)obj["data"]["stat"]["share"];
                        share_incr = (int)obj["data"]["stat"]["incr_share"];
                        view = (int)obj["data"]["stat"]["view"];
                        view_incr = (int)obj["data"]["stat"]["incr_view"];
                    }
                }
                return this;
            }

            #endregion Public Methods
        }

        /// <summary>
        /// 视频类
        /// </summary>
        public class Video : INotifyPropertyChanged
        {
            #region Public Constructors

            /// <summary>
            /// 初始化视频数据
            /// </summary>
            public Video()
            {
                Refresh();
            }

            #endregion Public Constructors

            #region Public Events

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion Public Events

            #region Public Properties

            /// <summary>
            /// 硬币
            /// </summary>
            public int coin { get; private set; }

            /// <summary>
            /// 硬币增量
            /// </summary>
            public int coin_incr { get; private set; }

            /// <summary>
            /// 弹幕
            /// </summary>
            public int dm { get; private set; }

            /// <summary>
            /// 弹幕增量
            /// </summary>
            public int dm_incr { get; private set; }

            /// <summary>
            /// 电池
            /// </summary>
            public float elec { get; private set; }

            /// <summary>
            /// 电池增量
            /// </summary>
            public float elec_incr { get; private set; }

            /// <summary>
            /// 粉丝
            /// </summary>
            public int fan { get; private set; }

            /// <summary>
            /// 粉丝增量
            /// </summary>
            public int fan_incr { get; private set; }

            /// <summary>
            /// 收藏
            /// </summary>
            public int fav { get; private set; }

            /// <summary>
            /// 收藏增量
            /// </summary>
            public int fav_incr { get; private set; }

            /// <summary>
            /// 激励计划
            /// </summary>
            public float growup { get; private set; }

            /// <summary>
            /// 激励计划增量
            /// </summary>
            public float growup_incr { get; private set; }

            /// <summary>
            /// 点赞
            /// </summary>
            public int like { get; private set; }

            /// <summary>
            /// 点赞增量
            /// </summary>
            public int like_incr { get; private set; }

            /// <summary>
            /// 播放
            /// </summary>
            public int play { get; private set; }

            /// <summary>
            /// 播放增量
            /// </summary>
            public int play_incr { get; private set; }

            /// <summary>
            /// 分享
            /// </summary>
            public int share { get; private set; }

            /// <summary>
            /// 分享增量
            /// </summary>
            public int share_incr { get; private set; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// 刷新数据
            /// </summary>
            /// <returns>刷新后的实例</returns>
            public Video Refresh()
            {
                string str = Bas.GetHTTPBody("https://member.bilibili.com/x/h5/data/overview?type=0", Bas.account.Cookies, "https://member.bilibili.com/studio/gabriel/data-center/overview");
                if (!string.IsNullOrEmpty(str))
                {
                    JObject obj = JObject.Parse(str);
                    if ((int)obj["code"] == 0)
                    {
                        coin = (int)obj["data"]["stat"]["coin"];
                        coin_incr = (int)obj["data"]["stat"]["coin"] - (int)obj["data"]["stat"]["coin_last"];
                        dm = (int)obj["data"]["stat"]["dm"];
                        dm_incr = (int)obj["data"]["stat"]["dm"] - (int)obj["data"]["stat"]["dm_last"];
                        elec_incr = (float)obj["data"]["stat"]["elec"] - (float)obj["data"]["stat"]["elec_last"];
                        fan = (int)obj["data"]["stat"]["fan"];
                        fan_incr = (int)obj["data"]["stat"]["fan"] - (int)obj["data"]["stat"]["fan_last"];
                        fav = (int)obj["data"]["stat"]["fav"];
                        fav_incr = (int)obj["data"]["stat"]["fav"] - (int)obj["data"]["stat"]["fav_last"];
                        like = (int)obj["data"]["stat"]["like"];
                        like_incr = (int)obj["data"]["stat"]["like"] - (int)obj["data"]["stat"]["like_last"];
                        play = (int)obj["data"]["stat"]["play"];
                        play_incr = (int)obj["data"]["stat"]["play"] - (int)obj["data"]["stat"]["play_last"];
                        share = (int)obj["data"]["stat"]["share"];
                        share_incr = (int)obj["data"]["stat"]["share"] - (int)obj["data"]["stat"]["share_last"];
                    }
                }

                elec = GetCharge();
                float[] tmp = GetGrowUp();
                growup_incr = tmp[0];
                growup = tmp[1];
                return this;
            }

            #endregion Public Methods

            #region Private Methods

            /// <summary>
            /// 获得充电数据
            /// </summary>
            /// <returns>电池数</returns>
            private float GetCharge()
            {
                string str = Bas.GetHTTPBody("https://member.bilibili.com/x/web/elec/balance", Bas.account.Cookies);
                JObject obj = JObject.Parse(str);
                if ((int)obj["code"] == 0)
                {
                    return (float)obj["data"]["wallet"]["sponsorBalance"];
                }
                else
                {
                    return -1;
                }
            }

            /// <summary>
            /// 获得激励计划数据
            /// </summary>
            /// <returns>[0]:前天收入;[1]:本月收入</returns>
            private float[] GetGrowUp()
            {
                string str = Bas.GetHTTPBody("https://api.bilibili.com/studio/growup/web/up/summary", Bas.account.Cookies);
                JObject obj = JObject.Parse(str);
                if ((int)obj["code"] == 0)
                {
                    return new float[2] { (float)obj["data"]["day_income"], (float)obj["data"]["income"] };
                }
                else
                {
                    return new float[2] { -1, -1 };
                }
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}