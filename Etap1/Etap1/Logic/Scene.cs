using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etap1.Logic
{
    public class Scene
    {
        private readonly int width;
        private readonly int height;


        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Scene(int Width, int Height)
        {
            width = Width;
            height = Height;
        }
    }
}
