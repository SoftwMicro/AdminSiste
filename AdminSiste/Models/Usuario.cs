using System.ComponentModel.DataAnnotations;

namespace AdminSiste.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
