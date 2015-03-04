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
        /// Builds and returns a collection of Sheet objects from the persistent storage (.xml file).
        /// If the .xml file does not exist an empty collection is returned.
        /// </summary>
        public static List<Sheet> BuildSheetsFromFile()
        {
            List<Sheet> loadedSheets = new List<Sheet>();

            try
            {
                string fileName = Path.Combine(Environment.CurrentDirectory, SheetEditor.SheetFileDirectory, SheetEditor.SheetFileName);
                if (File.Exists(fileName))
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open);
                    XmlReader reader = XmlReader.Create(fs);

                    XmlSerializer xml = new XmlSerializer(typeof(List<Sheet>));
                    loadedSheets = (List<Sheet>)xml.Deserialize(reader);
                }

                return loadedSheets;
            }
            catch (Exception e)
            {
                throw new Exception("Failed loading sheets from .xml!", e);
            }
        }
    }
}
