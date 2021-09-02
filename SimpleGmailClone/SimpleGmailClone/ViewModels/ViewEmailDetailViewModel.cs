using SimpleGmailClone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SimpleGmailClone.ViewModels
{
    public class ViewEmailDetailViewModel : BaseViewModel
    {
        public Email SelectedEmail { get; set; }
        public ImageSource Attachment
        {
            get
            {
                var byteArray = Convert.FromBase64String(SelectedEmail.Base64Attachment);
                var stream = new MemoryStream(byteArray);

                return ImageSource.FromStream(() => stream);
            }
        }

        public ViewEmailDetailViewModel(Email email)
        {
            SelectedEmail = email;
        }
    }
}
