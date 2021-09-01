using SimpleGmailClone.Models;
using SimpleGmailClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleGmailClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewEmailDetailPage : ContentPage
    {
        public ViewEmailDetailPage(Email email)
        {
            InitializeComponent();
            BindingContext = new ViewEmailDetailViewModel(email);
        }
    }
}