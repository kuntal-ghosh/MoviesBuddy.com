using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Database;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        protected readonly VidlyDbContext _context;
        public MoviesController()
        {
            _context=new VidlyDbContext();
        }

        public IHttpActionResult GetMovies()
        {
            var movies =_context.Movies.ToList().Select(AutoMapper.Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return Ok(AutoMapper.Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult Addmovie(MovieDto movieDto)
        {
            var movie = AutoMapper.Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri+"/"+movieDto.Id),movieDto );
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            AutoMapper.Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var customerInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            _context.Movies.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
