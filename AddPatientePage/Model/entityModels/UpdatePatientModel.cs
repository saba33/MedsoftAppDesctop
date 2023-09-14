using MedSoftAppRepo.Infrastructure.Validators;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string Fullname
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [Required]
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        [Required]
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
        [EmailValidator(ErrorMessage = "მოცემული მეილის ფორმატი არასწორია გთხოვთ გამოასწოროთ")]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
