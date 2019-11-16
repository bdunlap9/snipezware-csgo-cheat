using System;
using System.Runtime.InteropServices;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200000B RID: 11
	public struct IMAGE_DOS_HEADER
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000372A File Offset: 0x0000192A
		private string _e_magic
		{
			get
			{
				return new string(this.e_magic);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00003737 File Offset: 0x00001937
		public bool isValid
		{
			get
			{
				return this._e_magic == "MZ";
			}
		}

		// Token: 0x04000056 RID: 86
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public char[] e_magic;

		// Token: 0x04000057 RID: 87
		public ushort e_cblp;

		// Token: 0x04000058 RID: 88
		public ushort e_cp;

		// Token: 0x04000059 RID: 89
		public ushort e_crlc;

		// Token: 0x0400005A RID: 90
		public ushort e_cparhdr;

		// Token: 0x0400005B RID: 91
		public ushort e_minalloc;

		// Token: 0x0400005C RID: 92
		public ushort e_maxalloc;

		// Token: 0x0400005D RID: 93
		public ushort e_ss;

		// Token: 0x0400005E RID: 94
		public ushort e_sp;

		// Token: 0x0400005F RID: 95
		public ushort e_csum;

		// Token: 0x04000060 RID: 96
		public ushort e_ip;

		// Token: 0x04000061 RID: 97
		public ushort e_cs;

		// Token: 0x04000062 RID: 98
		public ushort e_lfarlc;

		// Token: 0x04000063 RID: 99
		public ushort e_ovno;

		// Token: 0x04000064 RID: 100
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ushort[] e_res1;

		// Token: 0x04000065 RID: 101
		public ushort e_oemid;

		// Token: 0x04000066 RID: 102
		public ushort e_oeminfo;

		// Token: 0x04000067 RID: 103
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public ushort[] e_res2;

		// Token: 0x04000068 RID: 104
		public int e_lfanew;
	}
}
