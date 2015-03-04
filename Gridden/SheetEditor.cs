using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Gridden
{
    /// <summary>
    /// Singleton utility class for manipulating a collection of Sheet instances.
    /// </summary>
    public class SheetEditor
    {
        public const string SheetFileName = "sheets.xml";
        public const string SheetFileDirectory = "sheets";

        // Singleton instance.
        private static SheetEditor _instance;
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

        private SheetEditor()
        {
        }

        #region Public properties

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
        public List<Sprite> GetSpritesFromCurrentSheet()
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

        /// <summary>
        /// Creates a new sprite from the given file and assigns it the given character for the map.
        /// This will throw an exception if there is already a Sprite in the collection assigned to the given character.
        /// </summary>
        public int AddSpriteToCurrentSheet(char c, string fileName)
        {
            // TODO: 
            // 1) throw error if Sprite's char c is already in sheet
            // 2) copy image to sheets/<sheetName>/<index>.<ext>
            // 3) add to list with new index

            SaveSheetsToFile();
            return 0; // TODO: return the new Sprite's index?
        }

        /// <summary>
        /// Removes the given Sprite from the current sheet.
        /// </summary>
        public void RemoveSpriteFromCurrentSheet(Sprite s)
        {
            string fileName = s.FileName;
            // TODO: use fileName to delete the actual file sheets/<sheetName>/<index>
            CurrentSheet.RemoveSprite(s);
            SaveSheetsToFile();
        }

        /// <summary>
        /// Saves all sheets managed by the application to the .xml file.
        /// </summary>
        public static void SaveSheetsToFile()
        {
            try
            {
                // create the directory if it does not exist.
                string dir = Path.Combine(Environment.CurrentDirectory, SheetFileDirectory);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                XmlSerializer xml = new XmlSerializer(typeof(List<Sheet>));
                TextWriter fs = new StreamWriter(Path.Combine(dir, SheetFileName));
                xml.Serialize(fs, SheetEditor.Instance.Sheets);
                fs.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Failed saving sheets to .xml!", e);
            }
        }
    }
}
