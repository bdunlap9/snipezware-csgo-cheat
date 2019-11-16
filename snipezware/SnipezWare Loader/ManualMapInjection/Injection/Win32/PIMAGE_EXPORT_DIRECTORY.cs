using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000029 RID: 41
	public class PIMAGE_EXPORT_DIRECTORY : ManagedPtr<IMAGE_EXPORT_DIRECTORY>
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00003A14 File Offset: 0x00001C14
		public PIMAGE_EXPORT_DIRECTORY(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003A1D File Offset: 0x00001C1D
		public PIMAGE_EXPORT_DIRECTORY(object value) : base(value, true)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003A27 File Offset: 0x00001C27
		public static PIMAGE_EXPORT_DIRECTORY operator +(PIMAGE_EXPORT_DIRECTORY c1, int c2)
		{
			return new PIMAGE_EXPORT_DIRECTORY(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003A41 File Offset: 0x00001C41
		public static PIMAGE_EXPORT_DIRECTORY operator ++(PIMAGE_EXPORT_DIRECTORY a)
		{
			return a + 1;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003A4A File Offset: 0x00001C4A
		public new static explicit operator PIMAGE_EXPORT_DIRECTORY(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PIMAGE_EXPORT_DIRECTORY(ptr);
		}
	}
}
