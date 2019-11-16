using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000017 RID: 23
	public struct IMAGE_EXPORT_DIRECTORY
	{
		// Token: 0x040000F0 RID: 240
		public uint Characteristics;

		// Token: 0x040000F1 RID: 241
		public uint TimeDateStamp;

		// Token: 0x040000F2 RID: 242
		public ushort MajorVersion;

		// Token: 0x040000F3 RID: 243
		public ushort MinorVersion;

		// Token: 0x040000F4 RID: 244
		public uint Name;

		// Token: 0x040000F5 RID: 245
		public uint Base;

		// Token: 0x040000F6 RID: 246
		public uint NumberOfFunctions;

		// Token: 0x040000F7 RID: 247
		public uint NumberOfNames;

		// Token: 0x040000F8 RID: 248
		public uint AddressOfFunctions;

		// Token: 0x040000F9 RID: 249
		public uint AddressOfNames;

		// Token: 0x040000FA RID: 250
		public uint AddressOfNameOrdinals;
	}
}
