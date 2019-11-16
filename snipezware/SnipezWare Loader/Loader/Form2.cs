using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using HWIDGrabber;
using Loader.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Loader
{
	// Token: 0x02000035 RID: 53
	public class Form2 : MetroForm
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00004E87 File Offset: 0x00003087
		public Form2()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004E98 File Offset: 0x00003098
		private void Form2_Load(object sender, EventArgs e)
		{
			this.hwid = HWDI.GetMachineGuid();
			if (Settings.Default.Checked)
			{
				this.metroTextBox1.Text = Settings.Default.Username;
				this.metroTextBox2.Text = Settings.Default.Password;
				this.metroCheckBox1.Checked = Settings.Default.Checked;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004EFC File Offset: 0x000030FC
		private void metroButton1_Click(object sender, EventArgs e)
		{
			Settings.Default.Username = this.metroTextBox1.Text;
			Settings.Default.Password = this.metroTextBox2.Text;
			Settings.Default.Checked = this.metroCheckBox1.Checked;
			Settings.Default.Save();
			this.webBrowser1.Navigate(string.Concat(new string[]
			{
				"http://snipez.xyz/loader-files/check.php?username=",
				this.metroTextBox1.Text,
				"&password=",
				this.metroTextBox2.Text,
				"&hwid=",
				this.hwid
			}));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004FA8 File Offset: 0x000031A8
		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (this.webBrowser1.DocumentText.Contains("p1"))
			{
				if (this.webBrowser1.DocumentText.Contains("h1"))
				{
					base.Hide();
					Form3 form = new Form3();
					form.Closed += delegate(object s, EventArgs args)
					{
						base.Close();
					};
					form.Show();
					return;
				}
				if (this.webBrowser1.DocumentText.Contains("h2"))
				{
					MetroMessageBox.Show(this, "Your HWID is Oudated. Message the Admins.", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Process.Start("http://www.snipez.xyz/forum/index.php?board/21-hwid-reset/");
					return;
				}
				if (this.webBrowser1.DocumentText.Contains("h3"))
				{
					MetroMessageBox.Show(this, "Your new HWID was Set.", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (this.webBrowser1.DocumentText.Contains("h4"))
				{
					MetroMessageBox.Show(this, "Error: Can't set new HWID", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			else
			{
				MetroMessageBox.Show(this, "Username and E-Mail do not match!", "SnipezWare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000050AC File Offset: 0x000032AC
		private void E9XGD1KW1MQE()
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

		// Token: 0x060000B0 RID: 176 RVA: 0x0000540C File Offset: 0x0000360C
		private void E9XGD1KW1MQE1241255()
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

		// Token: 0x060000B1 RID: 177 RVA: 0x0000576C File Offset: 0x0000396C
		private void E9XGD1KW1MQE5153231245()
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

		// Token: 0x060000B2 RID: 178 RVA: 0x00005ACC File Offset: 0x00003CCC
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

		// Token: 0x060000B3 RID: 179 RVA: 0x00005E2C File Offset: 0x0000402C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00005E4C File Offset: 0x0000404C
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form2));
			this.metroTextBox1 = new MetroTextBox();
			this.metroTextBox2 = new MetroTextBox();
			this.metroButton1 = new MetroButton();
			this.metroCheckBox1 = new MetroCheckBox();
			this.webBrowser1 = new WebBrowser();
			this.metroLabel2 = new MetroLabel();
			this.pictureBox2 = new PictureBox();
			this.metroLabel1 = new MetroLabel();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.metroTextBox1.CustomButton.Image = null;
			this.metroTextBox1.CustomButton.Location = new Point(258, 1);
			this.metroTextBox1.CustomButton.Name = "";
			this.metroTextBox1.CustomButton.Size = new Size(21, 21);
			this.metroTextBox1.CustomButton.Style = 4;
			this.metroTextBox1.CustomButton.TabIndex = 1;
			this.metroTextBox1.CustomButton.Theme = 1;
			this.metroTextBox1.CustomButton.UseSelectable = true;
			this.metroTextBox1.CustomButton.Visible = false;
			this.metroTextBox1.Lines = new string[0];
			this.metroTextBox1.Location = new Point(23, 134);
			this.metroTextBox1.MaxLength = 32767;
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.PasswordChar = '\0';
			this.metroTextBox1.PromptText = "Forum Username";
			this.metroTextBox1.ScrollBars = ScrollBars.None;
			this.metroTextBox1.SelectedText = "";
			this.metroTextBox1.SelectionLength = 0;
			this.metroTextBox1.SelectionStart = 0;
			this.metroTextBox1.ShortcutsEnabled = true;
			this.metroTextBox1.Size = new Size(280, 23);
			this.metroTextBox1.Style = 2;
			this.metroTextBox1.TabIndex = 0;
			this.metroTextBox1.Theme = 2;
			this.metroTextBox1.UseSelectable = true;
			this.metroTextBox1.WaterMark = "Forum Username";
			this.metroTextBox1.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox1.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.metroTextBox2.CustomButton.Image = null;
			this.metroTextBox2.CustomButton.Location = new Point(258, 1);
			this.metroTextBox2.CustomButton.Name = "";
			this.metroTextBox2.CustomButton.Size = new Size(21, 21);
			this.metroTextBox2.CustomButton.Style = 4;
			this.metroTextBox2.CustomButton.TabIndex = 1;
			this.metroTextBox2.CustomButton.Theme = 1;
			this.metroTextBox2.CustomButton.UseSelectable = true;
			this.metroTextBox2.CustomButton.Visible = false;
			this.metroTextBox2.Lines = new string[0];
			this.metroTextBox2.Location = new Point(23, 163);
			this.metroTextBox2.MaxLength = 32767;
			this.metroTextBox2.Name = "metroTextBox2";
			this.metroTextBox2.PasswordChar = '●';
			this.metroTextBox2.PromptText = "Forum E-Mail";
			this.metroTextBox2.ScrollBars = ScrollBars.None;
			this.metroTextBox2.SelectedText = "";
			this.metroTextBox2.SelectionLength = 0;
			this.metroTextBox2.SelectionStart = 0;
			this.metroTextBox2.ShortcutsEnabled = true;
			this.metroTextBox2.Size = new Size(280, 23);
			this.metroTextBox2.Style = 2;
			this.metroTextBox2.TabIndex = 1;
			this.metroTextBox2.Theme = 2;
			this.metroTextBox2.UseSelectable = true;
			this.metroTextBox2.WaterMark = "Forum E-Mail";
			this.metroTextBox2.WaterMarkColor = Color.FromArgb(109, 109, 109);
			this.metroTextBox2.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
			this.metroButton1.Location = new Point(23, 213);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(280, 23);
			this.metroButton1.Style = 8;
			this.metroButton1.TabIndex = 5;
			this.metroButton1.Text = "Login";
			this.metroButton1.Theme = 2;
			this.metroButton1.UseSelectable = true;
			this.metroButton1.Click += this.metroButton1_Click;
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.CheckAlign = ContentAlignment.MiddleRight;
			this.metroCheckBox1.Location = new Point(172, 192);
			this.metroCheckBox1.Name = "metroCheckBox1";
			this.metroCheckBox1.Size = new Size(131, 15);
			this.metroCheckBox1.Style = 2;
			this.metroCheckBox1.TabIndex = 6;
			this.metroCheckBox1.Text = "Remember my login";
			this.metroCheckBox1.Theme = 2;
			this.metroCheckBox1.UseSelectable = true;
			this.webBrowser1.Location = new Point(23, 328);
			this.webBrowser1.MinimumSize = new Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new Size(250, 250);
			this.webBrowser1.TabIndex = 7;
			this.webBrowser1.DocumentCompleted += this.webBrowser1_DocumentCompleted;
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new Point(23, 103);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new Size(280, 19);
			this.metroLabel2.TabIndex = 11;
			this.metroLabel2.Text = "SnipezWare | snipez.xyz | HvH Premium Cheat.";
			this.metroLabel2.TextAlign = ContentAlignment.TopCenter;
			this.metroLabel2.Theme = 2;
			this.pictureBox2.BackgroundImage = Resources.snipez_logo1;
			this.pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
			this.pictureBox2.Location = new Point(68, 22);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(67, 65);
			this.pictureBox2.TabIndex = 12;
			this.pictureBox2.TabStop = false;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = 2;
			this.metroLabel1.Location = new Point(150, 42);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(123, 25);
			this.metroLabel1.TabIndex = 13;
			this.metroLabel1.Text = "SnipezWare V1";
			this.metroLabel1.TextAlign = ContentAlignment.TopCenter;
			this.metroLabel1.Theme = 2;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(326, 248);
			base.Controls.Add(this.metroLabel1);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.metroLabel2);
			base.Controls.Add(this.webBrowser1);
			base.Controls.Add(this.metroCheckBox1);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.metroTextBox2);
			base.Controls.Add(this.metroTextBox1);
			base.DisplayHeader = false;
			this.ForeColor = SystemColors.ControlText;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form2";
			base.Padding = new Padding(20, 30, 20, 20);
			base.Resizable = false;
			base.ShadowType = 0;
			base.Style = 1;
			this.Text = "Form2";
			base.TextAlign = 1;
			base.Theme = 2;
			base.Load += this.Form2_Load;
			((ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000158 RID: 344
		private string hwid;

		// Token: 0x04000159 RID: 345
		private IContainer components;

		// Token: 0x0400015A RID: 346
		private MetroTextBox metroTextBox1;

		// Token: 0x0400015B RID: 347
		private MetroTextBox metroTextBox2;

		// Token: 0x0400015C RID: 348
		private MetroButton metroButton1;

		// Token: 0x0400015D RID: 349
		private MetroCheckBox metroCheckBox1;

		// Token: 0x0400015E RID: 350
		private WebBrowser webBrowser1;

		// Token: 0x0400015F RID: 351
		private MetroLabel metroLabel2;

		// Token: 0x04000160 RID: 352
		private PictureBox pictureBox2;

		// Token: 0x04000161 RID: 353
		private MetroLabel metroLabel1;
	}
}
