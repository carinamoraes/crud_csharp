using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models
{
    public class User
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("created_at")]
        public DateTime Created_at { get; set; }
    }
}
