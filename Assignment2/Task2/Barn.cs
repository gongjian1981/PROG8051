using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Barn : AbstractBuilding
    {
        private readonly List<string> customizedTaskList = ["wire milking equipment"];
        public override List<string> GetCustomizedTaskList()
        {
            return customizedTaskList;
        }
    }
}
