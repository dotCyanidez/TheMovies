using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.ViewModel
{
    public partial class MovieViewModel : ObservableObject
    {
        private Movie _movie = new();
        private MovieRepository _movieRepository = new();
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private int _duration;
        [ObservableProperty]
        private string _genre;

        public Exception Add()
        {
            _movie.Title = Title;
            _movie.Duration = Duration;
            _movie.Genre = Genre;

            Exception? e = _movieRepository.Add(_movie);
            return e;

        }
    }
}
