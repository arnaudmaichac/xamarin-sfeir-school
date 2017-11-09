using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieApp.Core.Services
{
    public class MovieService
    {
        public async Task<List<Movie>> GetMoviesByName(string search = "batman")
        {
            string url = string.Format(Constants.ApiUrl, "search/movie", $"?api_key={Constants.ApiKey}&query={search}&language=fr-FR&page=1&include_adult=false");

            // return jsonResult["results"].ToObject<List<Movie>>();
            return null;
        }
    }
}
