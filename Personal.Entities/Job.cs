using System.ComponentModel.DataAnnotations;
namespace Personal.Entities
{
    public class Job
    {
        [Required]
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        [Range(100,10000)]
        public int MinSalary { get; set; }
        [Range(500,int.MaxValue)]
        public int MaxSalary { get; set; }
    }
}
