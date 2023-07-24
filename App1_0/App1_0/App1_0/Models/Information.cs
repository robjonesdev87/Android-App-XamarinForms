using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App1_0.Models
{
    public class Information : ObservableObject
    {
        public string Title { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string LandlineNumber { get; set; } 
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ServiceRequired { get; set; } 
        public string PboReason { get; set; } 
        public string TweakTime { get; set; } 
        public string EmploymentStatus { get; set; } 
        public string HouseNumber { get; set; } 
        public string Address { get; set; } 
        public string Postcode { get; set; } 
        public string TypeOfHouse { get; set; }
        public string NumberOfWindows { get; set; }
        public string NumberOfDoors { get; set; }
        public string NumberOfFrenchDoors { get; set; }
        public string WindowType { get; set; }
        public string EstAge { get; set; } 
        public string EstOccupation { get; set; } 
        public string EstServicesRequired { get; set; } 
        public string ConfirmWith { get; set; } 
        public string Notes { get; set; } 
        public DateTime? CreationDate { get; set; }
        public ObservableCollection<string> TitlesCollection { get; set; }
        public ObservableCollection<string> EmploymentCollection { get; set; }
        public ObservableCollection<string> TypeOfHouseCollection { get; set; }
        public ObservableCollection<string> WindowTypeCollection { get; set; }
        public ObservableCollection<string> ServiceRequiredCollection { get; set; }


    }

}
