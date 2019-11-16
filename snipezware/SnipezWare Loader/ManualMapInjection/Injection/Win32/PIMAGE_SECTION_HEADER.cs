using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000027 RID: 39
	public class PIMAGE_SECTION_HEADER : ManagedPtr<IMAGE_SECTION_HEADER>
	{
		// Token: 0x0600005B RID: 91 RVA: 0x0000399D File Offset: 0x00001B9D
		public PIMAGE_SECTION_HEADER(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000039A6 File Offset: 0x00001BA6
		public PIMAGE_SECTION_HEADER(object value) : base(value, true)
		{
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000039B0 File Offset: 0x00001BB0
		public new static explicit operator PIMAGE_SECTION_HEADER(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_SECTION_HEADER(ptr);
		}
	}
}
