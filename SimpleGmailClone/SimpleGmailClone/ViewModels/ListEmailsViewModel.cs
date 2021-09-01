using SimpleGmailClone.Models;
using SimpleGmailClone.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleGmailClone.ViewModels
{
    public class ListEmailsViewModel : BaseViewModel
    {
        public ObservableCollection<Email> Emails { get; set; } = new ObservableCollection<Email>() {
            new Email("test", "test"),
            new Email("test1", "test2"),
            new Email("test3", "test3"),
        };

        public ICommand NavigateToCreateEmailCommand { get; }

        public ListEmailsViewModel()
        {
            NavigateToCreateEmailCommand = new Command(OnCreateEmail);
        }

        private async void OnCreateEmail()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CreateEmailPage(Emails));
        }
    }
}
