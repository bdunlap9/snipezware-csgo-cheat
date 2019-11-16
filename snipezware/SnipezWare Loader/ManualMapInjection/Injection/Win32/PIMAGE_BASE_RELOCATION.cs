using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002E RID: 46
	public class PIMAGE_BASE_RELOCATION : ManagedPtr<IMAGE_BASE_RELOCATION>
	{
		// Token: 0x0600007C RID: 124 RVA: 0x00003B95 File Offset: 0x00001D95
		public PIMAGE_BASE_RELOCATION(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003B9E File Offset: 0x00001D9E
		public PIMAGE_BASE_RELOCATION(object value) : base(value, true)
		{
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003BA8 File Offset: 0x00001DA8
		public static PIMAGE_BASE_RELOCATION operator +(PIMAGE_BASE_RELOCATION c1, int c2)
		{
			return new PIMAGE_BASE_RELOCATION(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003BC2 File Offset: 0x00001DC2
		public static PIMAGE_BASE_RELOCATION operator ++(PIMAGE_BASE_RELOCATION a)
		{
			return a + 1;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003BCB File Offset: 0x00001DCB
		public new static explicit operator PIMAGE_BASE_RELOCATION(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_BASE_RELOCATION(ptr);
		}
	}
}
