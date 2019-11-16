using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002B RID: 43
	public class PDWORD : ManagedPtr<uint>
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00003AAE File Offset: 0x00001CAE
		public PDWORD(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003AB7 File Offset: 0x00001CB7
		public PDWORD(object value) : base(value, true)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003AC1 File Offset: 0x00001CC1
		public static PDWORD operator +(PDWORD c1, int c2)
		{
			return new PDWORD(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003ADB File Offset: 0x00001CDB
		public static PDWORD operator ++(PDWORD a)
		{
			return a + 1;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003AE4 File Offset: 0x00001CE4
		public new static explicit operator PDWORD(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PDWORD(ptr);
		}
	}
}
