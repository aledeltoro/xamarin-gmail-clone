using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace SimpleGmailClone.Models
{
    public class Email : INotifyPropertyChanged
    {
        public Email(string from, string to, string body, string subject = "(no subject)", string base64Image = null)
        {
            Subject = subject;
            Body = body;
            From = from;
            To = to;
            Date = DateTime.UtcNow;
            Base64Attachment = base64Image;
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Base64Attachment { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
