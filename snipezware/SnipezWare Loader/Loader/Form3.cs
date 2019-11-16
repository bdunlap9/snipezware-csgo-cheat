using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Loader.Properties;
using ManualMapInjection.Injection;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Loader
{
	// Token: 0x02000036 RID: 54
	public class Form3 : MetroForm
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00006704 File Offset: 0x00004904
		public Form3()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006728 File Offset: 0x00004928
		private void Form3_Load(object sender, EventArgs e)
		{
			this.metroLabel5.Text = "Welcome back \n" + Settings.Default.Username;
			this.webBrowser1.Navigate("http://snipez.xyz/loader-files/check.php?username=" + Settings.Default.Username + "&password=0&hwid=0");
			this.webBrowser2.Navigate("http://snipez.xyz/loader-files/changelog.txt");
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006788 File Offset: 0x00004988
		private void metroLabel1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/YYv8kXK");
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006795 File Offset: 0x00004995
		private void metroLabel2_Click(object sender, EventArgs e)
		{
			Process.Start("http://snipez.xyz/forum/");
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000067A2 File Offset: 0x000049A2
		private void metroLabel3_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.snipez.xyz/forum/index.php?board/14-snipezware-support/");
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000067AF File Offset: 0x000049AF
		private void metroLabel4_Click(object sender, EventArgs e)
		{
			if (MetroMessageBox.Show(this, "Are you sure you want to quit the injector?", "SnipezWare", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000067CC File Offset: 0x000049CC
		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.metroComboBox1.Items.Add("SnipezWare Beta");
			this.metroComboBox1.Items.Add("SnipezWare Public");
			this.metroComboBox1.Items.Add("");
			this.metroComboBox1.Items.Add("onecrack (broken)");
			this.webBrowser1.Dispose();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000683C File Offset: 0x00004A3C
		private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			string text = this.webBrowser2.Document.Body.InnerHtml;
			text = text.Remove(0, 5);
			text = text.Remove(text.Length - 6, 6);
			this.metroTextBox1.Text = text;
			this.webBrowser2.Dispose();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006890 File Offset: 0x00004A90
		private void metroButton1_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.metroComboBox1.SelectedIndex;
			if (this.metroComboBox1.SelectedIndex == 0)
			{
				this.Inject("http://snipez.xyz/loader-files/dll/beta.crypt");
				return;
			}
			if (this.metroComboBox1.SelectedIndex == 1)
			{
				this.Inject("http://snipez.xyz/loader-files/dll/pub.crypt");
				return;
			}
			if (this.metroComboBox1.SelectedIndex == 3)
			{
				this.Inject("http://snipez.xyz/loader-files/dll/onecrack.crypt");
				return;
			}
			if (this.metroComboBox1.SelectedIndex == -1 || this.metroComboBox1.SelectedIndex == 2)
			{
				MetroMessageBox.Show(this, "Nothing selected", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006928 File Offset: 0x00004B28
		private void Inject(string webPath)
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SnipezWare\\";
			string text2 = text + "sw.crypt";
			string text3 = text + "sw.load";
			Process process = Process.GetProcessesByName("csgo").FirstOrDefault<Process>();
			if (process != null)
			{
				using (WebClient webClient = new WebClient())
				{
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					webClient.DownloadFile(webPath, text2);
				}
				if (!File.Exists(text2))
				{
					MetroMessageBox.Show(this, "Error: An unexpected error happened, loader will now restart", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Application.Restart();
				}
				this.FileDecrypt(text2, text3, "cFjN4P5WaLBnfBGbRufVz256m2sdXQZm44s9pKq6FPkrpr7wKHdtuJmNA3kX7h");
				ManualMapInjector manualMapInjector = new ManualMapInjector(process)
				{
					AsyncInjection = false
				};
				this.metroLabel9.Text = string.Format("hmodule = 0x{0:x8}", manualMapInjector.Inject(text3).ToInt64());
				File.Delete(text2);
				File.Delete(text3);
				if (this.metroCheckBox1.Checked)
				{
					Application.Exit();
					return;
				}
			}
			else
			{
				MetroMessageBox.Show(this, "Error: You need to have CSGO open to inject!", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006A50 File Offset: 0x00004C50
		private void FileDecrypt(string inputFile, string outputFile, string password)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] array = new byte[32];
			FileStream fileStream = new FileStream(inputFile, FileMode.Open);
			fileStream.Read(array, 0, array.Length);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(bytes, array, 50000);
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
			rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.Mode = CipherMode.CFB;
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Read);
			FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
			byte[] array2 = new byte[1048576];
			try
			{
				int count;
				while ((count = cryptoStream.Read(array2, 0, array2.Length)) > 0)
				{
					Application.DoEvents();
					fileStream2.Write(array2, 0, count);
				}
			}
			catch (CryptographicException ex)
			{
				Console.WriteLine("CryptographicException error: " + ex.Message);
			}
			catch (Exception ex2)
			{
				Console.WriteLine("Error: " + ex2.Message);
			}
			try
			{
				cryptoStream.Close();
			}
			catch (Exception ex3)
			{
				Console.WriteLine("Error by closing CryptoStream: " + ex3.Message);
			}
			finally
			{
				fileStream2.Close();
				fileStream.Close();
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00006BCC File Offset: 0x00004DCC
		private void E9XGD1KW124MQE()
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

		// Token: 0x060000C2 RID: 194 RVA: 0x00006F2C File Offset: 0x0000512C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006F4C File Offset: 0x0000514C
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form3));
			this.metroLabel1 = new MetroLabel();
			this.metroLabel2 = new MetroLabel();
			this.metroLabel3 = new MetroLabel();
			this.webBrowser1 = new WebBrowser();
			this.webBrowser2 = new WebBrowser();
			this.metroLabel4 = new MetroLabel();
			this.metroComboBox1 = new MetroComboBox();
			this.metroLabel5 = new MetroLabel();
			this.metroCheckBox1 = new MetroCheckBox();
			this.metroButton1 = new MetroButton();
			this.metroLabel8 = new MetroLabel();
			this.metroLabel9 = new MetroLabel();
			this.pictureBox5 = new PictureBox();
			this.metroTextBox1 = new MetroTextBox();
			this.timer1 = new Timer(this.components);
			((ISupportInitialize)this.pictureBox5).BeginInit();
			base.SuspendLayout();
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = 0;
			this.metroLabel1.Location = new Point(83, 15);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(45, 15);
			this.metroLabel1.TabIndex = 6;
			this.metroLabel1.Text = "Discord";
			this.metroLabel1.Theme = 2;
			this.metroLabel1.Click += this.metroLabel1_Click;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = 0;
			this.metroLabel2.Location = new Point(134, 15);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new Size(45, 15);
			this.metroLabel2.TabIndex = 7;
			this.metroLabel2.Text = "Forums";
			this.metroLabel2.Theme = 2;
			this.metroLabel2.Click += this.metroLabel2_Click;
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontSize = 0;
			this.metroLabel3.Location = new Point(185, 15);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new Size(49, 15);
			this.metroLabel3.TabIndex = 8;
			this.metroLabel3.Text = "Support";
			this.metroLabel3.Theme = 2;
			this.metroLabel3.Click += this.metroLabel3_Click;
			this.webBrowser1.Location = new Point(156, 349);
			this.webBrowser1.MinimumSize = new Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new Size(250, 149);
			this.webBrowser1.TabIndex = 9;
			this.webBrowser1.DocumentCompleted += this.webBrowser1_DocumentCompleted;
			this.webBrowser2.Location = new Point(156, 349);
			this.webBrowser2.MinimumSize = new Size(20, 20);
			this.webBrowser2.Name = "webBrowser2";
			this.webBrowser2.Size = new Size(250, 149);
			this.webBrowser2.TabIndex = 9;
			this.webBrowser2.DocumentCompleted += this.webBrowser2_DocumentCompleted;
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.FontSize = 0;
			this.metroLabel4.Location = new Point(240, 15);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new Size(24, 15);
			this.metroLabel4.TabIndex = 11;
			this.metroLabel4.Text = "Exit";
			this.metroLabel4.Theme = 2;
			this.metroLabel4.Click += this.metroLabel4_Click;
			this.metroComboBox1.FormattingEnabled = true;
			this.metroComboBox1.ItemHeight = 23;
			this.metroComboBox1.Location = new Point(264, 50);
			this.metroComboBox1.Name = "metroComboBox1";
			this.metroComboBox1.PromptText = "Select Version";
			this.metroComboBox1.Size = new Size(177, 29);
			this.metroComboBox1.Style = 3;
			this.metroComboBox1.TabIndex = 12;
			this.metroComboBox1.Theme = 2;
			this.metroComboBox1.UseSelectable = true;
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new Point(80, 41);
			this.metroLabel5.MaximumSize = new Size(185, 40);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new Size(95, 38);
			this.metroLabel5.TabIndex = 13;
			this.metroLabel5.Text = "Welcome back\r\nUser";
			this.metroLabel5.Theme = 2;
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.Checked = true;
			this.metroCheckBox1.CheckState = CheckState.Checked;
			this.metroCheckBox1.Location = new Point(283, 265);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new Size(158, 15);
			this.metroCheckBox1.Style = 2;
			this.metroCheckBox1.TabIndex = 14;
			this.metroCheckBox1.Text = "Exit Loader After Injection";
			this.metroCheckBox1.Theme = 2;
			this.metroCheckBox1.UseSelectable = true;
			this.metroButton1.Location = new Point(10, 257);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(200, 23);
			this.metroButton1.TabIndex = 18;
			this.metroButton1.Text = "Inject Cheat";
			this.metroButton1.Theme = 2;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += this.metroButton1_Click;
			this.metroLabel8.AutoSize = true;
			this.metroLabel8.FontSize = 0;
			this.metroLabel8.Location = new Point(277, 32);
			this.metroLabel8.Name = "metroLabel8";
			this.metroLabel8.Size = new Size(164, 15);
			this.metroLabel8.TabIndex = 19;
			this.metroLabel8.Text = "Please select your cheat to load";
			this.metroLabel8.Theme = 2;
			this.metroLabel9.AutoSize = true;
			this.metroLabel9.FontSize = 0;
			this.metroLabel9.Location = new Point(1000, 1);
			this.metroLabel9.Name = "metroLabel9";
			this.metroLabel9.Size = new Size(177, 15);
			this.metroLabel9.TabIndex = 20;
			this.metroLabel9.Text = "Please select your desired settings";
			this.metroLabel9.Theme = 2;
			this.pictureBox5.BackgroundImage = Resources.snipez_logo1;
			this.pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
			this.pictureBox5.Location = new Point(10, 15);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new Size(64, 64);
			this.pictureBox5.TabIndex = 21;
			this.pictureBox5.TabStop = false;
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new Point(267, 2);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new Size(161, 161);
			this.metroTextBox1.CustomButton.Style = 4;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = 1;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[]
			{
				"Loading Changelogs...."
			};
			this.metroTextBox1.Location = new Point(10, 85);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Multiline = true;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.ReadOnly = true;
			this.metroTextBox1.ScrollBars = ScrollBars.Vertical;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new Size(431, 166);
			this.metroTextBox1.TabIndex = 22;
			this.metroTextBox1.Text = "Loading Changelogs....";
			this.metroTextBox1.Theme = 2;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMarkColor = Color.Black;
			this.metroTextBox1.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(451, 289);
			base.Controls.Add(this.metroTextBox1);
			base.Controls.Add(this.pictureBox5);
			base.Controls.Add(this.metroLabel9);
			base.Controls.Add(this.metroLabel8);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.metroCheckBox1);
			base.Controls.Add(this.metroLabel5);
			base.Controls.Add(this.metroComboBox1);
			base.Controls.Add(this.metroLabel4);
			base.Controls.Add(this.webBrowser1);
			base.Controls.Add(this.metroLabel3);
			base.Controls.Add(this.metroLabel2);
			base.Controls.Add(this.metroLabel1);
			base.DisplayHeader = false;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form3";
			base.Padding = new Padding(20, 30, 20, 20);
			base.Resizable = false;
			base.ShadowType = 0;
			base.Style = 1;
			this.Text = "Form3";
			base.Theme = 2;
			base.Load += this.Form3_Load;
			((ISupportInitialize)this.pictureBox5).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000162 RID: 354
		private string KeyText = "ASDfghJKL";

		// Token: 0x04000163 RID: 355
		private string FilePath = "";

		// Token: 0x04000164 RID: 356
		private IContainer components;

		// Token: 0x04000165 RID: 357
		private MetroLabel metroLabel1;

		// Token: 0x04000166 RID: 358
		private MetroLabel metroLabel2;

		// Token: 0x04000167 RID: 359
		private MetroLabel metroLabel3;

		// Token: 0x04000168 RID: 360
		private WebBrowser webBrowser1;

		// Token: 0x04000169 RID: 361
		private WebBrowser webBrowser2;

		// Token: 0x0400016A RID: 362
		private MetroLabel metroLabel4;

		// Token: 0x0400016B RID: 363
		private MetroComboBox metroComboBox1;

		// Token: 0x0400016C RID: 364
		private MetroLabel metroLabel5;

		// Token: 0x0400016D RID: 365
		private MetroCheckBox metroCheckBox1;

		// Token: 0x0400016E RID: 366
		private MetroButton metroButton1;

		// Token: 0x0400016F RID: 367
		private MetroLabel metroLabel8;

		// Token: 0x04000170 RID: 368
		private MetroLabel metroLabel9;

		// Token: 0x04000171 RID: 369
		private PictureBox pictureBox5;

		// Token: 0x04000172 RID: 370
		private MetroTextBox metroTextBox1;

		// Token: 0x04000173 RID: 371
		private Timer timer1;
	}
}
