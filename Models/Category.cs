using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models
{
    public class Category
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime Created_at { get; set; }
    }
}
