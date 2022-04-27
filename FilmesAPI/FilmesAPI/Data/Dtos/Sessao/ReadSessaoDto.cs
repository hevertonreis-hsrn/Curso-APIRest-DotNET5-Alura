using FilmesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data
{
    public class ReadSessaoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
    }
}