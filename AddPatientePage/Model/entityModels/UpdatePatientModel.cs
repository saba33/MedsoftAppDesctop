namespace MedsofAppMVP.Model.entityModels
{
    public class UpdatePatientModel
    {
        private string fullName;
        public DateTime dob;
        private string gender;
        private string phone;
        private string address;
        private string privateNumber;
        private string mail;


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
