using ExtensionMethods;
using RtkIRLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private static readonly Color ColorDisabled = Color.Silver;
        private static readonly Color ColorEnabled = Color.FromArgb(0, 127, 0);

        private IRMonitor irMonitor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            irMonitor = new IRMonitor(0x00FFFFF);
            irMonitor.IRDeviceRemoved += irMonitor_IRDeviceRemoved;
            irMonitor.IRDeviceArrived += irMonitor_IRDeviceArrived;
            irMonitor.IRCodeReceived += irMonitor_IRCodeReceived;

            irMonitor.StartMonitoring();
        }

        void irMonitor_IRCodeReceived(object sender, IRCodeReceivedEventArgs e)
        {
            switch (e.Device)
            {
                case DeviceType.RTKIR:
                    lblCodeRTK.InvokeIfRequired(c => c.Text = e.IRCode.ToString("X4"));
                    break;
                case DeviceType.AF9100IR:
                    lblCodeAF.InvokeIfRequired(c => c.Text = e.IRCode.ToString("X4"));
                    break;
            }

            dataGridView1.InvokeIfRequired(c =>
            {
                string[] row = new string[] { DateTime.Now.ToString(), e.Device.ToString(), e.IRCode.ToString("X4") };
                int rownumber = c.Rows.Add(row);
                c.CurrentCell = c.Rows[rownumber].Cells[0];
            });
        }

        void irMonitor_IRDeviceArrived(object sender, IRDeviceChangeEventArgs e)
        {
            switch (e.Device)
            {
                case DeviceType.RTKIR:
                    statusRTK.InvokeIfRequired(c => c.BackColor = ColorEnabled);
                    lblDevIdRTK.InvokeIfRequired(c => c.Text = e.DeviceID.ToString());
                    break;
                case DeviceType.AF9100IR:
                    statusAF.InvokeIfRequired(c => c.BackColor = ColorEnabled);
                    lblDevIdAF.InvokeIfRequired(c => c.Text = e.DeviceID.ToString());
                    break;
            }
        }

        void irMonitor_IRDeviceRemoved(object sender, IRDeviceChangeEventArgs e)
        {
            switch (e.Device)
            {
                case DeviceType.RTKIR:
                    statusRTK.InvokeIfRequired(c => c.BackColor = ColorDisabled);
                    lblDevIdRTK.InvokeIfRequired(c => c.Text = "n.a.");
                    break;
                case DeviceType.AF9100IR:
                    statusAF.InvokeIfRequired(c => c.BackColor = ColorDisabled);
                    lblDevIdAF.InvokeIfRequired(c => c.Text = "n.a.");
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            irMonitor.StopMonitoring();
        }
    }
}
