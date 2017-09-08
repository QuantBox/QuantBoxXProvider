namespace QuantBox.XApi
{
    public interface IXApi
    {
        void RegisterSpi(IXSpi spi);
        void Release();
        void Connect(ServerInfoField server, UserInfoField user);
        void Disconnect();
        void Query(QueryType type, ReqQueryField query);
        bool Connected { get; }
        void Subscribe(string instrument, string exchange, InstrumentType type);
        void Unsubscribe(string instrument, string exchange, InstrumentType type);
        string SendOrder(params OrderField[] orders);
        string CancelOrder(params string[] list);
        string ApiVersion { get; }
        ApiType ApiTypes { get; }
        string ApiName { get; }
        ServerInfoField Server { get; }
        UserInfoField User { get; }
        RspUserLoginField UserLogin { get; }
    }
}