using System;
using System.Windows.Forms;

namespace Gridden.View
{
    /// <summary>
    /// Form for allowing the modification of Map properties: name, width, height.
    /// </summary>
    public partial class MapInfoForm : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
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

        /// <summary>
        /// Event handler for clicking the "OK" button.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            SaveControlValuesToMap();
            this.Close();
        }

        /// <summary>
        /// Copy values from the UI controls to the Map instance.
        /// </summary>
        private void SetControlValuesFromMap()
        {
            this.nameTextBox.Text = Map.Name;
            this.widthSelector.Value = Map.MapWidth;
            this.heightSelector.Value = Map.MapHeight;
        }


        /// <summary>
        /// Copy values from the Map instance to the UI controls.
        /// </summary>
        private void SaveControlValuesToMap()
        {
            Map.Name = this.nameTextBox.Text;
            Map.MapWidth = (int)this.widthSelector.Value;
            Map.MapHeight = (int)this.heightSelector.Value;
        }
    }
}
