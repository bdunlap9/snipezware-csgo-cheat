using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000023 RID: 35
	public class PIMAGE_NT_HEADERS32 : ManagedPtr<IMAGE_NT_HEADERS32>
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00003885 File Offset: 0x00001A85
		public PIMAGE_NT_HEADERS32(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000388E File Offset: 0x00001A8E
		public PIMAGE_NT_HEADERS32(object value) : base(value, true)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003898 File Offset: 0x00001A98
		public new static explicit operator PIMAGE_NT_HEADERS32(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_NT_HEADERS32(ptr);
		}
	}
}
