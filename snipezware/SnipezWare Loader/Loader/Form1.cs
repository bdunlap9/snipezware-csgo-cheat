using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;
using Loader.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Loader
{
	// Token: 0x02000034 RID: 52
	public class Form1 : MetroForm
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x00003F10 File Offset: 0x00002110
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003F20 File Offset: 0x00002120
		private void Form1_Load(object sender, EventArgs e)
		{
			this.version = 1003;
			if (new Ping().Send("www.snipez.xyz").Status == IPStatus.Success)
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)WebRequest.Create("http://snipez.xyz/loader-files/version.txt").GetResponse();
				if (httpWebResponse == null || httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					MetroMessageBox.Show(this, "CAN'T CONNECT TO SNIPEZWARE!", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Application.Exit();
				}
				else
				{
					this.timer1.Start();
				}
			}
			else
			{
				MetroMessageBox.Show(this, "CAN'T CONNECT TO SNIPEZWARE!", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Application.Exit();
			}
			string path = "C:\\Users\\Public\\Documents\\LoaderPath.txt";
			if (File.Exists(path))
			{
				using (StreamReader streamReader = File.OpenText(path))
				{
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						this.oldexepath = text;
					}
					streamReader.Close();
				}
			}
			if (File.Exists(this.oldexepath))
			{
				File.Delete(this.oldexepath);
				File.Delete(path);
			}
			using (WebResponse response = WebRequest.Create("http://snipez.xyz/loader-files/status.txt").GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					using (StreamReader streamReader2 = new StreamReader(responseStream))
					{
						string a = streamReader2.ReadToEnd();
						if (a == "0")
						{
							MetroMessageBox.Show(this, "Error: SnipezWare has been locked!", "SneipzWare Locked!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							Application.Exit();
						}
						else if (!(a == "1"))
						{
							if (a == "2")
							{
								MetroMessageBox.Show(this, "Error: SnipezWare is currently Updating! Sorry for the inconvenience.", "SnipezWare Under Maintenance!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else if (a == "3")
							{
								MetroMessageBox.Show(this, "Error: SnipezWare use on own risk! There may have been a VAC detection!", "SnipezWare Detected!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
					}
				}
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004118 File Offset: 0x00002318
		private void timer1_Tick(object sender, EventArgs e)
		{
			using (WebResponse response = WebRequest.Create("http://snipez.xyz/loader-files/version.txt").GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(responseStream))
					{
						string b = streamReader.ReadToEnd();
						if (this.version.ToString() != b)
						{
							this.metroLabel3.Text = "Status: Updating...";
							this.timer1.Stop();
							this.timer2.Start();
						}
						else
						{
							this.metroLabel2.Text = "SnipezWare up to date!";
							this.metroLabel3.Text = "Status: No updates where found..";
							this.timer4.Start();
							this.timer1.Stop();
						}
					}
				}
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004204 File Offset: 0x00002404
		private void timer2_Tick(object sender, EventArgs e)
		{
			this.metroLabel3.Text = "Status: Downloading update...";
			this.timer2.Stop();
			string path = "C:\\Users\\Public\\Documents\\LoaderPath.txt";
			if (!File.Exists(path))
			{
				using (StreamWriter streamWriter = File.CreateText(path))
				{
					streamWriter.WriteLine(Assembly.GetEntryAssembly().Location);
				}
			}
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			char[] array = new char[8];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			string str = new string(array);
			new WebClient().DownloadFile("http://snipez.xyz/loader-files/update.exe", Directory.GetCurrentDirectory() + "/" + str + ".exe");
			Process.Start(Directory.GetCurrentDirectory() + "/" + str + ".exe");
			Application.Exit();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000042FC File Offset: 0x000024FC
		private void timer4_Tick(object sender, EventArgs e)
		{
			this.timer4.Stop();
			base.Hide();
			Form2 form = new Form2();
			form.Closed += delegate(object s, EventArgs args)
			{
				base.Close();
			};
			form.Show();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000432B File Offset: 0x0000252B
		private void timer5_Tick(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004334 File Offset: 0x00002534
		private void E9XGD1KW1MQE5153235()
		{
			int num = 251367137;
			if (num <= 251367106)
			{
				if (num <= 251367196)
				{
					num++;
				}
			}
			int num2 = 251367190;
			if (num2 <= 251367145)
			{
				if (num2 <= 251367131)
				{
					num2++;
				}
			}
			int num3 = 251367191;
			if (num3 <= 251367159)
			{
				if (num3 <= 251367108)
				{
					num3++;
				}
			}
			int num4 = 251367124;
			if (num4 <= 251367131)
			{
				if (num4 <= 251367114)
				{
					num4++;
				}
			}
			int num5 = 251367158;
			if (num5 <= 251367145)
			{
				if (num5 <= 251367109)
				{
					num5++;
				}
			}
			int num6 = 251367174;
			if (num6 <= 251367169)
			{
				if (num6 <= 251367181)
				{
					num6++;
				}
			}
			int num7 = 251367158;
			if (num7 <= 251367165)
			{
				if (num7 <= 251367199)
				{
					num7++;
				}
			}
			int num8 = 251367174;
			if (num8 <= 251367167)
			{
				if (num8 <= 251367168)
				{
					num8++;
				}
			}
			int num9 = 251367168;
			if (num9 <= 251367161)
			{
				if (num9 <= 251367121)
				{
					num9++;
				}
			}
			int num10 = 251367199;
			if (num10 <= 251367138)
			{
				if (num10 <= 251367181)
				{
					num10++;
				}
			}
			int num11 = 251367183;
			if (num11 <= 251367177)
			{
				if (num11 <= 251367138)
				{
					num11++;
				}
			}
			int num12 = 251367110;
			if (num12 <= 251367164)
			{
				if (num12 <= 251367165)
				{
					num12++;
				}
			}
			int num13 = 251367179;
			if (num13 <= 251367129)
			{
				if (num13 <= 251367103)
				{
					num13++;
				}
			}
			int num14 = 251367170;
			if (num14 <= 251367198)
			{
				if (num14 <= 251367143)
				{
					num14++;
				}
			}
			int num15 = 251367143;
			if (num15 <= 251367129)
			{
				if (num15 <= 251367163)
				{
					num15++;
				}
			}
			int num16 = 251367173;
			if (num16 <= 251367102)
			{
				if (num16 <= 251367194)
				{
					num16++;
				}
			}
			int num17 = 251367142;
			if (num17 <= 251367107)
			{
				if (num17 <= 251367179)
				{
					num17++;
				}
			}
			int num18 = 251367118;
			if (num18 <= 251367171)
			{
				if (num18 <= 251367104)
				{
					num18++;
				}
			}
			int num19 = 251367121;
			if (num19 > 251367126)
			{
				return;
			}
			if (num19 <= 251367143)
			{
				num19++;
				return;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004694 File Offset: 0x00002894
		private void E9XGD1KW1MQE9812()
		{
			int num = 251367137;
			if (num <= 251367106)
			{
				if (num <= 251367196)
				{
					num++;
				}
			}
			int num2 = 251367190;
			if (num2 <= 251367145)
			{
				if (num2 <= 251367131)
				{
					num2++;
				}
			}
			int num3 = 251367191;
			if (num3 <= 251367159)
			{
				if (num3 <= 251367108)
				{
					num3++;
				}
			}
			int num4 = 251367124;
			if (num4 <= 251367131)
			{
				if (num4 <= 251367114)
				{
					num4++;
				}
			}
			int num5 = 251367158;
			if (num5 <= 251367145)
			{
				if (num5 <= 251367109)
				{
					num5++;
				}
			}
			int num6 = 251367174;
			if (num6 <= 251367169)
			{
				if (num6 <= 251367181)
				{
					num6++;
				}
			}
			int num7 = 251367158;
			if (num7 <= 251367165)
			{
				if (num7 <= 251367199)
				{
					num7++;
				}
			}
			int num8 = 251367174;
			if (num8 <= 251367167)
			{
				if (num8 <= 251367168)
				{
					num8++;
				}
			}
			int num9 = 251367168;
			if (num9 <= 251367161)
			{
				if (num9 <= 251367121)
				{
					num9++;
				}
			}
			int num10 = 251367199;
			if (num10 <= 251367138)
			{
				if (num10 <= 251367181)
				{
					num10++;
				}
			}
			int num11 = 251367183;
			if (num11 <= 251367177)
			{
				if (num11 <= 251367138)
				{
					num11++;
				}
			}
			int num12 = 251367110;
			if (num12 <= 251367164)
			{
				if (num12 <= 251367165)
				{
					num12++;
				}
			}
			int num13 = 251367179;
			if (num13 <= 251367129)
			{
				if (num13 <= 251367103)
				{
					num13++;
				}
			}
			int num14 = 251367170;
			if (num14 <= 251367198)
			{
				if (num14 <= 251367143)
				{
					num14++;
				}
			}
			int num15 = 251367143;
			if (num15 <= 251367129)
			{
				if (num15 <= 251367163)
				{
					num15++;
				}
			}
			int num16 = 251367173;
			if (num16 <= 251367102)
			{
				if (num16 <= 251367194)
				{
					num16++;
				}
			}
			int num17 = 251367142;
			if (num17 <= 251367107)
			{
				if (num17 <= 251367179)
				{
					num17++;
				}
			}
			int num18 = 251367118;
			if (num18 <= 251367171)
			{
				if (num18 <= 251367104)
				{
					num18++;
				}
			}
			int num19 = 251367121;
			if (num19 > 251367126)
			{
				return;
			}
			if (num19 <= 251367143)
			{
				num19++;
				return;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000049F4 File Offset: 0x00002BF4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004A14 File Offset: 0x00002C14
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			this.metroLabel1 = new MetroLabel();
			this.metroLabel2 = new MetroLabel();
			this.metroLabel3 = new MetroLabel();
			this.timer1 = new Timer(this.components);
			this.timer2 = new Timer(this.components);
			this.timer_rainbow = new Timer(this.components);
			this.timer4 = new Timer(this.components);
			this.timer5 = new Timer(this.components);
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = 2;
			this.metroLabel1.FontWeight = 1;
			this.metroLabel1.Location = new Point(8, 16);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(179, 25);
			this.metroLabel1.Style = 2;
			this.metroLabel1.TabIndex = 1;
			this.metroLabel1.Text = "SnipezWare Launcher";
			this.metroLabel1.Theme = 2;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = 0;
			this.metroLabel2.Location = new Point(23, 53);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new Size(112, 15);
			this.metroLabel2.Style = 2;
			this.metroLabel2.TabIndex = 2;
			this.metroLabel2.Text = "Checking for updates";
			this.metroLabel2.Theme = 2;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontSize = 0;
			this.metroLabel3.Location = new Point(23, 78);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new Size(126, 15);
			this.metroLabel3.Style = 2;
			this.metroLabel3.TabIndex = 3;
			this.metroLabel3.Text = "Status: Checking version";
			this.metroLabel3.Theme = 2;
			this.timer1.Interval = 1500;
			this.timer1.Tick += this.timer1_Tick;
			this.timer2.Interval = 1500;
			this.timer2.Tick += this.timer2_Tick;
			this.timer4.Interval = 1500;
			this.timer4.Tick += this.timer4_Tick;
			this.timer5.Interval = 1500;
			this.timer5.Tick += this.timer5_Tick;
			this.pictureBox1.BackgroundImage = Resources.snipez_logo1;
			this.pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			this.pictureBox1.Location = new Point(213, 44);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(64, 63);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(289, 116);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.metroLabel3);
			base.Controls.Add(this.metroLabel2);
			base.Controls.Add(this.metroLabel1);
			base.DisplayHeader = false;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form1";
			base.Padding = new Padding(20, 30, 20, 20);
			base.Resizable = false;
			base.ShadowType = 0;
			base.Style = 1;
			this.Text = "Form1";
			base.TextAlign = 1;
			base.Theme = 2;
			base.Load += this.Form1_Load;
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400014B RID: 331
		private string oldexepath;

		// Token: 0x0400014C RID: 332
		private int version;

		// Token: 0x0400014D RID: 333
		private int count;

		// Token: 0x0400014E RID: 334
		private IContainer components;

		// Token: 0x0400014F RID: 335
		private MetroLabel metroLabel1;

		// Token: 0x04000150 RID: 336
		private MetroLabel metroLabel2;

		// Token: 0x04000151 RID: 337
		private MetroLabel metroLabel3;

		// Token: 0x04000152 RID: 338
		private Timer timer1;

		// Token: 0x04000153 RID: 339
		private Timer timer2;

		// Token: 0x04000154 RID: 340
		private Timer timer_rainbow;

		// Token: 0x04000155 RID: 341
		private Timer timer4;

		// Token: 0x04000156 RID: 342
		private Timer timer5;

		// Token: 0x04000157 RID: 343
		private PictureBox pictureBox1;
	}
}
