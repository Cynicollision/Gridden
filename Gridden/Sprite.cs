using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridden
{
    public class Sprite
    {
        public const int Size = 32;

        public Sprite(char c, string fileName)
        {
            _char = c;
            _fileName = fileName;
        }

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
    }
}
