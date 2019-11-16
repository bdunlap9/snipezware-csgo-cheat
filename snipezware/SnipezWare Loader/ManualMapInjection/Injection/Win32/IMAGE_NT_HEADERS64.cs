using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000011 RID: 17
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_NT_HEADERS64
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00003768 File Offset: 0x00001968
		private string _Signature
		{
			get
			{
				return new string(this.Signature);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00003775 File Offset: 0x00001975
		public bool isValid
		{
			get
			{
				return this._Signature == "PE\0\0";
			}
		}

		// Token: 0x040000D0 RID: 208
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public char[] Signature;

		// Token: 0x040000D1 RID: 209
		[FieldOffset(4)]
		public IMAGE_FILE_HEADER FileHeader;

		// Token: 0x040000D2 RID: 210
		[FieldOffset(24)]
		public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
	}
}
