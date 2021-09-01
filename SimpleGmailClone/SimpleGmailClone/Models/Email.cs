﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleGmailClone.Models
{
    public class Email : INotifyPropertyChanged
    {
        public Email(string from, string to, string body, string subject = "(no subject)")
        {
            Subject = subject;
            Body = body;
            From = from;
            To = to;
            Date = DateTime.UtcNow;
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
