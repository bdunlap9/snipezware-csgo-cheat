using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002F RID: 47
	public class PSHORT : ManagedPtr<short>
	{
		// Token: 0x06000081 RID: 129 RVA: 0x00003BE2 File Offset: 0x00001DE2
		public PSHORT(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003BEB File Offset: 0x00001DEB
		public PSHORT(object value) : base(value, true)
		{
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003BF5 File Offset: 0x00001DF5
		public static PSHORT operator +(PSHORT c1, int c2)
		{
			return new PSHORT(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003C0F File Offset: 0x00001E0F
		public static PSHORT operator ++(PSHORT a)
		{
			return a + 1;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003C18 File Offset: 0x00001E18
		public new static explicit operator PSHORT(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PSHORT(ptr);
		}
	}
}
