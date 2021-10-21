using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SbrfLibrary.SBRFSRV
{
    [ComImport]
    [CompilerGenerated]
    [Guid("1903B22D-0B17-4DE6-8D7A-6725A6245942")]
    [TypeIdentifier]
    public interface IServer31
    {
        [MethodImpl(MethodImplOptions.InternalCall | MethodImplOptions.PreserveSig)]
        [DispId(1)]
        int NFun([In] int func);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(2)]
        void SParam([In][MarshalAs(UnmanagedType.BStr)] string Name, [In][MarshalAs(UnmanagedType.Struct)] object Value);

        void _VtblGap1_2();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(5)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string GParamString([In][MarshalAs(UnmanagedType.BStr)] string Name);
    }
}
