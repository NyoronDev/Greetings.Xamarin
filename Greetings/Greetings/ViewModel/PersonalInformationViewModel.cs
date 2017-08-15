using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings.ViewModel
{
    public class PersonalInformationViewModel : ViewModelBase
    {
        private string _name;
        private string _emailAddress;
        private string _phoneNumber;
        private int _age;
        private bool _isProgrammer;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        public bool IsProgrammer
        {
            get { return _isProgrammer; }
            set { SetProperty(ref _isProgrammer, value); }
        }
    }
}
