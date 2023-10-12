using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using TheMovies.Command;
using TheMovies.Model;

namespace TheMovies.ViewModel
{
    public partial class MainMovieViewModel : ObservableObject
    {
        [ObservableProperty]
        private MovieViewModel _movieVM = new();

        public ICommand AddMovieCommand { get;}

        HallRepository HallRepository = new();
        ShowRepository ShowRepository = new();

        ShowViewModel ShowViewModel = new();


        public MainMovieViewModel()
        {
            AddMovieCommand = new AddMovieCommand();
            ShowViewModel = new ShowViewModel();
            //HallRepository.GetAll();
            //HallRepository.Get(2);
            //HallRepository.Add(new Hall(2, 1, 11));
            //HallRepository.Delete(3);
            //HallRepository.Update(new Hall(2,1,7));

            //ShowRepository.Add(2, 2, DateTime.Now.AddDays(5));
            //ShowRepository.Add(2, 2, DateTime.Now.AddDays(7));
            //ShowRepository.Add(9, 2, DateTime.Now.AddMonths(2));
            List<Show> ls = ShowRepository.GetAllWhitin30();
           
        }
        public List<Show> ShowListOfShows()
        {
            List<Show> ls = ShowRepository.GetAllWhitin30();
            return ls;
        }




    }
}
