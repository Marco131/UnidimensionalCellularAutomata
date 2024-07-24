using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidimensional_CellularAutomata.Classes
{
    internal class CellularAutomataManager
    {
        // Constants
        private const int _SEQUENCE_SIZE = 3;

        private static List<bool[]> _SEQUENCE_LIST = new List<bool[]> {     // List in a specific rder
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {true, true, true},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {true, true, false},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {true, false, true},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {true, false, false},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {false, true, true},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {false, true, false},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {false, false, true},
            new bool[CellularAutomataManager._SEQUENCE_SIZE] {false, false, false}
        };

        private static bool[] _STATE_LIST = { false, false, true, true, false, true, true, false };     // List in a specific rder

        private const float _STEP_TIME_INTERVAL = 250; // miliseconds


        // Fields
        private float _stepTimer;
        private Grid _grid;


        // Properties


        // Ctor
        public CellularAutomataManager(Grid grid)
        {
            this._grid = grid;
        }


        // Methods
        public void Update(GameTime gameTime)
        {
            this._stepTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this._stepTimer >= CellularAutomataManager._STEP_TIME_INTERVAL)
            {
                // Get last row, and add default values to off screen pixels
                List<bool> lastRow = this._grid.GetLastRow().ToList();
                lastRow.Insert(0, false);
                lastRow.Add(false);

                // Generate new row
                List<bool> newRow = new List<bool>();
                for (int i = 1; i < Grid.COLUMN_NB + 1; i++)
                {
                    bool test = new bool[3] { false, false, false} == new bool[3] { false, false, false};

                    bool[] sequence = { lastRow[i - 1], lastRow[i], lastRow[i + 1] };
                    int sequenceID = CellularAutomataManager._SEQUENCE_LIST.FindIndex(value => value[0] == sequence[0] && value[1] == sequence[1] && value[2] == sequence[2]);
                    newRow.Add(CellularAutomataManager._STATE_LIST[sequenceID]);
                }

                this._grid.AddNewRow(newRow.ToArray());

                this._stepTimer = this._stepTimer - CellularAutomataManager._STEP_TIME_INTERVAL;
            }
        }
    }
}
