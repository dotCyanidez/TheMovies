using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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


        public MainMovieViewModel()
        {
            AddMovieCommand = new AddMovieCommand();
            //HallRepository.GetAll();
            //HallRepository.Get(2);
            HallRepository.Add(new Hall(2, 1, 11));
            HallRepository.Delete(3);
            HallRepository.Update(new Hall(2,1,7));
        }





    }
}
