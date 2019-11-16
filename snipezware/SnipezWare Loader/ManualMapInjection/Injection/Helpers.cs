using System;
using System.Text;

namespace ManualMapInjection.Injection
{
	// Token: 0x02000002 RID: 2
	internal static class Helpers
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		internal static string ToStringAnsi(byte[] buffer)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in buffer)
			{
				if (b == 0)
				{
					break;
				}
				stringBuilder.Append((char)b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002090 File Offset: 0x00000290
		internal static bool _stricmp(char[] str1, char[] str2)
		{
			int num = Math.Min(str1.Length, str2.Length);
			for (int i = 0; i < num; i++)
			{
				if (str1[i] != str2[i])
				{
					return false;
				}
				if (str1[i] == '\0')
				{
					break;
				}
			}
			return true;
		}
	}
}
