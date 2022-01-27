using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Models
{
    public class Jogo
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Produtora { get; set; }
        [Required]
        public double Preco { get; set; }
    }
}
