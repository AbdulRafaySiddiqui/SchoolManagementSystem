using System.Windows.Input;

namespace School_Manager
{
    public class SendMessageViewModel : BaseViewModel
    {
        #region Constructor

        public SendMessageViewModel()
        {
            //set the commands
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        #endregion

        #region Properties

        public string Message { get; set; }

        public string Response { get; set; }

        public TextEntity IpAddress { get; set; } = new TextEntity { FeildName = "IP Address", Value = "http://192.168.0.100", IsEnabled = false };

        public TextEntity Port { get; set; } = new TextEntity { FeildName = "Port", Value = "8090", IsEnabled = false };

        public TextEntity UserName { get; set; } = new TextEntity { FeildName = "Username", Value = "abcd", IsEnabled = false };

        public TextEntity Password { get; set; } = new TextEntity { FeildName = "Password", Value = "1234", IsEnabled = false };

        public TextEntity Number { get; set; } = new TextEntity { FeildName = "Enter Number", ValidationType = ValidationType.PhoneNumber };

        public TextEntity Mask { get; set; } = new TextEntity { FeildName = "Mask Name" , Value = "None" , IsEnabled = false};

        public string Count { get; set; }

        #endregion

        #region Commands

        public ICommand SendMessageCommand { get; set; }

        #endregion

        #region Command Methods

        private void SendMessage()
        {
            if(!Number.IsValid || Message.IsNullOrEmpty())
            {
                DialogManager.ShowValidationMessage();
                return;
            }
            var phone = Number.Value.Replace("-","").Remove(0,3).Insert(0,"0");
            if(phone.Length == 11)
                Response = SMS.SendSmsByMobile(phone, UserName.Value , Password.Value , IpAddress.Value , Port.Value , Message);
        }

        #endregion
    }
}
