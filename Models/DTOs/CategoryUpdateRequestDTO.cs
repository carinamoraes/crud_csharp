using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models.DTOs
{
    public class CategoryUpdateRequestDTO
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
