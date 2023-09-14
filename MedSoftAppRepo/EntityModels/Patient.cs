using MedSoftAppRepo.Infrastructure.Validators;

namespace MedSoftAppRepo.Model
{
    public class Patient
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public int GenderID { get; set; }
        [PhoneNumberValidation(ErrorMessage = "გთხოვთ შეიყვანოთ სწორი ნომერი")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PrivateNumber { get; set; }
        [EmailValidator(ErrorMessage = "მოცემული მეილის ფორმატი არასწორია გთხოვთ გამოასწოროთ")]
        public string Mail { get; set; }
        public Gender Gender { get; set; }
    }
}
