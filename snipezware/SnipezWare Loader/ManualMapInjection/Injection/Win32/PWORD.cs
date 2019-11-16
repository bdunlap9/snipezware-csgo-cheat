using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x0200002A RID: 42
	public class PWORD : ManagedPtr<ushort>
	{
		// Token: 0x06000068 RID: 104 RVA: 0x00003A61 File Offset: 0x00001C61
		public PWORD(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003A6A File Offset: 0x00001C6A
		public PWORD(object value) : base(value, true)
		{
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003A74 File Offset: 0x00001C74
		public static PWORD operator +(PWORD c1, int c2)
		{
			return new PWORD(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003A8E File Offset: 0x00001C8E
		public static PWORD operator ++(PWORD a)
		{
			return a + 1;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003A97 File Offset: 0x00001C97
		public new static explicit operator PWORD(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PWORD(ptr);
		}
	}
}
