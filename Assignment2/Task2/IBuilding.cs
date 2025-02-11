namespace Task2
{
    /// <summary>
    /// Class <c>IBuilding</c> is an interface that holds the structure of a building need to be wired
    /// </summary>
    internal interface IBuilding
    {
        int BuildingSize { get; set; }
        int LightBulbNumber { get; set; }
        int OutletNumber { get; set; }
        string CreditCardNumber { get; set; }

        List<string> GetCommonTaskList()
        List<string> GetCustomizedTaskList();
        List<string> GetAllOperations();
    }
}
