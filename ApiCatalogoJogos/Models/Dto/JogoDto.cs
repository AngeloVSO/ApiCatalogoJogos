using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.Models.Dto
{
    public class JogoDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser de no mínimo $1 e no máximo $1000")]
        public double Preco { get; set; }
    }
}
