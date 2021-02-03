using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStorage.Models
{
    public static class TempStorage
    {
        private static List<MovieInfo> movieInfo = new List<MovieInfo>();

        public static IEnumerable<MovieInfo> MovieInf => movieInfo;

        public static void AddMovie(MovieInfo movie)
        {
            movieInfo.Add(movie);
        }
    }
}
