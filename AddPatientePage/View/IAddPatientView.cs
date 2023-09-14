namespace MedsofAppMVP.View
{
    public interface IAddPatientView
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PrivateNumber { get; set; }
        public string Mail { get; set; }

        event EventHandler AddPatientToListEvent;

    }
}
