// 

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Systems.Audio.Native
{
    internal class ConstCharPtrMarshaler : ICustomMarshaler
    {
        private static readonly ConstCharPtrMarshaler Instance = new ConstCharPtrMarshaler();

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        public int GetNativeDataSize() => IntPtr.Size;

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            switch (ManagedObj)
            {
                case string str:
                    return Marshal.StringToHGlobalAnsi(str);
                default:
                    throw new ArgumentException(
                        $"{nameof(ConstCharPtrMarshaler)} only supports marshaling of strings. Got '{ManagedObj.GetType()}'");
            }
        }

        public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.PtrToStringAnsi(pNativeData);

        // See https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.custommarshalers.typetotypeinfomarshaler.getinstance
#pragma warning disable IDE0060 // Remove unused parameter
        public static ICustomMarshaler GetInstance(string cookie) => Instance;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}