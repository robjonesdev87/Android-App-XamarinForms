using App1_0.ViewModels.Telesales;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Telesales.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveFromListPage : PopupPage
    {
        public RemoveFromListPage(TelesalesViewModel telesalesViewModel)
        {
            BindingContext = telesalesViewModel;
            InitializeComponent();
        }
    }
}