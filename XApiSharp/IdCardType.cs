namespace QuantBox.XApi
{
    public enum IdCardType : byte
    {
        EID,			///组织机构代码
        IDCard,			///中国公民身份证
        Passport,		///护照
        LicenseNo,		///营业执照号
        TaxNo,			///税务登记号/当地纳税ID
        DrivingLicense,	///驾照
        SocialID,		///当地社保ID
        LocalID,		///当地身份证
        OtherCard,		///其他证件
    };
}
