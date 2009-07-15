using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFML.Window;

namespace Game
{
    public partial class Launcher : Form
    {
        class SmartVideoMode
        {
            public VideoMode mode;
            public override string ToString()
            {
                return string.Format("{0}x{1} ({2})", mode.Width, mode.Height, mode.BitsPerPixel);
            }
        }
        static IEnumerable<SmartVideoMode> VideoModes
        {
            get
            {
                for (uint i = 0; i < VideoMode.ModesCount; ++i)
                {
                    yield return new SmartVideoMode { mode = VideoMode.GetMode(i) };
                }
            }
        }

        public Launcher()
        {
            InitializeComponent();

            foreach (var v in VideoModes)
            {
                dVideoModes.Items.Add(v);
            }

            dVideoModes.SelectedIndex = 0;
        }

        public bool Fullscreen
        {
            get
            {
                return dFullscreen.Checked;
            }
        }

        public VideoMode Mode
        {
            get
            {
                return ((SmartVideoMode)dVideoModes.SelectedItem).mode;
            }
        }

        private void dOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void dCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
