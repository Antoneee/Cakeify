using System.ComponentModel.DataAnnotations;

namespace Cakeify.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1,100, ErrorMessage = "The Display Order field must be between 1 and 100.")]
        public int OrderId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
