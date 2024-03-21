using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniversáriosAgenda.Classe
{
    public class Aniversariante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo 60 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatório.")]
        public DateTime DataNacimento { get; set; }
        public string Descricao { get; set; }
    }
}
