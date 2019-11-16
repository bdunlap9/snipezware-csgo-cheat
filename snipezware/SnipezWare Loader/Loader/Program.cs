using System;
using System.Windows.Forms;

namespace Loader
{
	// Token: 0x02000037 RID: 55
	internal static class Program
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x00007AA6 File Offset: 0x00005CA6
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
