using CopyData.EntityModels;

namespace CopyData.Models
{
    public class DataModel
    {
        public List<Employee> GetEmployees { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
