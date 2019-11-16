using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000022 RID: 34
	public class PIMAGE_DOS_HEADER : ManagedPtr<IMAGE_DOS_HEADER>
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000385B File Offset: 0x00001A5B
		public PIMAGE_DOS_HEADER(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003864 File Offset: 0x00001A64
		public PIMAGE_DOS_HEADER(object value) : base(value, true)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000386E File Offset: 0x00001A6E
		public new static explicit operator PIMAGE_DOS_HEADER(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_DOS_HEADER(ptr);
		}
	}
}
