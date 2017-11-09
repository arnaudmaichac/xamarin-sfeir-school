using MovieApp.Core.Models;
using MovieApp.Core.Services;
using MvvmHelpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MovieApp.Core.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableRangeCollection<Movie> Movies { get; } = new ObservableRangeCollection<Movie>();

        private Movie selectedMovie;
        public Movie SelectedMovie
        {
            get
            {
                return selectedMovie;
            }
            set
            {
                if (selectedMovie != null)
                {
                    NavigateToDetailPage();
                    selectedMovie = null;
                }

                selectedMovie = value;
                OnPropertyChanged();
            }
        }

        private readonly INavigation navigation;
        private readonly MovieService movieService;

        public MainViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            this.movieService = new MovieService();
        }

        public async void GetData()
        {
            Movies.AddRange(await movieService.GetMoviesByName());
        }

        private async void NavigateToDetailPage()
        {
            await navigation.PushAsync(new DetailsPage(selectedMovie));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
