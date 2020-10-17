
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola_API.Models {

  public class Curso {

    public int id { get; set; }
  
    [Required(ErrorMessage = "Campo obrigatório")]
    [Range(0, 99, ErrorMessage = "Este campo deve conter no máximo 2 caracteres.")]
    public int codCurso { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(30, ErrorMessage = "Este campo deve conter no máximo 30 caracteres.")]
    public string nomeCurso { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    [MaxLength(1, ErrorMessage = "Este campo deve conter no máximo 1 caracter.")]
    public string periodo { get; set; }

  }
}