using System.ComponentModel.DataAnnotations;

namespace AdminSiste.Models.Cliente
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Telefone { get; set; }

        [MaxLength(50)]
        public string Celular { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(100)]
        public string Site { get; set; }

        [Required]
        public string TipoPessoa { get; set; } // PF, PJ, ES

        [Required]
        public int Situacao { get; set; } // 1 = Ativo, 0 = Inativo

        public string Vendedor { get; set; } // Autocomplete

        // Relacionamentos
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
    }
}