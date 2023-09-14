using System.ComponentModel;

namespace MedsofAppMVP.Model.entityModels
{
    public class PatientModel
    {
        private int id;
        private string fullName;
        public DateTime dob;
        private string gender;
        [Browsable(false)]
        public int GenderId { get; set; }
        private string phone;
        private string address;
        private string privateNumber;
        private string mail;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Fullname
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        [DisplayName("სქესი")]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [PhoneNumberValidation(ErrorMessage = "გთხოვთ შეიყვანოთ ვალიდური ნომერი")]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PrivateNumber
        {
            get { return privateNumber; }
            set { privateNumber = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}


