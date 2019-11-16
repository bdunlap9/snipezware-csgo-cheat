using System;
using ManualMapInjection.Injection.Types;

namespace ManualMapInjection.Injection.Win32
{
	// Token: 0x02000025 RID: 37
	public class PPROCESS_BASIC_INFORMATION : ManagedPtr<PROCESS_BASIC_INFORMATION>
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00003926 File Offset: 0x00001B26
		public PPROCESS_BASIC_INFORMATION(IntPtr address) : base(address)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000392F File Offset: 0x00001B2F
		public PPROCESS_BASIC_INFORMATION(object value) : base(value, true)
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003939 File Offset: 0x00001B39
		public new static explicit operator PPROCESS_BASIC_INFORMATION(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			return new PPROCESS_BASIC_INFORMATION(ptr);
		}
	}
}
