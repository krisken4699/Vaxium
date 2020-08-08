using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;
using System.Diagnostics;
using System.IO;
using Guna.UI.WinForms;


namespace Vaxium_V._2_I2
{
    public partial class Form1 : Form
    {
        ExploitAPI api = new ExploitAPI();
        Point lastPoint;

        public double[] Xram = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] Xcpu = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] Xspn = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int a = 9;

        public Form1()
        {
            InitializeComponent();
            hideUI("Minor");
            WelcomeLOGO.Show();
            Title.Show();

            //CheckSpeed\/

            KeepSpeedCheck.Checked = Properties.Settings.Default.Keep;
            
            if(KeepSpeedCheck.Checked == true)
            {
                if(Properties.Settings.Default.Speed.ToString() == "True")
                {
                    CheckSpeed.Checked = true;
                }
                if(Properties.Settings.Default.Speed == true)
                {
                    timer1.Interval = 1000;
                }
                if (Properties.Settings.Default.RemoveBar == true)
                {
                    CheckRemoveBar.Checked = true;
                }
                if (Properties.Settings.Default.Animation == true)
                {
                    CheckAnimation.Checked = true;
                }
            }
            else
            {
                Properties.Settings.Default.Speed = false;
                Properties.Settings.Default.RemoveBar = false;
                Properties.Settings.Default.Animation = false;
            }

        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }


        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Properties.Settings.Default.Save();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public int MenuBarPosY = -230;



        private void flatLabel1_Click(object sender, EventArgs e)
        {
            if (MenuBarPosY == -230)
            {
                for (int i = -230; i < 0; i++)
                {
                    QuickH.HideSync(AttachConditionSwitch);
                    MenuBar.SetBounds(0, MenuBarPosY, 100, 290);
                    MenuBarPosY = MenuBarPosY + 1;
                }
                showButtons("major");

            }
            else
            {
                hideUI("major");
                for (int i = -230; i < 0; i++)
                {
                    QuickH.ShowSync(AttachConditionSwitch);
                    MenuBar.SetBounds(0, MenuBarPosY, 100, 290);
                    MenuBarPosY--;
                }  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hideUI("major");
            hideUI("minor");
            Title.Show();
            WelcomeLOGO.Show();
        }

        public void hideUI(string Size)
        {
            if(Size == "major")
            {
                if (Properties.Settings.Default.Animation)
                {
                SpinTrans.HideSync(Settings);
                SpinTrans.HideSync(PerformanceButton);
                SpinTrans.HideSync(LibraryButton);
                SpinTrans.HideSync(ExecutorButton);
                }
                AttachConditionSwitch.Show();
                ExecutorButton.Hide();
                PerformanceButton.Hide();
                LibraryButton.Hide();
                SelectionPad.Hide();
                Settings.Hide();
            }
            else if(Size == "minor")
            {
                /*if(Properties.Settings.Default.Animation == true)
                {
                    SpinTrans.HideSync(ScriptBox);
                    QuickH.HideSync(ExecuteButton);
                    QuickH.HideSync(ClearButton);
                    QuickH.HideSync(OpenButton);
                    QuickH.HideSync(InjectButton);
                    QuickV.HideSync(SepLineV);
                    QuickH.HideSync(Library);
                    QuickV.HideSync(Bar1);
                    QuickV.HideSync(Bar2);
                    QuickV.HideSync(Bar3);
                    QuickV.HideSync(Bar4);
                    QuickV.HideSync(Bar5);
                    QuickV.HideSync(Bar6);
                    QuickV.HideSync(Bar7);
                    QuickV.HideSync(Bar8);
                    QuickV.HideSync(Bar9);
                    QuickV.HideSync(Bar10);
                    QuickH.HideSync(CPUbar);
                    QuickH.HideSync(KeepSpeedCheck);
                    QuickH.HideSync(CheckAnimation);
                    QuickH.HideSync(CheckRemoveBar);
                    QuickH.HideSync(CheckSpeed);
                    QuickV.HideSync(KillRoblox);
                    QuickV.HideSync(AttachButton);
                    SpinTrans.HideSync(gunaSeparator1);
                }
                */
                ExecuteButton.Hide();
                OpenButton.Hide();
                ScriptBox.Hide();
                ClearButton.Hide();
                Title.Hide();
                InjectButton.Hide();
                WelcomeLOGO.Hide();
                CPUcircle.Hide();
                RAMcircle.Hide();
                timer1.Stop();
                PerformanceChart.Hide();
                Library.Hide();
                CPUbar.Hide();
                KillRoblox.Hide();
                CheckSpeed.Hide();
                gunaSeparator1.Hide();
                AttachButton.Hide();
                TimeLabel.Hide();
                Bar1.Hide();
                Bar2.Hide();
                Bar3.Hide();
                Bar4.Hide();
                Bar5.Hide();
                Bar6.Hide();
                Bar7.Hide();
                Bar8.Hide();
                Bar9.Hide();
                Bar10.Hide();
                KeepSpeedCheck.Hide();
                CheckRemoveBar.Hide();
                CheckAnimation.Hide();
                SepLineV.Hide();
            }
            
        }
        public void showButtons(string Size)
        {
            if (Size == "major")
            {
                if (Properties.Settings.Default.Animation)
                {
                    SpinTrans.ShowSync(PerformanceButton);
                    SpinTrans.ShowSync(LibraryButton);
                    SpinTrans.ShowSync(ExecutorButton);
                    SpinTrans.ShowSync(Settings);
                }
                AttachConditionSwitch.Hide();
                PerformanceButton.Show();
                ExecutorButton.Show();
                LibraryButton.Show();
                Settings.Show();
                SelectionPad.Show();
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            string script = ScriptBox.Text;
            api.SendLuaScript(script);
        }



        private void ExecutorButton_Click(object sender, EventArgs e)
        {
            hideUI("minor"); 
            SelectionPad.SetBounds(SelectionPad.Location.X, ExecutorButton.Location.Y, SelectionPad.Width, SelectionPad.Height);
            if (Properties.Settings.Default.Animation == true)
            {
                SpinTrans.ShowSync(ScriptBox);
                QuickH.ShowSync(ExecuteButton);
                QuickH.ShowSync(ClearButton);
                QuickH.ShowSync(OpenButton);
                QuickH.ShowSync(InjectButton);
                QuickV.ShowSync(SepLineV);
            }
            SepLineV.Show();
            ScriptBox.Show();
            ExecuteButton.Show();
            OpenButton.Show();
            ClearButton.Show();
            InjectButton.Show();
            
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                ScriptBox.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.ScriptBox.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception)
            {
                int num = (int)MessageBox.Show("OH NOSE! Fail to load file...", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ScriptBox.Clear();
        }

        private void InjectButton_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void PerformanceButton_Click(object sender, EventArgs e)
        {
            SelectionPad.SetBounds(SelectionPad.Location.X, PerformanceButton.Location.Y, SelectionPad.Width, SelectionPad.Height);
            hideUI("minor");
            if (CheckRemoveBar.Checked == false)
            {
                if(Properties.Settings.Default.Animation == true)
                {
                    QuickV.ShowSync(Bar1);
                    QuickV.ShowSync(Bar2);
                    QuickV.ShowSync(Bar3);
                    QuickV.ShowSync(Bar4);
                    QuickV.ShowSync(Bar5);
                    QuickV.ShowSync(Bar6);
                    QuickV.ShowSync(Bar7);
                    QuickV.ShowSync(Bar8);
                    QuickV.ShowSync(Bar9);
                    QuickV.ShowSync(Bar10);
                    QuickH.ShowSync(CPUbar);
                }
                Bar1.Show();
                Bar2.Show();
                Bar3.Show();
                Bar4.Show();
                Bar5.Show();
                Bar6.Show();
                Bar7.Show();
                Bar8.Show();
                Bar9.Show();
                Bar10.Show();
                CPUbar.Show();
            }
            if (Properties.Settings.Default.Animation == true)
            {
                QuickH.ShowSync(CPUcircle);
                QuickH.ShowSync(RAMcircle);
                QuickH.ShowSync(PerformanceChart);
                QuickH.ShowSync(TimeLabel);
            }
            CPUcircle.Show();
            RAMcircle.Show();
            timer1.Start();
            PerformanceChart.Show();
            TimeLabel.Show();
        }

        private void CPUcircle_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AttachConditionSwitch.Checked = api.isAPIAttached();
            DateTime now = DateTime.Now;
            api.isAPIAttached();
            a--;

            float fcpu = CPU.NextValue();
            float fram = RAM.NextValue();

            PerformanceChart.Series["SplineCPU"].Points.Clear();
            PerformanceChart.Series["CPU"].Points.Clear();
            PerformanceChart.Series["RAM"].Points.Clear();

            if (a == 8)
            {
                for (int i = 9; i > 0; --i)
                {
                    Xspn[i] = Xspn[(i - 1)];
                }
            }
            for (int i = 99; i > 0; --i)
            {
                Xcpu[i] = Xcpu[(i - 1)];
                Xram[i] = Xram[(i - 1)];
            }

            Xcpu[0] = fcpu;
            Xram[0] = fram;
            Xspn[0] = fcpu;

            PerformanceChart.Series["CPU"].Points.AddY(Xcpu[0]);
            PerformanceChart.Series["RAM"].Points.AddY(Xram[0]);
            PerformanceChart.Series["SplineCPU"].Points.AddY(Xspn[0]);

            for (int i = 1; i < 99; i++)
            {
                //richTextBox1.Text = (Xspn[0].ToString() + " " + Xspn[1].ToString() + " " + Xspn[2].ToString() + " " + Xspn[3].ToString() + " " + Xspn[4].ToString() + " " + Xspn[5].ToString() + " " + Xspn[6].ToString() + " " + Xspn[7].ToString() + " " + Xspn[8].ToString() + " " + Xspn[9].ToString());
                
                PerformanceChart.Series["CPU"].Points.AddY(Xcpu[i]);
                PerformanceChart.Series["RAM"].Points.AddY(Xram[i]);  
            }
            for (int i = 1; i < 10; i++)
            {
                PerformanceChart.Series["SplineCPU"].Points.AddY(Xspn[i]);
            }

            CPUcircle.Value = (int)fcpu;
            CPUcircle.SubscriptText = string.Format("{0:0.0}%", fcpu);

            RAMcircle.Value = (int)fram;
            RAMcircle.SubscriptText = string.Format("{0:0.0}%", fram);
            CPUbar.Value = (int)fcpu;

            TimeLabel.Text = now.Hour.ToString() + ":" + now.Minute.ToString() + "." + now.Second.ToString() + "." + now.Millisecond.ToString();

            if (a == 0) { a = 9; }

            //The Progress V BARS \/
            Bar1.Value = (int)Xcpu[90];
            Bar2.Value = (int)Xcpu[80];
            Bar3.Value = (int)Xcpu[70];
            Bar4.Value = (int)Xcpu[60];
            Bar5.Value = (int)Xcpu[50];
            Bar6.Value = (int)Xcpu[40];
            Bar7.Value = (int)Xcpu[30];
            Bar8.Value = (int)Xcpu[20];
            Bar9.Value = (int)Xcpu[10];
            Bar10.Value = (int)Xcpu[0];



        }

        public void refresh(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }

        }

        private void Library_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptBox.Text = File.ReadAllText($"./Scripts/{Library.SelectedItem}");
        }

        private void LibraryButton_Click(object sender, EventArgs e)
        {
            hideUI("minor");
            SelectionPad.SetBounds(SelectionPad.Location.X, LibraryButton.Location.Y, SelectionPad.Width, SelectionPad.Height);
            if (Properties.Settings.Default.Animation == true)
            {
                QuickH.ShowSync(Library);
            }


                Library.Show();

            Library.Items.Clear();//Clear Items in the LuaScriptList
            refresh(Library, "./Scripts", "*.txt");
            refresh(Library, "./Scripts", "*.lua");
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            hideUI("minor");
            SelectionPad.SetBounds(SelectionPad.Location.X, Settings.Location.Y, SelectionPad.Width, SelectionPad.Height);

            KillRoblox.Show();
            CheckSpeed.Show();
            AttachButton.Show();
            gunaSeparator1.Show();
            KeepSpeedCheck.Show();
            CheckRemoveBar.Show();
        }

      

        private void AttachButton_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void KillRoblox_MouseHover(object sender, EventArgs e)
        {
            KillRoblox.OnHoverBaseColor = ColorChangeKillRoblox.Value;
            KillRoblox.Animated = true;
        }

        private void KillRoblox_Click(object sender, EventArgs e)
        {
            Process[] roblox = Process.GetProcesses();
            foreach(Process openedroblox in roblox)
            {
                bool flag = openedroblox.ProcessName == "RobloxPlayerBeta";
                    
                if(flag)
                {
                    openedroblox.Kill();
                }
            }
        }

       

        private void KeepSpeedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (KeepSpeedCheck.Checked == true)
            {
                Properties.Settings.Default.Keep = true;
            }
            else
            {
                Properties.Settings.Default.Keep = false;
            }
            Properties.Settings.Default.Save();
        }

        

        private void SwitchSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSpeed.Checked == true)
            {
                Properties.Settings.Default.Speed = true;
                timer1.Interval = 1000;
            }
            else
            {
                Properties.Settings.Default.Speed = false;
                timer1.Interval = 100;
            }
            Properties.Settings.Default.Save();
        }

        private void CheckRemoveBar_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSpeed.Checked == true)
            {
                Properties.Settings.Default.RemoveBar = true;
            }
            else
            {
                Properties.Settings.Default.RemoveBar = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Settings_Click_1(object sender, EventArgs e)
        {
            hideUI("minor");

            if(Properties.Settings.Default.Animation == true)
            {
                QuickH.ShowSync(KeepSpeedCheck);
                QuickH.ShowSync(CheckAnimation);
                QuickH.ShowSync(CheckRemoveBar);
                QuickH.ShowSync(CheckSpeed);
                QuickV.ShowSync(KillRoblox);
                QuickV.ShowSync(AttachButton);
                SpinTrans.ShowSync(gunaSeparator1);
            }



            KillRoblox.Show();
            AttachButton.Show();
            gunaSeparator1.Show();
            CheckSpeed.Show();
            KeepSpeedCheck.Show();
            CheckRemoveBar.Show();
            CheckAnimation.Show();
            
        }

        private void CheckAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAnimation.Checked == true)
            {
                Properties.Settings.Default.Animation = true;
            }
            else
            {
                Properties.Settings.Default.Animation = false;
            }
            Properties.Settings.Default.Save();
        }

        
        private void InjectButton_Click_1(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void AttachConditionSwitch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ScriptBox_Load(object sender, EventArgs e)
        {

        }


        //SpinTrans.HideSync(Settings);
        //sprite.Image = ((GunaCircleButton)sender).Image;
        //SpinTrans.ShowSync(Settings);

    }
}