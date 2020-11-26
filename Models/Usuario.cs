using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PoC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings=false, ErrorMessage="Campo obrigatório." )]
        public string Nome { get; set; }
    }
}