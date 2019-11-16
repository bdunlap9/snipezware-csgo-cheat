using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000028 RID: 40
	public class PIMAGE_THUNK_DATA : ManagedPtr<IMAGE_THUNK_DATA>
	{
		// Token: 0x0600005E RID: 94 RVA: 0x000039C7 File Offset: 0x00001BC7
		public PIMAGE_THUNK_DATA(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000039D0 File Offset: 0x00001BD0
		public PIMAGE_THUNK_DATA(object value) : base(value, true)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000039DA File Offset: 0x00001BDA
		public static PIMAGE_THUNK_DATA operator +(PIMAGE_THUNK_DATA c1, int c2)
		{
			return new PIMAGE_THUNK_DATA(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000039F4 File Offset: 0x00001BF4
		public static PIMAGE_THUNK_DATA operator ++(PIMAGE_THUNK_DATA a)
		{
			return a + 1;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000039FD File Offset: 0x00001BFD
		public new static explicit operator PIMAGE_THUNK_DATA(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_THUNK_DATA(ptr);
		}
	}
}
