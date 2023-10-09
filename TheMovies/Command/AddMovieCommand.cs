using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheMovies.ViewModel;

namespace TheMovies.Command
{
    public class AddMovieCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MainMovieViewModel mmvm;
            if (parameter is MainMovieViewModel)
            {
                mmvm = (MainMovieViewModel)parameter;
            }
            else
                return;

            string messageBoxText = string.Empty;
            string messageBoxCaption = "Der skete en fejl";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult messageBoxResult;
            try
            {

                if (mmvm.MovieVM.Title.IsNullOrEmpty())
                    throw new Exception("Du skal skrive en titel");

                if (mmvm.MovieVM.Duration <= 0)
                    throw new Exception("Du skal indtaste filmens længde i minutter");


                if (mmvm.MovieVM.Genre.IsNullOrEmpty())
                    throw new Exception("Du skal skrive en genre");

                Exception ex = mmvm.MovieVM.Add();
                if ( ex != null)
                    throw new Exception(ex.Message);

            }
            catch (Exception ex)
            {
                messageBoxText = ex.Message;
                messageBoxResult = MessageBox.Show(messageBoxText,messageBoxCaption,button);
                return;
            }

            messageBoxText = $"Filmen: {mmvm.MovieVM.Title} er tilføjet";
            messageBoxCaption = "Film tilføjet";
            messageBoxResult = MessageBox.Show(messageBoxText, messageBoxCaption, button);


        }
    }
}
