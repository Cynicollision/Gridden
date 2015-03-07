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
        public const string SheetFolderName = "images";

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

        private int _selectedSpriteIndex;
        public int SelectedSpriteIndex
        {
            get
            {
                return _selectedSpriteIndex;
            }
            set
            {
                _selectedSpriteIndex = value;
            }
        }

        #endregion

        /// <summary>
        /// Returns the collection of Sprite instances that are part of the current Sheet.
        /// </summary>
        /// <returns></returns>
        public List<Sprite> GetSpritesFromSheet()
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
        /// Returns the sprite with the given index.
        /// </summary>
        public Sprite GetSpriteByIndex(int index)
        {
            return CurrentSheet.Sprites.Where(r => r.Index == index).First();
        }

        /// <summary>
        /// Creates a new sprite from the given file and assigns it the given character for the map.
        /// This will throw an exception if there is already a Sprite in the collection assigned to the given character.
        /// </summary>
        public void AddSpriteToSheet(char c, string sourceFileName)
        {
            // create the sheet folder if it doesn't exist yet.
            string sheetDir = Path.Combine(Environment.CurrentDirectory, SheetEditor.SheetFolderName);
            if (!Directory.Exists(sheetDir))
            {
                Directory.CreateDirectory(sheetDir);
            }

            // build the new file name and copy the file to the local folder.
            int newIndex = CurrentSheet.Sprites.Count;
            string newFileName = Path.Combine(sheetDir, newIndex + Path.GetExtension(sourceFileName));
            File.Copy(sourceFileName, newFileName);

            // add the Sprite to the Sheet, then save it.
            CurrentSheet.AddNewSprite(c, newFileName);
            SaveSheetToFile();
        }

        /// <summary>
        /// Removes the given Sprite from the current sheet.
        /// </summary>
        public void RemoveSpriteFromCurrentSheet(int index)
        {
            // remove from sheet and save.
            CurrentSheet.RemoveSprite(index);
            SaveSheetToFile();

            SelectedSpriteIndex = 0;
        }

        /// <summary>
        /// Saves all sheets managed by the application to the .xml file.
        /// </summary>
        public static void SaveSheetToFile()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Sheet));
                TextWriter fs = new StreamWriter(Path.Combine(Environment.CurrentDirectory, SheetFileName));
                xml.Serialize(fs, SheetEditor.Instance.CurrentSheet);
                fs.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Failed saving sheets to .xml! See inner exception.", e);
            }
        }
    }
}
