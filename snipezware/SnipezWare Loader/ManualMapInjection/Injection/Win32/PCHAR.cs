using System;
using System.Runtime.InteropServices;
using System.Text;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000024 RID: 36
	public class PCHAR : ManagedPtr<char>
	{
		// Token: 0x0600004C RID: 76 RVA: 0x000038AF File Offset: 0x00001AAF
		public PCHAR(IntPtr address) : base(address)
		{
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000038B8 File Offset: 0x00001AB8
		public PCHAR(object value) : base(value, true)
		{
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000038C2 File Offset: 0x00001AC2
		public PCHAR(string value) : base(Encoding.UTF8.GetBytes(value), true)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000038D6 File Offset: 0x00001AD6
		public static PCHAR operator +(PCHAR c1, int c2)
		{
			return new PCHAR(c1.Address + c2 * c1.StructSize);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000038F0 File Offset: 0x00001AF0
		public static PCHAR operator ++(PCHAR a)
		{
			return a + 1;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000038F9 File Offset: 0x00001AF9
		public new static explicit operator PCHAR(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PCHAR(ptr);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003910 File Offset: 0x00001B10
		public override string ToString()
		{
			return Marshal.PtrToStringAnsi(base.Address) ?? string.Empty;
		}
	}
}
