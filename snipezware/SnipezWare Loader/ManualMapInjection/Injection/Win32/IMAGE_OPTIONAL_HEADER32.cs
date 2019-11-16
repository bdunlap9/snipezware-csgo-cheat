using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000E RID: 14
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_OPTIONAL_HEADER32
	{
		// Token: 0x04000072 RID: 114
		[FieldOffset(0)]
		public MagicType Magic;

		// Token: 0x04000073 RID: 115
		[FieldOffset(2)]
		public byte MajorLinkerVersion;

		// Token: 0x04000074 RID: 116
		[FieldOffset(3)]
		public byte MinorLinkerVersion;

		// Token: 0x04000075 RID: 117
		[FieldOffset(4)]
		public uint SizeOfCode;

		// Token: 0x04000076 RID: 118
		[FieldOffset(8)]
		public uint SizeOfInitializedData;

		// Token: 0x04000077 RID: 119
		[FieldOffset(12)]
		public uint SizeOfUninitializedData;

		// Token: 0x04000078 RID: 120
		[FieldOffset(16)]
		public uint AddressOfEntryPoint;

		// Token: 0x04000079 RID: 121
		[FieldOffset(20)]
		public uint BaseOfCode;

		// Token: 0x0400007A RID: 122
		[FieldOffset(24)]
		public uint BaseOfData;

		// Token: 0x0400007B RID: 123
		[FieldOffset(28)]
		public uint ImageBase;

		// Token: 0x0400007C RID: 124
		[FieldOffset(32)]
		public uint SectionAlignment;

		// Token: 0x0400007D RID: 125
		[FieldOffset(36)]
		public uint FileAlignment;

		// Token: 0x0400007E RID: 126
		[FieldOffset(40)]
		public ushort MajorOperatingSystemVersion;

		// Token: 0x0400007F RID: 127
		[FieldOffset(42)]
		public ushort MinorOperatingSystemVersion;

		// Token: 0x04000080 RID: 128
		[FieldOffset(44)]
		public ushort MajorImageVersion;

		// Token: 0x04000081 RID: 129
		[FieldOffset(46)]
		public ushort MinorImageVersion;

		// Token: 0x04000082 RID: 130
		[FieldOffset(48)]
		public ushort MajorSubsystemVersion;

		// Token: 0x04000083 RID: 131
		[FieldOffset(50)]
		public ushort MinorSubsystemVersion;

		// Token: 0x04000084 RID: 132
		[FieldOffset(52)]
		public uint Win32VersionValue;

		// Token: 0x04000085 RID: 133
		[FieldOffset(56)]
		public uint SizeOfImage;

		// Token: 0x04000086 RID: 134
		[FieldOffset(60)]
		public uint SizeOfHeaders;

		// Token: 0x04000087 RID: 135
		[FieldOffset(64)]
		public uint CheckSum;

		// Token: 0x04000088 RID: 136
		[FieldOffset(68)]
		public SubSystemType Subsystem;

		// Token: 0x04000089 RID: 137
		[FieldOffset(70)]
		public DllCharacteristicsType DllCharacteristics;

		// Token: 0x0400008A RID: 138
		[FieldOffset(72)]
		public uint SizeOfStackReserve;

		// Token: 0x0400008B RID: 139
		[FieldOffset(76)]
		public uint SizeOfStackCommit;

		// Token: 0x0400008C RID: 140
		[FieldOffset(80)]
		public uint SizeOfHeapReserve;

		// Token: 0x0400008D RID: 141
		[FieldOffset(84)]
		public uint SizeOfHeapCommit;

		// Token: 0x0400008E RID: 142
		[FieldOffset(88)]
		public uint LoaderFlags;

		// Token: 0x0400008F RID: 143
		[FieldOffset(92)]
		public uint NumberOfRvaAndSizes;

		// Token: 0x04000090 RID: 144
		[FieldOffset(96)]
		public IMAGE_DATA_DIRECTORY ExportTable;

		// Token: 0x04000091 RID: 145
		[FieldOffset(104)]
		public IMAGE_DATA_DIRECTORY ImportTable;

		// Token: 0x04000092 RID: 146
		[FieldOffset(112)]
		public IMAGE_DATA_DIRECTORY ResourceTable;

		// Token: 0x04000093 RID: 147
		[FieldOffset(120)]
		public IMAGE_DATA_DIRECTORY ExceptionTable;

		// Token: 0x04000094 RID: 148
		[FieldOffset(128)]
		public IMAGE_DATA_DIRECTORY CertificateTable;

		// Token: 0x04000095 RID: 149
		[FieldOffset(136)]
		public IMAGE_DATA_DIRECTORY BaseRelocationTable;

		// Token: 0x04000096 RID: 150
		[FieldOffset(144)]
		public IMAGE_DATA_DIRECTORY Debug;

		// Token: 0x04000097 RID: 151
		[FieldOffset(152)]
		public IMAGE_DATA_DIRECTORY Architecture;

		// Token: 0x04000098 RID: 152
		[FieldOffset(160)]
		public IMAGE_DATA_DIRECTORY GlobalPtr;

		// Token: 0x04000099 RID: 153
		[FieldOffset(168)]
		public IMAGE_DATA_DIRECTORY TLSTable;

		// Token: 0x0400009A RID: 154
		[FieldOffset(176)]
		public IMAGE_DATA_DIRECTORY LoadConfigTable;

		// Token: 0x0400009B RID: 155
		[FieldOffset(184)]
		public IMAGE_DATA_DIRECTORY BoundImport;

		// Token: 0x0400009C RID: 156
		[FieldOffset(192)]
		public IMAGE_DATA_DIRECTORY IAT;

		// Token: 0x0400009D RID: 157
		[FieldOffset(200)]
		public IMAGE_DATA_DIRECTORY DelayImportDescriptor;

		// Token: 0x0400009E RID: 158
		[FieldOffset(208)]
		public IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

		// Token: 0x0400009F RID: 159
		[FieldOffset(216)]
		public IMAGE_DATA_DIRECTORY Reserved;
	}
}
