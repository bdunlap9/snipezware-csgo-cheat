using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000F RID: 15
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_OPTIONAL_HEADER64
	{
		// Token: 0x040000A0 RID: 160
		[FieldOffset(0)]
		public MagicType Magic;

		// Token: 0x040000A1 RID: 161
		[FieldOffset(2)]
		public byte MajorLinkerVersion;

		// Token: 0x040000A2 RID: 162
		[FieldOffset(3)]
		public byte MinorLinkerVersion;

		// Token: 0x040000A3 RID: 163
		[FieldOffset(4)]
		public uint SizeOfCode;

		// Token: 0x040000A4 RID: 164
		[FieldOffset(8)]
		public uint SizeOfInitializedData;

		// Token: 0x040000A5 RID: 165
		[FieldOffset(12)]
		public uint SizeOfUninitializedData;

		// Token: 0x040000A6 RID: 166
		[FieldOffset(16)]
		public uint AddressOfEntryPoint;

		// Token: 0x040000A7 RID: 167
		[FieldOffset(20)]
		public uint BaseOfCode;

		// Token: 0x040000A8 RID: 168
		[FieldOffset(24)]
		public ulong ImageBase;

		// Token: 0x040000A9 RID: 169
		[FieldOffset(32)]
		public uint SectionAlignment;

		// Token: 0x040000AA RID: 170
		[FieldOffset(36)]
		public uint FileAlignment;

		// Token: 0x040000AB RID: 171
		[FieldOffset(40)]
		public ushort MajorOperatingSystemVersion;

		// Token: 0x040000AC RID: 172
		[FieldOffset(42)]
		public ushort MinorOperatingSystemVersion;

		// Token: 0x040000AD RID: 173
		[FieldOffset(44)]
		public ushort MajorImageVersion;

		// Token: 0x040000AE RID: 174
		[FieldOffset(46)]
		public ushort MinorImageVersion;

		// Token: 0x040000AF RID: 175
		[FieldOffset(48)]
		public ushort MajorSubsystemVersion;

		// Token: 0x040000B0 RID: 176
		[FieldOffset(50)]
		public ushort MinorSubsystemVersion;

		// Token: 0x040000B1 RID: 177
		[FieldOffset(52)]
		public uint Win32VersionValue;

		// Token: 0x040000B2 RID: 178
		[FieldOffset(56)]
		public uint SizeOfImage;

		// Token: 0x040000B3 RID: 179
		[FieldOffset(60)]
		public uint SizeOfHeaders;

		// Token: 0x040000B4 RID: 180
		[FieldOffset(64)]
		public uint CheckSum;

		// Token: 0x040000B5 RID: 181
		[FieldOffset(68)]
		public SubSystemType Subsystem;

		// Token: 0x040000B6 RID: 182
		[FieldOffset(70)]
		public DllCharacteristicsType DllCharacteristics;

		// Token: 0x040000B7 RID: 183
		[FieldOffset(72)]
		public ulong SizeOfStackReserve;

		// Token: 0x040000B8 RID: 184
		[FieldOffset(80)]
		public ulong SizeOfStackCommit;

		// Token: 0x040000B9 RID: 185
		[FieldOffset(88)]
		public ulong SizeOfHeapReserve;

		// Token: 0x040000BA RID: 186
		[FieldOffset(96)]
		public ulong SizeOfHeapCommit;

		// Token: 0x040000BB RID: 187
		[FieldOffset(104)]
		public uint LoaderFlags;

		// Token: 0x040000BC RID: 188
		[FieldOffset(108)]
		public uint NumberOfRvaAndSizes;

		// Token: 0x040000BD RID: 189
		[FieldOffset(112)]
		public IMAGE_DATA_DIRECTORY ExportTable;

		// Token: 0x040000BE RID: 190
		[FieldOffset(120)]
		public IMAGE_DATA_DIRECTORY ImportTable;

		// Token: 0x040000BF RID: 191
		[FieldOffset(128)]
		public IMAGE_DATA_DIRECTORY ResourceTable;

		// Token: 0x040000C0 RID: 192
		[FieldOffset(136)]
		public IMAGE_DATA_DIRECTORY ExceptionTable;

		// Token: 0x040000C1 RID: 193
		[FieldOffset(144)]
		public IMAGE_DATA_DIRECTORY CertificateTable;

		// Token: 0x040000C2 RID: 194
		[FieldOffset(152)]
		public IMAGE_DATA_DIRECTORY BaseRelocationTable;

		// Token: 0x040000C3 RID: 195
		[FieldOffset(160)]
		public IMAGE_DATA_DIRECTORY Debug;

		// Token: 0x040000C4 RID: 196
		[FieldOffset(168)]
		public IMAGE_DATA_DIRECTORY Architecture;

		// Token: 0x040000C5 RID: 197
		[FieldOffset(176)]
		public IMAGE_DATA_DIRECTORY GlobalPtr;

		// Token: 0x040000C6 RID: 198
		[FieldOffset(184)]
		public IMAGE_DATA_DIRECTORY TLSTable;

		// Token: 0x040000C7 RID: 199
		[FieldOffset(192)]
		public IMAGE_DATA_DIRECTORY LoadConfigTable;

		// Token: 0x040000C8 RID: 200
		[FieldOffset(200)]
		public IMAGE_DATA_DIRECTORY BoundImport;

		// Token: 0x040000C9 RID: 201
		[FieldOffset(208)]
		public IMAGE_DATA_DIRECTORY IAT;

		// Token: 0x040000CA RID: 202
		[FieldOffset(216)]
		public IMAGE_DATA_DIRECTORY DelayImportDescriptor;

		// Token: 0x040000CB RID: 203
		[FieldOffset(224)]
		public IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

		// Token: 0x040000CC RID: 204
		[FieldOffset(232)]
		public IMAGE_DATA_DIRECTORY Reserved;
	}
}
