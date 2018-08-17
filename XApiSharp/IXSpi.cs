namespace QuantBox.XApi
{
    public interface IXSpi
    {
        void ProcessConnectionStatus(ConnectionStatus status, RspUserLoginField login);
        void ProcessError(ErrorField error);
        void ProcessQryInstrument(InstrumentField inst, bool last);
        void ProcessQryPosition(PositionField position, bool last);
        void ProcessQryInvestor(InvestorField investor, bool last);
        void ProcessQryAccount(AccountField account, bool last);
        void ProcessQrySettlementInfo(SettlementInfoField info, bool last);
        void ProcessQryOrder(OrderField order, bool last);
        void ProcessQryTrade(TradeField trade, bool last);
        void ProcessDepthMarketData(DepthMarketDataField data);
        void ProcessRtnOrder(OrderField order);
        void ProcessRtnTrade(TradeField trade);
        void ProcessRtnInstrumentStatus(InstrumentStatusField status);
        void ProcessLog(LogField log);
    }
}