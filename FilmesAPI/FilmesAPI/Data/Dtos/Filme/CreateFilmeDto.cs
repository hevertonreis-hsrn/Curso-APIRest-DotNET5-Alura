﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo 'Título' é obrigatório ")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo 'Diretor' é obrigatório ")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O 'Gênero' não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A 'Duração' é no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
