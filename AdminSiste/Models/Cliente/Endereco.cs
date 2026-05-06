using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AdminSiste.Models.Cliente
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; } // Comercial, Residencial, etc.

        [Required, MaxLength(10)]
        public string CEP { get; set; }

        [Required, MaxLength(150)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required, MaxLength(100)]
        public string Cidade { get; set; }

        [Required, MaxLength(2)]
        public string UF { get; set; }

        // Relacionamento
        public int ClienteId { get; set; }
        [ValidateNever]
        public Cliente Cliente { get; set; }
    }
}