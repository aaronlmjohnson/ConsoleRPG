using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    class SceneData
    {
        public IDictionary<string, int> PlayerStart { get; set; }
        public IDictionary<string, IDictionary<string, IDictionary<string, int>>> Buildings { get; set; }


    }
}
