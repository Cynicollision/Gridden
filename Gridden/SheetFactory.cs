using System.Collections.Generic;

namespace Gridden
{
    public static class SheetFactory
    {
        public static Sheet GetBlank()
        {
            return new Sheet(new List<Sprite>());
        }

        public static Sheet BuildFromSpriteList(List<Sprite> sprites)
        {
            return new Sheet(sprites);
        }
    }
}
