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
            Sheet s = new Sheet();
            s.Sprites = new List<Sprite>();
            return s;
        }

        /// <summary>
        /// Builds and returns a collection of Sheet objects from the persistent storage (.xml file).
        /// </summary>
        public static List<Sheet> BuildSheetsFromFile()
        {
            try
            {
                string fileName = Path.Combine(Environment.CurrentDirectory, SheetEditor.SheetFileDirectory, SheetEditor.SheetFileName);

                FileStream fs = new FileStream(fileName, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                XmlSerializer xml = new XmlSerializer(typeof(List<Sheet>));
                return (List<Sheet>)xml.Deserialize(reader);
            }
            catch (Exception e)
            {
                throw new Exception("Failed loading sheets from .xml!", e);
            }
        }
    }
}
