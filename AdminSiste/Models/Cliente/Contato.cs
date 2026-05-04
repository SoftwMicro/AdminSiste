using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminSiste.Models.Cliente
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string TelefoneComercial { get; set; }

        [MaxLength(50)]
        public string TelefoneCelular { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [EmailAddress, MaxLength(60)]
        public string Email { get; set; }

        // Relacionamento
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}