using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class House : AbstractBuilding
    {
        private readonly List<string> customizedTaskList = ["install fire alarms"];
        public override List<string> GetCustomizedTaskList()
        {
            return customizedTaskList;
        }
    }
}
