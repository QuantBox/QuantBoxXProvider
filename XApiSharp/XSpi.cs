using System;

namespace QuantBox.XApi
{
    public class XSpi : IXSpi
    {
        #region Response Handler

        void IXSpi.ProcessRtnInstrumentStatus(InstrumentStatusField status)
        {
            InstrumentStatusChanged?.Invoke(this, status);
        }

        void IXSpi.ProcessConnectionStatus(ConnectionStatus status, RspUserLoginField login)
        {
            StatusChanged?.Invoke(this, status, login);
        }

        void IXSpi.ProcessError(ErrorField error)
        {
            ErrorHappened?.Invoke(this, error);
        }

        void IXSpi.ProcessQryInstrument(InstrumentField inst, bool last)
        {
            InstrumentReceived?.Invoke(this, inst, last);
        }

        void IXSpi.ProcessQryPosition(PositionField position, bool last)
        {
            PositionReceived?.Invoke(this, position, last);
        }

        void IXSpi.ProcessQryInvestor(InvestorField investor, bool last)
        {
            InvestorReceived?.Invoke(this, investor, last);
        }

        void IXSpi.ProcessQryAccount(AccountField account, bool last)
        {
            AccountReceived?.Invoke(this, account, last);
        }

        void IXSpi.ProcessQrySettlementInfo(SettlementInfoField info, bool last)
        {
            SettlementInfoReceived?.Invoke(this, info, last);
        }

        void IXSpi.ProcessQryOrder(OrderField order, bool last)
        {
            OrderReceived?.Invoke(this, order, last);
        }

        void IXSpi.ProcessQryTrade(TradeField trade, bool last)
        {
            TradeReceived?.Invoke(this, trade, last);
        }

        void IXSpi.ProcessDepthMarketData(DepthMarketDataField data)
        {
            MarketDataReceived?.Invoke(this, data);
        }

        void IXSpi.ProcessRtnOrder(OrderField order)
        {
            OrderReturn?.Invoke(this, order);
        }

        void IXSpi.ProcessRtnTrade(TradeField trade)
        {
            TradeReturn?.Invoke(this, trade);
        }

        public void ProcessLog(LogField log)
        {
            LogHappened?.Invoke(this, log);
        }

        #endregion

        #region Response Events
        public event XApiEventHandler2<ConnectionStatus, RspUserLoginField> StatusChanged;
        public event EventHandler<ErrorField> ErrorHappened;
        public event EventHandler<LogField> LogHappened;
        public event XApiEventHandler3<InstrumentField> InstrumentReceived;
        public event XApiEventHandler3<PositionField> PositionReceived;
        public event XApiEventHandler3<InvestorField> InvestorReceived;
        public event XApiEventHandler3<AccountField> AccountReceived;
        public event XApiEventHandler3<SettlementInfoField> SettlementInfoReceived;
        public event XApiEventHandler3<OrderField> OrderReceived;
        public event XApiEventHandler3<TradeField> TradeReceived;
        public event EventHandler<DepthMarketDataField> MarketDataReceived;
        public event EventHandler<OrderField> OrderReturn;
        public event EventHandler<TradeField> TradeReturn;
        public event EventHandler<InstrumentStatusField> InstrumentStatusChanged;
        #endregion
    }
}