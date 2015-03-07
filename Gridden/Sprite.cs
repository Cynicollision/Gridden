using System;
using System.Drawing;
using System.IO;

namespace Gridden
{
    /// <summary>
    /// Represents character -> image file name pair. 
    /// </summary>
    public class Sprite
    {
        public const int Size = 32;
        public Sprite()
        {
        }

        public Sprite(char c, string fileName)
        {
            _char = c;
            _fileName = fileName;
        }

        #region Public properties

        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        private char _char;
        public char Char
        {
            get
            {
                return _char;
            }
            set
            {
                _char = value;
            }
        }

        private string _fileName;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        private Image _image;
        public Image Image
        {
            get
            {
                if (_image == null)
                {
                    _image = Image.FromFile(FileName);
                }

                return _image;
            }
        }

        /// <summary>
        /// Renames the file that is associated with this Sprite to match its index.
        /// </summary>
        public void UpdateFileName()
        {
            try
            {
                string newFileName = Path.Combine(Environment.CurrentDirectory, SheetEditor.SheetFolderName, Index + Path.GetExtension(FileName));
                if (File.Exists(FileName) && newFileName != FileName)
                {
                    _image.Dispose();
                    File.Move(FileName, newFileName);
                    _image = Image.FromFile(newFileName);
                    FileName = newFileName;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed renaming sprite file! See inner exception.", e);
            }
        }

        #endregion

    }
}
