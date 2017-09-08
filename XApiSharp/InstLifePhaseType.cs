namespace QuantBox.XApi
{
    public enum InstLifePhaseType : byte
    {
        ///未上市
        NotStart,
        ///上市
        Started,
        ///停牌
        Pause,
        ///到期
        Expired,
        ///发行,参考于XSpeed
        Issue,
        ///首日上市,参考于XSpeed
        FirstList,
        ///退市,参考于XSpeed
        UnList,
    };
}
