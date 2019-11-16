using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Loader.Properties
{
	// Token: 0x02000038 RID: 56
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x000036E8 File Offset: 0x000018E8
		internal Resources()
		{
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00007ABD File Offset: 0x00005CBD
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Loader.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00007AE9 File Offset: 0x00005CE9
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00007AF0 File Offset: 0x00005CF0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00007AF8 File Offset: 0x00005CF8
		internal static Bitmap snipez_logo1
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("snipez logo1", Resources.resourceCulture);
			}
		}

		// Token: 0x04000174 RID: 372
		private static ResourceManager resourceMan;

		// Token: 0x04000175 RID: 373
		private static CultureInfo resourceCulture;
	}
}
