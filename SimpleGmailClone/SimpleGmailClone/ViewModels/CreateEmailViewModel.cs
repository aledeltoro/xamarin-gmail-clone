using SimpleGmailClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleGmailClone.ViewModels
{
    public class CreateEmailViewModel : BaseViewModel
    {
        private ObservableCollection<Email> _emails;

        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public ICommand CreateEmailCommand { get; set; }

        public CreateEmailViewModel(ObservableCollection<Email> emails)
        {
            _emails = emails;
            CreateEmailCommand = new Command(CreateEmail);
        }

        private async void CreateEmail()
        {
            _emails.Add(new Email(From, To, Body, Subject));
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
