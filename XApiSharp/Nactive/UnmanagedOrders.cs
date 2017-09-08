using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace QuantBox.XApi.Nactive
{
    internal struct UnmanagedOrders : IDisposable
    {
        private static readonly int OrderFieldSize = Marshal.SizeOf(typeof(OrderField));
        private static readonly int OrderIdTypeSize = Marshal.SizeOf(typeof(OrderIdType));

        public UnmanagedOrders(IReadOnlyList<OrderField> orders)
        {
            OrderPtr = Marshal.AllocHGlobal(OrderFieldSize * orders.Count);
            InOrderIdPtr = IntPtr.Zero;
            OutOrderIdPtr = Marshal.AllocHGlobal(OrderIdTypeSize * orders.Count);
            //将结构体写成内存块
            for (var i = 0; i < orders.Count; ++i) {
                Marshal.StructureToPtr(orders[i], new IntPtr(OrderPtr.ToInt64() + i * OrderFieldSize), false);
            }
        }

        public UnmanagedOrders(IReadOnlyList<string> list)
        {
            OrderPtr = IntPtr.Zero;
            InOrderIdPtr = Marshal.AllocHGlobal(OrderIdTypeSize * list.Count);
            OutOrderIdPtr = Marshal.AllocHGlobal(OrderIdTypeSize * list.Count);
            // 将结构体写成内存块
            for (var i = 0; i < list.Count; ++i) {
                var id = new OrderIdType() {
                    ID = list[i]
                };
                Marshal.StructureToPtr(id, new IntPtr(InOrderIdPtr.ToInt64() + i * OrderIdTypeSize), false);
            }
        }

        public IntPtr OrderPtr;
        public IntPtr InOrderIdPtr;
        public IntPtr OutOrderIdPtr;

        public void Dispose()
        {
            if (OrderPtr != IntPtr.Zero) {
                Marshal.FreeHGlobal(OrderPtr);
                OrderPtr = IntPtr.Zero;
            }
            if (InOrderIdPtr != IntPtr.Zero) {
                Marshal.FreeHGlobal(InOrderIdPtr);
                InOrderIdPtr = IntPtr.Zero;
            }
            if (OutOrderIdPtr != IntPtr.Zero) {
                Marshal.FreeHGlobal(OutOrderIdPtr);
                OutOrderIdPtr = IntPtr.Zero;
            }
        }
    }
}