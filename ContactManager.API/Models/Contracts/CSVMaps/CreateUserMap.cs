using ContactManager.API.Models.Contracts.Request;
using CsvHelper.Configuration;

namespace ContactManager.API.Models.Contracts.CSVMaps
{
    public class CreateUserMap : ClassMap<CreateUserRequest>
    {
        public CreateUserMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.DateOfBirth).Name("Date of birth");
            Map(m => m.Married).Name("Married");
            Map(m => m.Salary).Name("Salary");
            Map(m => m.Phone).Name("Phone");
        }
    }
}
