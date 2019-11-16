using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000012 RID: 18
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_SECTION_HEADER
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00003787 File Offset: 0x00001987
		public string Section
		{
			get
			{
				return new string(this.Name);
			}
		}

		// Token: 0x040000D3 RID: 211
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public char[] Name;

		// Token: 0x040000D4 RID: 212
		[FieldOffset(8)]
		public uint VirtualSize;

		// Token: 0x040000D5 RID: 213
		[FieldOffset(12)]
		public uint VirtualAddress;

		// Token: 0x040000D6 RID: 214
		[FieldOffset(16)]
		public uint SizeOfRawData;

		// Token: 0x040000D7 RID: 215
		[FieldOffset(20)]
		public uint PointerToRawData;

		// Token: 0x040000D8 RID: 216
		[FieldOffset(24)]
		public uint PointerToRelocations;

		// Token: 0x040000D9 RID: 217
		[FieldOffset(28)]
		public uint PointerToLinenumbers;

		// Token: 0x040000DA RID: 218
		[FieldOffset(32)]
		public ushort NumberOfRelocations;

		// Token: 0x040000DB RID: 219
		[FieldOffset(34)]
		public ushort NumberOfLinenumbers;

		// Token: 0x040000DC RID: 220
		[FieldOffset(36)]
		public DataSectionFlags Characteristics;
	}
}
