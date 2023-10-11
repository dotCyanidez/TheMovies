using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.ViewModel
{
    public partial class ShowViewModel : ObservableObject
    {
        private Show _show;
        private ShowRepository _showRepository = new();

        [ObservableProperty]
        private string _movieTitle;

        [ObservableProperty]
        private string _movieGenre;

        [ObservableProperty]
        private int _duration;

        [ObservableProperty]
        private string _cinemaName;

        [ObservableProperty]
        private DateTime _showdate;

        public void add(int movieId, int hallId, DateTime showDate)
        {
            _showRepository.Add(movieId,hallId,showDate);
        }

        public void update(int movieId, int hallId)
        {
            _showRepository.Update(_show.ShowId, movieId, hallId, Showdate);
        }

        public void delete() 
        {
            _showRepository.Delete(_show.ShowId);
        }

        public ShowViewModel Get(int id)
        {
           ShowViewModel temp = new() { _show = _showRepository.Get(id),
               MovieTitle = _show.MovieTitle,
               MovieGenre = _show.MovieGenre,
               Duration = _show.Duration,
            CinemaName = _show.CinemaName,
           Showdate = _show.ShowDate};
            return temp;
           
        }

        public ObservableCollection<ShowViewModel> GetAll()
        {
            ObservableCollection<ShowViewModel> tempCollection = new();
            List<Show> ls = _showRepository.GetAll();
            foreach (Show s in ls)
            {
                ShowViewModel temp = new()
                {
                    _show = s,
                    MovieTitle = _show.MovieTitle,
                    MovieGenre = _show.MovieGenre,
                    Duration = _show.Duration,
                    CinemaName = _show.CinemaName,
                    Showdate = _show.ShowDate
                };
                tempCollection.Add(temp);
            }
            return tempCollection;

        }

        public void Delete()
        {
            _showRepository.Delete(_show.ShowId);
        }



    }
}
