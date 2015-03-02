using System.Windows.Forms;

namespace Gridden
{
    /// <summary>
    /// Wrapper for Panel class that prevents annoying flickering when redrawing.
    /// </summary>
    public class DrawingPanel : Panel
    {
        public DrawingPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
}
