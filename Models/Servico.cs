using System.ComponentModel.DataAnnotations;

namespace PoC.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}