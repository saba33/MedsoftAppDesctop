using MedsofAppMVP.Model.entityModels;
using MedSoftAppRepo.Model;

namespace MedsofAppMVP.Model.Abstraction
{
    public interface IPatientModelRepo
    {
        void Add(AddPatientModel model);
        void RemovePatient(PatientDisplayModel model);
        IEnumerable<Patient> SearchPatient(string value);
        void EditPatient(PatientDisplayModel model, int Id);
        Task<IEnumerable<Patient>> GetAll();
        Task<IEnumerable<Patient>> GetByValue(string value);
    }
}
