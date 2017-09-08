# QuantBox XProvider
  重新设计了 OpenQuant 插件的架构，增强代码的可读性和可维护性
## What's New
* 增强了配置信息编辑器的功能，现在插件可以通过重载 **GetServerPropertyMap** 和 **GetUserPropertyMap** 来定制自己的配置选项
的显示信息，对属性重命名或隐藏某些不需要的属性。
```c#
// CTP Provider
protected override IDictionary<string, string> GetServerPropertyMap()
{
    return new Dictionary<string, string>{
        {"Label", "标识"},
        {"PublicTopicResumeType", "PublicTopicResumeType"},
        {"PrivateTopicResumeType", "PrivateTopicResumeType"},
        {"UserTopicResumeType", "UserTopicResumeType"},
        {"UserProductInfo", "UserProductInfo"},
        {"BrokerID", "BrokerID"},
        {"AuthCode", "AuthCode"},
        {"Address", "Address"},
        {"Port", "Port"},
        {"IsUsingUdp", "IsUsingUdp"},
        {"IsMulticast","IsMulticast"}
    };
}

protected override IDictionary<string, string> GetUserPropertyMap()
{
    return new Dictionary<string, string>{
        {"Label", "标识"},
        {"UserId", "用户名"},
        {"Password", "密码"}
    };
}
```
* 添加了 **InstrumentAltId** 属性设定插件在订阅合约时如何获取合约的交易所标识。有时导入的合约在 OpenQuant 中显示的合约信息
和在交易所中显示的不一致，例如郑商所的 SR805 合约一般在导入会做转换补全年份信息，不然的话获取历史数据的时候就不知道是要 
SR1805 的数据还是 SR0805 的数据。在这种情况下进行实盘或仿真交易需要订阅合约时就需要知道符合交易所标准的合约信息，通常在
导入这样合约的时候，插件会在 Instrument 中利用 AltId 保存交易所合约信息，但是在获取的这个信息需要提供 ProviderId，如果是
本插件导入的合约就直接使用 Id 属性就行了，如果是别的插件导入的合约就需要用户通过 **InstrumentAltId** 指定导入合约的 ProviderId。
 
* 添加了事件调试机制，在开发插件的过程中有一类错误是非常难以调试解决的，这就是由于并发写入一个 Queue 对象引发的 OpenQuant
系统崩溃，这类错误的发生通常没有规律随机产生难以通过断点的方式进行调试，而且没有 SmartQaunt.dll 的源代码不能在 OpenQuant 
的事件处理核心进行调试。现在插件提供了 **EventEmitter** 模拟 OpenQuant 的事件处理核心的工作机制，把错误的发生位置从 OpenQuant 
的事件处理核心转移到了插件中，这样就能方便的调试解决这类错误了。
```c#
// XProvider.cs
        public XProvider(Framework framework)
            : base(framework)
        {
            _manager = new ConnectManager(this);
            _processor = new TradingProcessor(this);
            _convertor = new Convertor(this);
            _timer = new TimedTask(this);
#if DEBUG
            _emitter = new EventDebugEmitter(this);
#else
            _emitter = new EventEmitter(this);
#endif
            ProviderInit();
        }
```

### XApiSharp

* XApi 的 C# 实现也进行了重新设计增强代码的可读性和可维护性，除了兼容 C++ 实现的 XAPI 外，通过定义 **IXApi** 和 **IXSpi**
这两个接口实现了对 Managed XAPI 实现的支持，**XTradingApi** 可以自动识别是 C++ 的实现还是 Managed 的实现，这个模式方便用户
使用 C# 等语言实现 XAPI 接入诸如比特币等交易市场。
```c#
        public XTradingApi(string path)
        {
            if (XApiHelper.IsManagedAssembly(path)) {
                FileType = XApiFileType.Managed;
                _instance = ManagedManager.GetInstance(path);
            }
            else {
                FileType = XApiFileType.Managed;
                _instance = new Nactive.XApi(path);
            }
            _api = (IXApi)_instance;
            _api.RegisterSpi(this);
        }
```