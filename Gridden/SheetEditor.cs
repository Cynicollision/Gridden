using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Gridden
{
    /// <summary>
    /// Singleton utility class for manipulating a collection of Sheet instances.
    /// </summary>
    public class SheetEditor
    {
        private static SheetEditor _instance;
        private SheetEditor()
        {
        }

        #region Public properties

        // Singleton instance.
        public static SheetEditor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SheetEditor();
                }
                return _instance;
            }
        }

        private List<Sheet> _sheets;
        public List<Sheet> Sheets
        {
            get
            {
                if (_sheets == null)
                {
                    _sheets = new List<Sheet>();
                }
                return _sheets;
            }
            set
            {
                _sheets = value;
            }
        }

        private Sheet _currentSheet;
        public Sheet CurrentSheet
        {
            get
            {
                return _currentSheet;
            }
            set
            {
                _currentSheet = value;
            }
        }

        #endregion

        /// <summary>
        /// Returns the collection of Sprite instances that are part of the current Sheet.
        /// </summary>
        /// <returns></returns>
        public List<Sprite> GetSprites()
        {
            return _currentSheet.Sprites;
        }

        /// <summary>
        /// Returns the Image object in the current sheet that corresponds to the given character c.
        /// </summary>
        public Image GetImageForCharacter(char c)
        {
            return CurrentSheet.Sprites.Where(r => r.Char == c).First().Image;
        }
    }
}
