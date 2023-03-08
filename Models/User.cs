using crud_csharp.Middleware;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models
{
    public class User
    { 

        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("created_at")]
        public DateTimeOffset Created_at { get; set; } = DateTimeOffset.Now;

        public void HashPassword()
        {
            Password = Password.Generate();
        }
    }
}
