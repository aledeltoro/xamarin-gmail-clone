using Newtonsoft.Json;
using SimpleGmailClone.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SimpleGmailClone.ViewModels
{
    public class CreateEmailViewModel : BaseViewModel
    {
        private ObservableCollection<Models.Email> _emails;

        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public ICommand CreateEmailCommand { get; set; }

        public CreateEmailViewModel(ObservableCollection<Models.Email> emails)
        {
            _emails = emails;
            CreateEmailCommand = new Command(CreateEmail);
        }

        private async void CreateEmail()
        {
            _emails.Add(new Models.Email(From, To, Body, Subject));

            var jsonString = JsonConvert.SerializeObject(_emails);
            Preferences.Set("emails", jsonString);

            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
