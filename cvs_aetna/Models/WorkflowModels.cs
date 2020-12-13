using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okta.Sdk;

namespace okta_aspnetcore_mvc_example.Models
{
    public class WorkflowModels
    {
        public string oktaId { get; set; }
        public string consent { get; set; }

    }


    public class RegisterUserModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

    }


    public class UpdateProfileModel
    {
        public string oktaId { get; set; }
        //common attributes
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        //consumer attributes
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

        //consumer progressive attributes
        public Int64 age { get; set; }
        public Int64 weight { get; set; }
        public string gender { get; set; }

        //provider attributes
        //public string licenseState { get; set; }
        //public string providerId { get; set; }
        //public string practiceName { get; set; }

    }


    public class UpdatePreferenceModel
    {
        public string oktaId { get; set; }
        //preferences
        public bool Promotions { get; set; }
        public bool ProductUpdates { get; set; }
        public bool Webinars { get; set; }
    }


    public class UserProfileModel
    {
        //common attributes
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        //consumer attributes
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string consumerId { get; set; }

        //consumer progressive attributes
        public Int64 age { get; set; }
        public Int64 weight { get; set; }
        public string gender { get; set; }


        //provider attributes
        public string licenseState { get; set; }
        public string providerId { get; set; }
        public string practiceName { get; set; }

        //preferences
        public bool Promotions { get; set; }
        public bool ProductUpdates { get; set; }
        public bool Webinars { get; set; }

        //consent
        public string consent { get; set; }
        public string level_of_assurance { get; set; }
        public string last_verification_date { get; set; }

        //app related
        public string auth_idp { get; set; }
        public string oktaId { get; set; }
        public string primaryRole { get; set; }
        public List<AppLink> assignedApps { get; set; }
        public List<string> unassignedApps { get; set; }

        public List<ListPermissionModel> listPermissions { get; set; }

        public List<ListDelegateModel> listDelegates { get; set; }
    }

    public class ListPermissionModel
    {
        public string userName { get; set; }
        public string oktaId { get; set; }
        public string email { get; set; }
    }

    public class ListDelegateModel
    {
        public string userName { get; set; }
        public string oktaId { get; set; }
        public string email { get; set; }
    }

    public class RequestAppModel
    {
        public string appName { get; set; }
        public string oktaId { get; set; }
        public string email { get; set; }
    }

    public class DelegateUserModel
    {
        public string delegateFirstName { get; set; }
        public string delegateLastName { get; set; }
        public string delegateEmail { get; set; }
        public string delegateOktaId { get; set; }
        public string parentOktaId { get; set; }
        public string parentEmail { get; set; }
        public string searchCriteria { get; set; }
    }
}
