﻿using System.ComponentModel;

namespace QuantBox.XApi
{
    public enum ConnectionStatus : byte
    {
        /// <summary>
        /// 未初始化
        /// </summary>
        [Description("未初始化")]
        Uninitialized = 0,
        /// <summary>
        /// 已经初始化
        /// </summary>
        [Description("已经初始化")]
        Initialized,
        /// <summary>
        /// 连接已经断开
        /// </summary>
        [Description("连接已经断开")]
        Disconnected,
        /// <summary>
        /// 连接中...
        /// </summary>
        [Description("连接中...")]
        Connecting,
        /// <summary>
        /// 连接成功
        /// </summary>
        [Description("连接成功")]
        Connected,
        /// <summary>
        /// 授权中...
        /// </summary>
        [Description("授权中...")]
        Authorizing,
        /// <summary>
        /// 授权成功
        /// </summary>
        [Description("授权成功")]
        Authorized,
        /// <summary>
        /// 登录中...
        /// </summary>
        [Description("登录中...")]
        Logining,
        /// <summary>
        /// 登录成功
        /// </summary>
        [Description("登录成功")]
        Logined,
        /// <summary>
        /// 确认中...
        /// </summary>
        [Description("确认中...")]
        Confirming,
        /// <summary>
        /// 已经确认
        /// </summary>
        [Description("已经确认")]
        Confirmed,
        /// <summary>
        /// 操作中...
        /// </summary>
        [Description("操作中...")]
        Doing,
        /// <summary>
        /// 完成
        /// </summary>
        [Description("完成")]
        Done,
        /// <summary>
        /// 关闭中...
        /// </summary>
        [Description("关闭中...")]
        Releasing
    }
}