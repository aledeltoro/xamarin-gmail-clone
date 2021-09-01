using SimpleGmailClone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGmailClone.ViewModels
{
    public class ViewEmailDetailViewModel : BaseViewModel
    {
        public Email SelectedEmail { get; set; }
        public ViewEmailDetailViewModel(Email email)
        {
            SelectedEmail = email;
        }
    }
}
