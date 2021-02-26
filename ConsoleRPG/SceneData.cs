using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class SceneData
    {
        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
        public IDictionary<string, int> PlayerStart { get; set; }
        public BuildingData[] Buildings { get; set; }

        public string Background { get; set; }

        //TODO: add connected scenes such as left: hub, right: forest_2 , up: forest_4, down: mountain_1
    }
}
