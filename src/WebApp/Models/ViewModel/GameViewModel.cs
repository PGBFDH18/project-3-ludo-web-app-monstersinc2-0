using System.Collections.Generic;
using WebApp.Models.ApplicationModel;

namespace WebApp.Models
{
    public class GameViewModel
    {

        /// <summary>
        /// Constructor to set the patterns 
        /// </summary>
        public GameViewModel()
        {
            Patterns = new Dictionary<string, int[]>
            {
                ["0"] = new int[] { 0, 55, 56, 57, 58, 59, 60, 18, 17, 16,
                                15, 14, 13, 7, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 37,
                                38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 19, 20, 21, 22,
                                23, 24, 72, 71, 70, 69, 68, 67, 61, 62, 63, 64, 65, 66, 73},
                ["1"] = new int[] { 0, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 37,
                                38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 19, 20, 21, 22,
                                23, 24, 72, 71, 70, 69, 68, 67, 61, 55, 56, 57, 58, 59, 60, 18, 17, 16,
                                15, 14, 13, 7, 8, 9, 10, 11, 12, 73},
                ["2"] = new int[] { 0, 37,
                                38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 19, 20, 21, 22,
                                23, 24, 72, 71, 70, 69, 68, 67, 61, 55, 56, 57, 58, 59, 60, 18, 17, 16,
                                15, 14, 13, 7, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 44, 45, 46, 47, 48, 73},
                ["3"] = new int[] { 0, 19, 20, 21, 22,
                                23, 24, 72, 71, 70, 69, 68, 67, 61, 55, 56, 57, 58, 59, 60, 18, 17, 16,
                                15, 14, 13, 7, 1, 2, 3, 4, 5, 6, 54, 53, 52, 51, 50, 49, 43, 37,
                                38, 39, 40, 41, 42, 36, 35, 34, 33, 32, 31, 25, 26, 27, 28, 29, 30, 73}
            };
        }

        public Dictionary<string, int[]> Patterns { get; set; }
        public int GameID { get; set; }
        public int CurrentPlayerID { get; set; }
        public int CurrentDieRoll { get; set; }
        public List<Player> Players { get; set; }
        public bool TimeToMove { get; set; } = false;
    }
}
