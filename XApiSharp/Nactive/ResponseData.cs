using System;

namespace QuantBox.XApi.Nactive
{
    internal struct ResponseData
    {
        public readonly byte RspType;
        public readonly IntPtr Api1;
        public readonly IntPtr Api2;
        public readonly double Double1;
        public readonly double Double2;
        public readonly IntPtr Ptr1;
        public readonly int Size1;
        public readonly IntPtr Ptr2;
        public readonly int Size2;
        public readonly IntPtr Ptr3;
        public readonly int Size3;

        public ResponseData(byte type, IntPtr api1, IntPtr api2, double double1, double double2, IntPtr ptr1,
            int size1, IntPtr ptr2, int size2, IntPtr ptr3, int size3)
        {
            RspType = type;
            Api1 = api1;
            Api2 = api2;
            Double1 = double1;
            Double2 = double2;
            Ptr1 = ptr1;
            Size1 = size1;
            Ptr2 = ptr2;
            Size2 = size2;
            Ptr3 = ptr3;
            Size3 = size3;
        }
    }
}
