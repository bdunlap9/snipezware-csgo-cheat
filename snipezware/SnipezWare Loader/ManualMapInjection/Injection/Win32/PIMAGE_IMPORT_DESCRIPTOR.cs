using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000026 RID: 38
	public class PIMAGE_IMPORT_DESCRIPTOR : ManagedPtr<IMAGE_IMPORT_DESCRIPTOR>
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00003950 File Offset: 0x00001B50
		public PIMAGE_IMPORT_DESCRIPTOR(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003959 File Offset: 0x00001B59
		public PIMAGE_IMPORT_DESCRIPTOR(object value) : base(value, true)
		{
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003963 File Offset: 0x00001B63
		public static PIMAGE_IMPORT_DESCRIPTOR operator +(PIMAGE_IMPORT_DESCRIPTOR c1, int c2)
		{
			return new PIMAGE_IMPORT_DESCRIPTOR(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000397D File Offset: 0x00001B7D
		public static PIMAGE_IMPORT_DESCRIPTOR operator ++(PIMAGE_IMPORT_DESCRIPTOR a)
		{
			return a + 1;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003986 File Offset: 0x00001B86
		public new static explicit operator PIMAGE_IMPORT_DESCRIPTOR(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_IMPORT_DESCRIPTOR(ptr);
		}
	}
}
