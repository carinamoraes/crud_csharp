using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp.Models.DTOs
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
