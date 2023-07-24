using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App1_0.Models 
{
    public class ClientValidation : ObservableObject
    {
        private bool firstNameValid;
        private bool lastNameValid;
        private bool addressValid;
        private bool postcodeValid;
        private bool totalToBePaidValid;
        private bool depositTotalValid;
        private bool inventoryRequiredValid;
        private bool measurementsValid;

        public bool FirstNameValid
        {
            get => firstNameValid;
            set => SetProperty(ref firstNameValid, value);
        }
        public bool LastNameValid
        {
            get => lastNameValid;
            set => SetProperty(ref lastNameValid, value);
        }
        public bool AddressValid {
            get => addressValid;
            set => SetProperty(ref addressValid, value);
        }
        public bool PostcodeValid { 
            get => postcodeValid;
            set => SetProperty(ref postcodeValid, value);
        }

        public bool DepositTotalValid
        {
            get => depositTotalValid;
            set => SetProperty(ref depositTotalValid, value);
        }

        public bool TotalToBePaidValid
        {
            get => totalToBePaidValid;
            set => SetProperty(ref totalToBePaidValid, value);
        }

        public bool InventoryRequiredValid
        {
            get => inventoryRequiredValid;
            set => SetProperty(ref inventoryRequiredValid, value);
        }

        public bool MeasurementsValid
        {
            get => measurementsValid;
            set => SetProperty(ref measurementsValid, value);
        }

    }
}
