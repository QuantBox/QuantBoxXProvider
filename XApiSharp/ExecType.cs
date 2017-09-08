namespace QuantBox.XApi
{
    public enum ExecType : byte
    {
        New,
        Stopped,
        Rejected,
        Expired,
        Trade,
        PendingCancel,
        Cancelled,
        CancelReject,
        PendingReplace,
        Replace,
        ReplaceReject,
        TradeCorrect,
        TradeCancel,
        OrderStatus,
        PendingNew,
        ClearingHold,
    };
}