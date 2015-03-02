using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gridden.View
{
    public partial class MapInfoForm : Form
    {
        public MapInfoForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = String.Format("Map Properties: {0}", MapEditor.Instance.CurrentMap.Name);
        }

        private Map _map;
        public Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                _map = value;
                SetControlValuesFromMap();
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            SaveControlValuesToMap();
            this.Close();
        }

        private void SetControlValuesFromMap()
        {
            this.nameTextBox.Text = Map.Name;
            this.widthSelector.Value = Map.MapWidth;
            this.heightSelector.Value = Map.MapHeight;
        }

        private void SaveControlValuesToMap()
        {
            Map.Name = this.nameTextBox.Text;
            Map.MapWidth = (int)this.widthSelector.Value;
            Map.MapHeight = (int)this.heightSelector.Value;
        }
    }
}
