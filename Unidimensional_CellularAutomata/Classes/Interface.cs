using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidimensional_CellularAutomata.Classes
{
    internal class Interface
    {
        // Constants
        public static readonly Vector2 WINDOW_DIMENSIONS = new Vector2(750, 750);


        // Fields
        private GraphicsDeviceManager _graphics;


        // Properties


        // Ctor
        public Interface(GraphicsDeviceManager graphics)
        {
            this._graphics = graphics;

            this._graphics.PreferredBackBufferHeight = (int)Interface.WINDOW_DIMENSIONS.Y;
            this._graphics.PreferredBackBufferWidth = (int)Interface.WINDOW_DIMENSIONS.X;
            this._graphics.ApplyChanges();
        }

        // Methods
    }
}
