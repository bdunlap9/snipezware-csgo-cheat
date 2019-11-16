using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200001B RID: 27
	public struct IMAGE_LOAD_CONFIG_DIRECTORY32
	{
		// Token: 0x04000105 RID: 261
		public uint Size;

		// Token: 0x04000106 RID: 262
		public uint TimeDateStamp;

		// Token: 0x04000107 RID: 263
		public ushort MajorVersion;

		// Token: 0x04000108 RID: 264
		public ushort MinorVersion;

		// Token: 0x04000109 RID: 265
		public uint GlobalFlagsClear;

		// Token: 0x0400010A RID: 266
		public uint GlobalFlagsSet;

		// Token: 0x0400010B RID: 267
		public uint CriticalSectionDefaultTimeout;

		// Token: 0x0400010C RID: 268
		public uint DeCommitFreeBlockThreshold;

		// Token: 0x0400010D RID: 269
		public uint DeCommitTotalFreeThreshold;

		// Token: 0x0400010E RID: 270
		public uint LockPrefixTable;

		// Token: 0x0400010F RID: 271
		public uint MaximumAllocationSize;

		// Token: 0x04000110 RID: 272
		public uint VirtualMemoryThreshold;

		// Token: 0x04000111 RID: 273
		public uint ProcessHeapFlags;

		// Token: 0x04000112 RID: 274
		public uint ProcessAffinityMask;

		// Token: 0x04000113 RID: 275
		public ushort CSDVersion;

		// Token: 0x04000114 RID: 276
		public ushort Reserved1;

		// Token: 0x04000115 RID: 277
		public uint EditList;

		// Token: 0x04000116 RID: 278
		public uint SecurityCookie;

		// Token: 0x04000117 RID: 279
		public uint SEHandlerTable;

		// Token: 0x04000118 RID: 280
		public uint SEHandlerCount;

		// Token: 0x04000119 RID: 281
		public uint GuardCFCheckFunctionPointer;

		// Token: 0x0400011A RID: 282
		public uint Reserved2;

		// Token: 0x0400011B RID: 283
		public uint GuardCFFunctionTable;

		// Token: 0x0400011C RID: 284
		public uint GuardCFFunctionCount;

		// Token: 0x0400011D RID: 285
		public uint GuardFlags;
	}
}
