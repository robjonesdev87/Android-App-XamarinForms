using App1_0.Models;
using App1_0.ViewModels.Telesales;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditImage : PopupPage
    {

        public EditImage(object viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}