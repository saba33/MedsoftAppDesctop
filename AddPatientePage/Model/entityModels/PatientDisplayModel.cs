using MedSoftAppRepo.Model;
using System.ComponentModel;

namespace MedsofAppMVP.Model.entityModels
{
    public class PatientDisplayModel
    {
        private int id;
        private string fullName;
        public DateTime dob;
        private string genderName;
        private string phone;
        private string address;
        private string privateNumber;
        private string mail;
        private Gender gender;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Browsable(false)]
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DisplayName("გვარი სახელი")]
        public string Fullname
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [DisplayName("დაბადების თარიღი")]
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        [DisplayName("სქესი")]
        public string GenderName
        {
            get { return genderName; }
            set { genderName = value; }
        }
        [DisplayName("მობ ნომერი")]
        [PhoneNumberValidation(ErrorMessage = "გთხოვთ შეიყვანოთ ვალიდური ნომერი")]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        [DisplayName("მისამართი")]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        [DisplayName("პირადი ნომერი")]
        public string PrivateNumber
        {
            get { return privateNumber; }
            set { privateNumber = value; }
        }
        [DisplayName("ელექტრონული მისამართი")]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
