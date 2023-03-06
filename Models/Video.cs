using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models
{
    public class Video
    {
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("duration")]
        public float Duration { get; set; }

        [Column("category_id")]
        public string Category_id { get; set; }

        [ForeignKey("Category_id")]
        public virtual Category? Category { get; set; }

        [Column("created_at")]
        public DateTimeOffset Created_at { get; set; } = DateTimeOffset.Now;


    }
}
