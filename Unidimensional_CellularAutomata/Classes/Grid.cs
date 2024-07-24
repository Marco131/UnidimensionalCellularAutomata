using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidimensional_CellularAutomata.Classes
{
    internal class Grid
    {
        // Constants
        public const int COLUMN_NB = 51;
        public const int ROW_NB = 51; 


        // Fields  
        private List<bool[]> _pixelList;
        private Texture2D _pixelTexture;
        private Vector2 _pixelDimensions;

        private bool _isContentLoaded;


        // Properties


        // Ctor
        public Grid(Vector2 screenDimensions)
        {
            this._pixelList = new List<bool[]>();
            this._pixelDimensions = screenDimensions / new Vector2(Grid.COLUMN_NB, Grid.ROW_NB);
            this._isContentLoaded = false;

            // Fill Pixel List
            this._pixelList = Enumerable.Repeat(new bool[Grid.COLUMN_NB], Grid.ROW_NB).ToList();
            this._pixelList[Grid.ROW_NB - 1][(int)(Grid.COLUMN_NB / 2) + 1] = true;
        }


        // Methods
        public void LoadContent(Texture2D pixelTexture)
        {
            this._pixelTexture = pixelTexture;
            this._isContentLoaded = true;
        }

        public void AddNewRow(bool[] row)
        {
            if (row.Length != Grid.COLUMN_NB)
            {
                throw new ArgumentException($"The row list must have {Grid.COLUMN_NB} values");
            }

            this._pixelList.RemoveAt(0);
            this._pixelList.Add(row);
        }

        public bool[] GetLastRow()
        {
            return this._pixelList.Last();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this._isContentLoaded)
            {
                for (int y= 0; y < Grid.ROW_NB; y++)
                {
                    for (int x = 0; x < Grid.COLUMN_NB; x++)
                    {
                        // Set pixel color
                        Color pixelColor = Color.White;
                        if (this._pixelList[y][x])
                        {
                            pixelColor = Color.Black;
                        }

                        // Compute position
                        Vector2 position = new Vector2(
                            this._pixelDimensions.X * x,
                            this._pixelDimensions.Y * y
                            );

                        // origin not center
                        spriteBatch.Draw(this._pixelTexture, position, null, pixelColor, 0, this._pixelTexture.Bounds.Center.ToVector2(), this._pixelDimensions, 0, 0);
                    }
                }
            }
        }
    }
}
