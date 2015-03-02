using System.Windows.Forms;

namespace Gridden
{
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
