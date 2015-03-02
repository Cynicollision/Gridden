using System.Windows.Forms;

namespace Gridden
{
    /// <summary>
    /// Form for viewing the text version of the map.
    /// </summary>
    public partial class MapTextViewer : Form
    {
        public MapTextViewer()
        {
            InitializeComponent();
        }

        public void SetMapText(string text)
        {
            mapText.Text = text;
        }
    }
}
