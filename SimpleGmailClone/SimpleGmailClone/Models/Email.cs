using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleGmailClone.Models
{
    public class Email : INotifyPropertyChanged
    {
        public Email(string subject, string body, string receiver = "johndoe@gmail.com")
        {
            Subject = subject;
            Body = body;
            Receiver = receiver;
            Date = DateTime.UtcNow;
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
