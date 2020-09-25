using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola_API.Models
{
    public class Aluno
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(5, ErrorMessage = "Este campo deve conter no máximo 5 caracteres")]
        public string ra { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter no máximo 30 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
     //   [Range(2, 0,  ErrorMessage = "Este campo deve conter no máximo 2 caracteres.")]
        public int codCurso { get; set; }
    }
}