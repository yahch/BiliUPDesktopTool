﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiliUPDesktopTool.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BiliUPDesktopTool.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 {
        ///  &quot;article&quot;: {
        ///    &quot;view&quot;: &quot;文章点击量。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;coin&quot;: &quot;硬币。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;reply&quot;: &quot;评论。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;fav&quot;: &quot;收藏。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;like&quot;: &quot;点赞。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;share&quot;: &quot;分享数。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;
        ///  },
        ///  &quot;video&quot;: {
        ///    &quot;play&quot;: &quot;视频播放数。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;coin&quot;: &quot;硬币。（每天中午12点更新昨日数据，实时模式下显示昨日增量+程序运行时增量）&quot;,
        ///    &quot;comment&quot;: &quot;评论。（每天中午12 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string DataDesc {
            get {
                return ResourceManager.GetString("DataDesc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似于 (图标) 的 System.Drawing.Icon 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Icon icon {
            get {
                object obj = ResourceManager.GetObject("icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Bitmap icon1 {
            get {
                object obj = ResourceManager.GetObject("icon1", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 B站UP主桌面工具的诞生离不开以下开源项目的帮助：
        ///
        ///·Newtonsoft.Json 12.0.1
        ///  https://www.newtonsoft.com/json
        ///  Copyright © 2019 Newtonsoft
        ///  Licensed under MIT
        ///
        ///·QRCoder 1.3.5
        ///  https://github.com/codebude/QRCoder/
        ///  Copyright © 2011 - 2018 Raffael Herrmann
        ///  Licensed under MIT
        ///  
        ///·SharpZipLib 1.1.0
        ///  https://github.com/icsharpcode/SharpZipLib
        ///  Copyright © 2000-2018 SharpZipLib Contributors
        ///  Licensed under MIT 的本地化字符串。
        /// </summary>
        internal static string Thanks {
            get {
                return ResourceManager.GetString("Thanks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似于 (图标) 的 System.Drawing.Icon 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Icon Upateicon {
            get {
                object obj = ResourceManager.GetObject("Upateicon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
    }
}
