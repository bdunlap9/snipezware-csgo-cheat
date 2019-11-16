using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000016 RID: 22
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_THUNK_DATA
	{
		// Token: 0x040000EC RID: 236
		[FieldOffset(0)]
		public uint ForwarderString;

		// Token: 0x040000ED RID: 237
		[FieldOffset(0)]
		public uint Function;

		// Token: 0x040000EE RID: 238
		[FieldOffset(0)]
		public uint Ordinal;

		// Token: 0x040000EF RID: 239
		[FieldOffset(0)]
		public uint AddressOfData;
	}
}
