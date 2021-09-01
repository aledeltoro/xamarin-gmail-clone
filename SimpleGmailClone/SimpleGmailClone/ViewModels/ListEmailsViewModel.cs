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
            new Email("test@gmail.com", "test@yahoo.com", "testing message", "Test"),
            new Email("test@gmail.com", "test@yahoo.com", "testing message", "Test"),
            new Email("test@gmail.com", "test@yahoo.com", "testing message", "Test"),
        };

        private Email _selectedEmail;
        public Email SelectedEmail 
        { 
            get
            {
                return _selectedEmail;
            }
            set
            {
                _selectedEmail = value;

                if (_selectedEmail != null)
                {
                    SelectedEmailCommand.Execute(_selectedEmail);
                }
            }
        }

        public ICommand NavigateToCreateEmailCommand { get; }
        public ICommand DeleteEmailCommand { get; set; }
        public ICommand SelectedEmailCommand { get; set; }

        public ListEmailsViewModel()
        {
            NavigateToCreateEmailCommand = new Command(OnCreateEmail);
            SelectedEmailCommand = new Command<Email>(OnEmailSelected);
            DeleteEmailCommand = new Command<Email>(DeleteEmail);
        }

        private async void OnCreateEmail()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CreateEmailPage(Emails));
        }

        private void DeleteEmail(Email email)
        {
            Emails.Remove(email);
        }

        private async void OnEmailSelected(Email email)
        {
           await App.Current.MainPage.Navigation.PushAsync(new ViewEmailDetailPage(email));
        }
    }
}
