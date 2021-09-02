using Newtonsoft.Json;
using Plugin.LocalNotification;
using SimpleGmailClone.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
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
        public ImageSource Attachment { get; set; }
        private string _base64Image { get; set; }

        public ICommand CreateEmailCommand { get; set; }
        public ICommand AttachPhotoCommand { get; set; }

        public CreateEmailViewModel(ObservableCollection<Models.Email> emails)
        {
            _emails = emails;

            CreateEmailCommand = new Command(CreateEmail);
            AttachPhotoCommand = new Command(AttachPhoto);
        }

        private async void CreateEmail()
        {
            var newEmail = new Models.Email(From, To, Body, Subject, _base64Image);
            _emails.Add(newEmail);

            var jsonString = JsonConvert.SerializeObject(_emails);
            Preferences.Set("emails", jsonString);

            await App.Current.MainPage.Navigation.PopAsync();

            SendNotification();
        }

        private async void SendNotification()
        {
            var notification = new NotificationRequest
            {
                Title = "Email status",
                Description = "Email was sent successfully", 
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                }
            };

            await NotificationCenter.Current.Show(notification);
        }

        private async void AttachPhoto()
        {
            var image = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            _base64Image = Convert.ToBase64String(File.ReadAllBytes(image.FullPath));

            var imageStream = await image.OpenReadAsync();
            Attachment = ImageSource.FromStream(() => imageStream);
        }
    }
}
