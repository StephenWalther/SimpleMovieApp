using SimpleMovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SimpleMovieApp.API
{
    public class MoviesController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            // check for CanViewMovies claim
            var claimsUser = this.User as ClaimsPrincipal;
            if (!claimsUser.HasClaim("CanViewMovies", "true"))
            {
                return Unauthorized();
            }

            var movies =new List<Movie>()
            {
                new Movie {Id=1, Title="Star Wars", Director="Lucas" },
                new Movie {Id=2, Title="The Martian", Director="Scott" },
                new Movie {Id=3, Title="Ex Machina", Director="Garland" }
            };

            return Ok(movies);
        }
    }
}
