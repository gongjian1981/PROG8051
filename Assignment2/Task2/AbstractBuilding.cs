using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal abstract class AbstractBuilding : IBuilding, IComparable
    {
        private string type;
        private int buildingSize;
        private int lightBulbNumber;
        private int outletNumber;
        private string creditCardNumber;
        private readonly List<string> commonTaskList = ["Create wiring schemas", "Purchase necessary parts"];
        public string Type { get; set; }
        public int BuildingSize { get; set; }
        public int LightBulbNumber { get; set; }
        public int OutletNumber { get; set; }
        public string CreditCardNumber { get; set; }

        public List<string> GetCommonTaskList()
        {
            return this.commonTaskList;
        }

        public abstract List<string> GetCustomizedTaskList();

        public virtual List<string> GetAllOperations()
        {
            List<string> operations = new List<string>();
            if (GetCommonTaskList() != null)
            {
                operations.AddRange(GetCommonTaskList());
            }
            if (GetCustomizedTaskList() != null)
            {
                operations.AddRange(GetCustomizedTaskList());
            }
            return operations;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return -1;
            }
            IBuilding b = (IBuilding)obj;
            return this.BuildingSize.CompareTo(b.BuildingSize);
        }
    }
}
