using System.ComponentModel.DataAnnotations;

namespace AVTOTTEST_LAST.Models
{
    public class User
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
