using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Gridden
{
    /// <summary>
    /// Factory class that provides various ways of generating new Sheet objects.
    /// </summary>
    public static class SheetFactory
    {
        /// <summary>
        /// Returns and returns an "empty" Sheet object.
        /// </summary>
        public static Sheet GetBlank()
        {
            return new Sheet();
        }

        /// <summary>
        /// Returns a new Sheet object instantiated from the .xml storage file.
        /// </summary>
        public static Sheet LoadSheetFromFile()
        {
            Sheet loadedSheet = SheetFactory.GetBlank();

            try
            {
                string fileName = Path.Combine(Environment.CurrentDirectory, SheetEditor.SheetFileName);
                if (File.Exists(fileName))
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open);
                    XmlReader reader = XmlReader.Create(fs);
                    XmlSerializer xml = new XmlSerializer(typeof(Sheet));
                    loadedSheet = (Sheet)xml.Deserialize(reader);
                    reader.Close();
                    fs.Close();
                }

                return loadedSheet;
            }
            catch (Exception e)
            {
                throw new Exception("Failed loading sheets from .xml!", e);
            }
        }
    }
}
