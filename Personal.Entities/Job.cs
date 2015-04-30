using System.ComponentModel.DataAnnotations;
namespace Personal.Entities
{
    public class Job
    {
        [Required]
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
    }
}
