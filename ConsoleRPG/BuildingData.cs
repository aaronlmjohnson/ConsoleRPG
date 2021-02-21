using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class BuildingData
    {
        //name
        public string Name { get; set; }

        // position
        public IDictionary<string, int> Position { get; set; }
        public string Path { get; set; }

    }
}
