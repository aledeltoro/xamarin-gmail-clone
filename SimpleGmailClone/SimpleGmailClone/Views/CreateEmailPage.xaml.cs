using SimpleGmailClone.Models;
using SimpleGmailClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleGmailClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEmailPage : ContentPage
    {
        public CreateEmailPage(ObservableCollection<Email> emails)
        {
            InitializeComponent();
            BindingContext = new CreateEmailViewModel(emails);
        }
    }
}