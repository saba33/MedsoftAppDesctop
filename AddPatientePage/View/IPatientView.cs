namespace MedsofAppMVP.View
{
    public interface IPatientView
    {

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }


        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler RemoveEvent;



        void SetPatientListBindingSource(BindingSource PatientList);
        void Show();
    }
}
