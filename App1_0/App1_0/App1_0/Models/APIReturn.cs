using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace App1_0.Models
{
    public class APIReturn
    {
        public class Login
        {
            public string Token { get; set; }
        }

        public class GetLoggedInUser
        {
            public string Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string RoleName { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public string MobileNumber { get; set; } = string.Empty;
            public string PhoneNumber { get; set; }
            public int SitFeeAmount { get; set; }
            public int CommissionFeePercent { get; set; }
            public string FirebaseToken { get; set; }

        }

        public class GetUserMessages
        {
            public string Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string RoleName { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public string MobileNumber { get; set; } = string.Empty;
            public string PhoneNumber { get; set; }
            public int SitFeeAmount { get; set; }
            public int CommissionFeePercent { get; set; }
            public string FirebaseToken { get; set; }
            public ObservableCollection<UserMessages> Messages { get; set; } = new ObservableCollection<UserMessages>();
        }

        public class GetUserJobs
        {
            public Job Job { get; set; }
        }

        public class GetClientWithId
        {
            public string Id { get; set; }
            public string GlobalStatus { get; set; } = String.Empty;
            public List<JobUsers> DeclinedUsers { get; set; } = new List<JobUsers>();
            public CanvasData CanvasData { get; set; }
            public Information Information { get; set; }
            public SalesData SalesData { get; set; }
            public SurveyData SurveyData { get; set; }

        }

    }
}
