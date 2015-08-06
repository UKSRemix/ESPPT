 /*   
    ESP Project Tool
    Copyright (C) 2015 Philip Redrup (Remix)

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Collections;


namespace ESPPT
{
    public partial class frmMain : Form
    {
        Serial serial = new Serial();
        IniFile config = new IniFile("config.ini");
        public frmMain()
        {
            InitializeComponent();
            //Add envents
            ESPTool.eventDebugText += new SerialMessage(DebugText);
            ESPTool.eventInitSerial += new InitSerial(ConnectSerial);
            Make.eventDebugText += new SerialMessage(DebugText);
            Make.eventMakeDone += new MakeDone(Upload);
            serial.eventSerialMessage += new SerialMessage(DebugText);
            //Setup Datagrideview
            dgPaths.ColumnCount = 2;
            dgPaths.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgPaths.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgPaths.ColumnHeadersDefaultCellStyle.Font = new Font(dgPaths.Font, FontStyle.Bold);
            dgPaths.Name = "dgPaths";
            dgPaths.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgPaths.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgPaths.GridColor = Color.Black;
            dgPaths.RowHeadersVisible = false;

            dgPaths.Columns[0].Name = "File";
            dgPaths.Columns[0].HeaderText = "File";
            dgPaths.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPaths.Columns[0].Width = 200;
            dgPaths.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dgPaths.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F, FontStyle.Bold);
            dgPaths.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dgPaths.Columns[1].Name = "Offset";
            dgPaths.Columns[1].HeaderText = "Offset";
            dgPaths.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPaths.Columns[1].Width = 94;
            dgPaths.Columns[1].DefaultCellStyle.BackColor = Color.Black;
            dgPaths.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12.5F, FontStyle.Bold);
            dgPaths.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dgPaths.MultiSelect = false;
            dgPaths.ScrollBars = 0;
            dgPaths.AllowUserToResizeColumns = false;
            dgPaths.AllowUserToResizeRows = false;
            dgPaths.AllowUserToAddRows = false;
            dgPaths.GridColor = Color.White;
            dgPaths.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dgPaths.Rows.Add(9);

           chDoAll.Checked = Convert.ToBoolean(config.getKey("[CONFIG]", "AutoBuild"));
        }

        public void ReadConfig(string path)
        {
            if (path == "") return;
            string[] lines = File.ReadAllLines(path);
            string projectPath = lines[0];
            dgPaths.Rows.Clear();
            for (int i = 1; i < 10; i++)
            {
                string[] row;
                if(i < lines.Count())
                    row = lines[i].Split(',');
                else
                    row = new string[] { "", "" };

                dgPaths.Rows.Add(row);
            }
            config.setKey("[CONFIG]", "LastProject", path);
            txtProjectPath.Text = projectPath;
        }

        public void WriteConfig(string filePath,string projectPath)
        {   
            string[] lines = new string[10];
            lines[0] = projectPath;
            for (int i = 0; i < dgPaths.Rows.Count; i++)
            {
                if(dgPaths.Rows[i].Cells[0].Value.ToString() != "")
                    lines[i + 1] = string.Format("{0},{1}",dgPaths.Rows[i].Cells[0].Value.ToString(),dgPaths.Rows[i].Cells[1].Value.ToString());
            }

            File.WriteAllLines(filePath,lines);
            config.setKey("[CONFIG]", "LastProject", filePath);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          
            cbCom.Items.AddRange(serial.GetPorts());
            cbCom.Text = cbCom.Items[cbCom.Items.Count - 1].ToString();

            ReadConfig(config.getKey("[CONFIG]", "LastProject"));
        }

        private void Upload()
        {
            if (this.InvokeRequired)
            {
                MakeDone d = new MakeDone(Upload);
                this.Invoke(d, new object[] { });
            }
            else
            {
                List<string> file = new List<string>();
                List<string> offset = new List<string>();
                txtDebug.Clear();
                foreach (DataGridViewRow dr in dgPaths.Rows)
                {
                    if (dr.Cells[0].Value.ToString() != "")
                    {
                        file.Add(dr.Cells[0].Value.ToString());
                        offset.Add(dr.Cells[1].Value.ToString());
                    }
                }
                ESPTool.flash(txtProjectPath.Text, cbCom.Text, file.ToArray<string>(), offset.ToArray<string>());
            }
        }
        private void ConnectSerial()
        {
            if (this.InvokeRequired)
            {
                InitSerial d = new InitSerial(ConnectSerial);
                this.Invoke(d, new object[] { });
            }
            else
            {
                serial.PortName = cbCom.Text;
                serial.BaudRate = Convert.ToInt32(cbBaudRate.Text);
                serial.DataBits = Convert.ToInt32(cbDatabits.Text);
                serial.Parity = cbParity.Text;
                serial.StopBits = cbStopBits.Text;
                serial.Handshake = cbFlowControl.Text;
                if (serial.Open()) btnConnect.Text = "Disconnect";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DialogResult result;
            switch (btn.Name)
            {
                case "btnConnect":
                    if (btnConnect.Text == "Connect")
                    {
                        txtDebug.Clear();
                        ConnectSerial();
                    }
                    else
                    {
                        serial.Close();
                        btnConnect.Text = "Connect";
                    }
                    break;
                case "btnBuild":
                    Make.Compile(txtProjectPath.Text, chDoAll.Checked);
                    break;
                case "btnUpload":
                    Upload();
                    break;
                case "btnSaveConfig":

                    saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"config";
                    saveFileDialog.FileName = "";
                    result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (!saveFileDialog.FileName.EndsWith(".txt"))
                            saveFileDialog.FileName += ".txt";
                        WriteConfig(saveFileDialog.FileName,txtProjectPath.Text);
                    }
                    break;
                case "btnSend":
                    serial.Send(txtSend.Text);
                    break;
                case "btnLoad":
                    oFD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"config";
                    oFD.FileName = "";
                    result = oFD.ShowDialog();
                    if (result == DialogResult.OK) ReadConfig(oFD.FileName);
                    break;
                default:
                    break;
            }
        }

        private void txtSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                serial.Send(txtSend.Text);
                txtSend.Text = "";
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            serial.Close();
        }

        private void DebugText(string message)
        {
            if (this.InvokeRequired)
            {
                SerialMessage d = new SerialMessage(DebugText);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                txtDebug.AppendText(message + "\n");
            }
        }

        private void chDoAll_CheckedChanged(object sender, EventArgs e)
        {
            config.setKey("[CONFIG]", "AutoBuild", chDoAll.Checked.ToString());
        }
    }

    public delegate void MakeDone();
    static class Make
    {
        public static event SerialMessage eventDebugText;
        public static event MakeDone eventMakeDone;
        static Process proc;
        public static void Compile(string dir,bool confirm = false)
        {
            proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.WorkingDirectory = dir;
            proc.OutputDataReceived += (sender, args) => DataReceived(args.Data);
            proc.StartInfo.CreateNoWindow = true;

            new Thread(() =>
            {
                proc.Start();
                proc.StandardInput.WriteLine(string.Format("Make"));
                proc.BeginOutputReadLine();
                proc.WaitForExit();
                if (confirm && eventMakeDone != null) eventMakeDone();

            }).Start();

            
        }

        private static void DataReceived(string data)
        {
            if (eventDebugText != null) eventDebugText(string.Format("{0}", data));
            if (data !=null && (data.Contains("Nothing to be done for 'all'.") || data.Contains("esptool -eo build/esp8266_at.out -es .irom0.text"))) proc.Kill();
        }
    }

    public delegate void InitSerial();
    static class ESPTool
    {
        public static event SerialMessage eventDebugText;
        public static event InitSerial eventInitSerial;

        public static void flash(string dir,string port,string[] bin ,string[] offset)
        {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.WorkingDirectory = string.Format(@"{0}\\firmware", dir);
            proc.OutputDataReceived += (sender, args) => DataReceived(args.Data);
            proc.StartInfo.CreateNoWindow = true;

            new Thread(() =>
            {
                string pram = string.Format(@"C:\Python27\python.exe {0}esptool.py --port {1} write_flash", AppDomain.CurrentDomain.BaseDirectory, port);
                for (int i = 0; i < offset.Count(); i++)
                {
                    pram += string.Format(@" {0} {1}", offset[i], bin[i]);
                }
                proc.Start();
                proc.StandardInput.WriteLine(pram);
                proc.BeginOutputReadLine();
            }).Start();
        }

        private static void DataReceived(string data)
        {
            if (eventDebugText != null) eventDebugText(string.Format("{0}", data));
            if(data.Contains("Leaving..."))
                if (eventInitSerial != null) eventInitSerial();
        }
    }

    static class Misc
    {
        //getLibs
        static public void getLibs()
        {
            string[] array1 = Directory.GetFiles(@"C:\ESP8266\SDK\esp_iot_sdk_v1.2.0\lib");
            string[] array2 = new string[array1.Count()];
            for (int i = 0; i < array2.Count(); i++)
            {
                array2[i] = Path.GetFileName(array1[i]).Substring(3).Replace(".a","");
            }
            File.WriteAllLines(@"C:\ESP8266\SDK\esp_iot_sdk_v1.2.0\lib\libs.txt", array2);
        }
    }
}
