using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.ViewModel
{
    public partial class MainShowViewModel : ObservableObject
    {

        public ObservableCollection<ShowViewModel> ShowVms { get; set; } = new();

        public MainShowViewModel()
        {
            ShowViewModel ShowVm = new();
            ShowVms = ShowVm.GetAll();
        }
    }
}
