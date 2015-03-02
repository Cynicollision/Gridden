using System.Collections.Generic;

namespace Gridden
{
    public class Sheet
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Sheet(List<Sprite> sprites)
        {
            _sprites = sprites;
            _currentIdx = 0;
            foreach (Sprite s in sprites)
            {
                s.Index = NextIndex;
            }
        }

        private int _currentIdx;
        private int NextIndex
        {
            get
            {
                return _currentIdx++;
            }
        }

        private List<Sprite> _sprites;
        public List<Sprite> Sprites
        {
            get
            {
                if (_sprites == null)
                {
                    _sprites = new List<Sprite>();
                }
                return _sprites;
            }
        }

        public void AddSprite(Sprite s)
        {
            s.Index = NextIndex;
            _sprites.Add(s);
        }
    }
}
