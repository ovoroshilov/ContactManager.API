using Microsoft.EntityFrameworkCore;

namespace ContactManager.API.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        [Precision(15, 2)]
        public decimal Salary { get; set; }
    }
}
