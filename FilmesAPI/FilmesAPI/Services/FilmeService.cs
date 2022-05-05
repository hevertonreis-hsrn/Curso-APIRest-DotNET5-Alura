using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            //filme.Id = id++;
            //filmes.Add(filme);

            //Filme filme = new Filme
            //{
            //   Titulo = filmeDto.Titulo,
            //    Diretor = filmeDto.Diretor,
            //    Genero = filmeDto.Genero,
            //    Duracao = filmeDto.Duracao
            //};

            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }
        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            //return Ok(filmes);

            //return _context.Filmes;
            //
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes
                .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
                .ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);

                return readDto;
            }

            return null;
            
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }

            //filme.Titulo = filmeDto.Titulo;
            //filme.Diretor = filmeDto.Diretor;
            //filme.Genero = filmeDto.Genero;
            //filme.Duracao = filmeDto.Duracao;

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();

        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                //ReadFilmeDto filmeDto = new ReadFilmeDto
                //{
                //    Titulo = filme.Titulo,
                //    Diretor = filme.Diretor,
                //    Genero = filme.Genero,
                //    Duracao = filme.Duracao,
                //    Id = filme.Id,
                //    HoraDaConsulta = DateTime.Now
                //};
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }

            return null;
        }
    }
}
