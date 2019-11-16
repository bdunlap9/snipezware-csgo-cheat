using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000C RID: 12
	public struct IMAGE_FILE_HEADER
	{
		// Token: 0x04000069 RID: 105
		public ushort Machine;

		// Token: 0x0400006A RID: 106
		public ushort NumberOfSections;

		// Token: 0x0400006B RID: 107
		public uint TimeDateStamp;

		// Token: 0x0400006C RID: 108
		public uint PointerToSymbolTable;

		// Token: 0x0400006D RID: 109
		public uint NumberOfSymbols;

		// Token: 0x0400006E RID: 110
		public ushort SizeOfOptionalHeader;

		// Token: 0x0400006F RID: 111
		public ushort Characteristics;
	}
}
