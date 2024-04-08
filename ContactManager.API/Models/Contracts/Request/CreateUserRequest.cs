using CsvHelper.Configuration.Attributes;

namespace ContactManager.API.Models.Contracts.Request
{
    public class CreateUserRequest
    {
        [Name("Name")]
        public string Name { get; set; }
        [Name("Date of birth")]
        public DateOnly DateOfBirth { get; set; }
        [Name("Married")]
        public bool Married { get; set; }
        [Name("Phone")]
        public string Phone { get; set; }
        [Name("Salary")]
        public decimal Salary { get; set; }
    }
}
