using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Loader.Properties
{
	// Token: 0x02000039 RID: 57
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00007B13 File Offset: 0x00005D13
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00007B1A File Offset: 0x00005D1A
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00007B2C File Offset: 0x00005D2C
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Username
		{
			get
			{
				return (string)this["Username"];
			}
			set
			{
				this["Username"] = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00007B3A File Offset: 0x00005D3A
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00007B4C File Offset: 0x00005D4C
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public string Password
		{
			get
			{
				return (string)this["Password"];
			}
			set
			{
				this["Password"] = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00007B5A File Offset: 0x00005D5A
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00007B6C File Offset: 0x00005D6C
		[UserScopedSetting]
		[DefaultSettingValue("False")]
		[DebuggerNonUserCode]
		public bool Checked
		{
			get
			{
				return (bool)this["Checked"];
			}
			set
			{
				this["Checked"] = value;
			}
		}

		// Token: 0x04000176 RID: 374
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
