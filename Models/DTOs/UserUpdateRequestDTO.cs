using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models.DTOs
{
    public class UserUpdateRequestDTO
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("email")]
        public string? Email { get; set; }
    }
}
