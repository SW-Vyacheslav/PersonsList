using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonsList.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Middlename { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }

        [Column]
        public int? Age { get; set; }
    }
}
