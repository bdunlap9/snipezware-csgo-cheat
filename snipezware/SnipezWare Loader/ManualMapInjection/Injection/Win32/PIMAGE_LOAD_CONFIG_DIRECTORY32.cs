using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000031 RID: 49
	public class PIMAGE_LOAD_CONFIG_DIRECTORY32 : ManagedPtr<IMAGE_LOAD_CONFIG_DIRECTORY32>
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00003C7C File Offset: 0x00001E7C
		public PIMAGE_LOAD_CONFIG_DIRECTORY32(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003C85 File Offset: 0x00001E85
		public PIMAGE_LOAD_CONFIG_DIRECTORY32(object value) : base(value, true)
		{
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003C8F File Offset: 0x00001E8F
		public static PIMAGE_LOAD_CONFIG_DIRECTORY32 operator +(PIMAGE_LOAD_CONFIG_DIRECTORY32 c1, int c2)
		{
			return new PIMAGE_LOAD_CONFIG_DIRECTORY32(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003CA9 File Offset: 0x00001EA9
		public static PIMAGE_LOAD_CONFIG_DIRECTORY32 operator ++(PIMAGE_LOAD_CONFIG_DIRECTORY32 a)
		{
			return a + 1;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003CB2 File Offset: 0x00001EB2
		public new static explicit operator PIMAGE_LOAD_CONFIG_DIRECTORY32(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_LOAD_CONFIG_DIRECTORY32(ptr);
		}
	}
}
