using System;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000A RID: 10
	[Flags]
	public enum DataSectionFlags : uint
	{
		// Token: 0x0400002C RID: 44
		TypeReg = 0u,
		// Token: 0x0400002D RID: 45
		TypeDsect = 1u,
		// Token: 0x0400002E RID: 46
		TypeNoLoad = 2u,
		// Token: 0x0400002F RID: 47
		TypeGroup = 4u,
		// Token: 0x04000030 RID: 48
		TypeNoPadded = 8u,
		// Token: 0x04000031 RID: 49
		TypeCopy = 16u,
		// Token: 0x04000032 RID: 50
		ContentCode = 32u,
		// Token: 0x04000033 RID: 51
		ContentInitializedData = 64u,
		// Token: 0x04000034 RID: 52
		ContentUninitializedData = 128u,
		// Token: 0x04000035 RID: 53
		LinkOther = 256u,
		// Token: 0x04000036 RID: 54
		LinkInfo = 512u,
		// Token: 0x04000037 RID: 55
		TypeOver = 1024u,
		// Token: 0x04000038 RID: 56
		LinkRemove = 2048u,
		// Token: 0x04000039 RID: 57
		LinkComDat = 4096u,
		// Token: 0x0400003A RID: 58
		NoDeferSpecExceptions = 16384u,
		// Token: 0x0400003B RID: 59
		RelativeGP = 32768u,
		// Token: 0x0400003C RID: 60
		MemPurgeable = 131072u,
		// Token: 0x0400003D RID: 61
		Memory16Bit = 131072u,
		// Token: 0x0400003E RID: 62
		MemoryLocked = 262144u,
		// Token: 0x0400003F RID: 63
		MemoryPreload = 524288u,
		// Token: 0x04000040 RID: 64
		Align1Bytes = 1048576u,
		// Token: 0x04000041 RID: 65
		Align2Bytes = 2097152u,
		// Token: 0x04000042 RID: 66
		Align4Bytes = 3145728u,
		// Token: 0x04000043 RID: 67
		Align8Bytes = 4194304u,
		// Token: 0x04000044 RID: 68
		Align16Bytes = 5242880u,
		// Token: 0x04000045 RID: 69
		Align32Bytes = 6291456u,
		// Token: 0x04000046 RID: 70
		Align64Bytes = 7340032u,
		// Token: 0x04000047 RID: 71
		Align128Bytes = 8388608u,
		// Token: 0x04000048 RID: 72
		Align256Bytes = 9437184u,
		// Token: 0x04000049 RID: 73
		Align512Bytes = 10485760u,
		// Token: 0x0400004A RID: 74
		Align1024Bytes = 11534336u,
		// Token: 0x0400004B RID: 75
		Align2048Bytes = 12582912u,
		// Token: 0x0400004C RID: 76
		Align4096Bytes = 13631488u,
		// Token: 0x0400004D RID: 77
		Align8192Bytes = 14680064u,
		// Token: 0x0400004E RID: 78
		LinkExtendedRelocationOverflow = 16777216u,
		// Token: 0x0400004F RID: 79
		MemoryDiscardable = 33554432u,
		// Token: 0x04000050 RID: 80
		MemoryNotCached = 67108864u,
		// Token: 0x04000051 RID: 81
		MemoryNotPaged = 134217728u,
		// Token: 0x04000052 RID: 82
		MemoryShared = 268435456u,
		// Token: 0x04000053 RID: 83
		MemoryExecute = 536870912u,
		// Token: 0x04000054 RID: 84
		MemoryRead = 1073741824u,
		// Token: 0x04000055 RID: 85
		MemoryWrite = 2147483648u
	}
}
