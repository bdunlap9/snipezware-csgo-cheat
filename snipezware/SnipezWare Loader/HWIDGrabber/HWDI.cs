using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace HWIDGrabber
{
	// Token: 0x02000033 RID: 51
	internal class HWDI
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003E74 File Offset: 0x00002074
		public static string GetMachineGuid()
		{
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			string text2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}
	}
}
