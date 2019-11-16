using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002C RID: 44
	public class PIMAGE_IMPORT_BY_NAME : ManagedPtr<IMAGE_IMPORT_BY_NAME>
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00003AFB File Offset: 0x00001CFB
		public PIMAGE_IMPORT_BY_NAME(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003B04 File Offset: 0x00001D04
		public PIMAGE_IMPORT_BY_NAME(object value) : base(value, true)
		{
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003B0E File Offset: 0x00001D0E
		public static PIMAGE_IMPORT_BY_NAME operator +(PIMAGE_IMPORT_BY_NAME c1, int c2)
		{
			return new PIMAGE_IMPORT_BY_NAME(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003B28 File Offset: 0x00001D28
		public static PIMAGE_IMPORT_BY_NAME operator ++(PIMAGE_IMPORT_BY_NAME a)
		{
			return a + 1;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003B31 File Offset: 0x00001D31
		public new static explicit operator PIMAGE_IMPORT_BY_NAME(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_IMPORT_BY_NAME(ptr);
		}
	}
}
