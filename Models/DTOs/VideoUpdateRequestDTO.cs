using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models.DTOs
{
    public class VideoUpdateRequestDTO
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("duration")]
        public float? Duration { get; set; }

        [Column("category_id")]
        public string? Category_id { get; set; }
    }
}
