using System;
using System.IO;
using System.Windows.Input;

namespace School_Manager
{
    public class AboutViewModel : BaseViewModel
    {
        #region Constructor

        public AboutViewModel()
        {
            //set the properties
            ProductID = ProductInformation.ProductID;
            ProductVersion = ProductInformation.ProductVersion;
            RegisteredDate = ProductInformation.RegistrationDate;
            RegisteredTo= ProductInformation.RegisteredTo;

            var registration = DataAccess.CheckRegistration();
            if(registration.Type == "FullTime")
            {
                ProductRegistration = "Full Time";
                ExpireIn = "No Expirey";
            }
            else if(registration.Type == "Monthly")
            {
                ProductRegistration = "Monthly";
                ExpireIn = $"{registration.DaysLeft} Days";
            }
            else if (registration.Type == "HalfYearly")
            {
                ProductRegistration = "Half Yearly";
                ExpireIn = $"{registration.DaysLeft} Days";
            }
            else if (registration.Type == "Yearly")
            {
                ProductRegistration = "Yearly";
                ExpireIn = $"{registration.DaysLeft} Days";
            }

            OpenLicenceCommand = new RelayCommand(OpenLicence);
        }

        #endregion

        #region Properties

        public string ProductID { get; set; }

        public string RegisteredTo { get; set; }

        public string RegisteredDate { get; set; }

        public string ProductVersion { get; set; }

        public string ProductRegistration { get; set; }

        public string ExpireIn { get; set; }

        public string Licence { get; set; }

        public bool LicenceHeaderVisibility { get; set; }

        #endregion

        #region Commands

        public ICommand OpenLicenceCommand { get; set; }

        #endregion

        #region Command Method

        private void OpenLicence()
        {
            try
            {
                Licence = File.ReadAllText("Licence.txt");
                if (Licence.IsNotNullOrEmpty())
                    LicenceHeaderVisibility = true;
            }
            catch(Exception ex)
            {
                Logger.Log(ex, true);
            }
        }

        #endregion
    }
}
