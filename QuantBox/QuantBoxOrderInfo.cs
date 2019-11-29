using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using QuantBox.XApi;

namespace QuantBox
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DeviationInfo
    {
        public OrderPriceAdjustMethod PriceAdjustMethod;
        public OrderDeviationMethod Method;
        public byte Slippage;
        public byte MaxTry;
        public byte TryCount;
        public int Threshold;

        public void SaveTo(BinaryWriter writer)
        {
            writer.Write((byte)PriceAdjustMethod);
            writer.Write((byte)Method);
            writer.Write(Slippage);
            writer.Write(MaxTry);
            writer.Write(TryCount);
            writer.Write(Threshold);
        }
        public void LoadForm(BinaryReader reader)
        {
            PriceAdjustMethod = (OrderPriceAdjustMethod)reader.ReadByte();
            Method = (OrderDeviationMethod)reader.ReadByte();
            Slippage = reader.ReadByte();
            MaxTry = reader.ReadByte();
            TryCount = reader.ReadByte();
            Threshold = reader.ReadInt32();
        }
    }

    [DataContract]
    public class QuantBoxOrderInfo
    {
        public OpenCloseType OpenClose = OpenCloseType.Undefined;
        public HedgeFlagType HedgeFlag = HedgeFlagType.Speculation;
        public OrderSide Side = OrderSide.Undefined;
        public OrderDeviationMode DeviationMode = OrderDeviationMode.Disabled;
        public OrderAdjustFailedMethod FailedMethod = OrderAdjustFailedMethod.Cancel;
        public int ParentOrderId;
        public DeviationInfo Market2Limit = new DeviationInfo();
        public DeviationInfo DeviationInfo = new DeviationInfo();
        internal object Processor = null;

        private static readonly int ThisSize;
        static QuantBoxOrderInfo()
        {
            foreach (var field in typeof(QuantBoxOrderInfo).GetFields()) {
                if (field.FieldType.IsEnum) {
                    ThisSize += Marshal.SizeOf(typeof(byte));
                }
                else if (field.FieldType == typeof(DeviationInfo)) {
                    ThisSize += Marshal.SizeOf(typeof(DeviationInfo));
                }
                else if (field.FieldType == typeof(int)) {
                    ThisSize += Marshal.SizeOf(typeof(int));
                }
                else if (field.FieldType == typeof(bool)) {
                    ThisSize += Marshal.SizeOf(typeof(bool));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] Save()
        {
            var bytes = new byte[ThisSize];
            using (var stream = new MemoryStream(bytes))
            using (var writer = new BinaryWriter(stream)) {
                writer.Write((byte)OpenClose);
                writer.Write((byte)HedgeFlag);
                writer.Write((byte)Side);
                writer.Write((byte)DeviationMode);
                writer.Write((byte)FailedMethod);
                writer.Write((byte)ParentOrderId);
                Market2Limit.SaveTo(writer);
                DeviationInfo.SaveTo(writer);
            }
            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Load(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            using (var reader = new BinaryReader(stream)) {
                OpenClose = (OpenCloseType)reader.ReadByte();
                HedgeFlag = (HedgeFlagType)reader.ReadByte();
                Side = (OrderSide)reader.ReadByte();
                DeviationMode = (OrderDeviationMode)reader.ReadByte();
                FailedMethod = (OrderAdjustFailedMethod)reader.ReadByte();
                ParentOrderId = reader.ReadInt32();
                Market2Limit.LoadForm(reader);
                DeviationInfo.LoadForm(reader);
            }
        }
    }
}
