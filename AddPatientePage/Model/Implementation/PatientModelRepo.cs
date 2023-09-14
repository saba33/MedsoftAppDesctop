using AutoMapper;
using MedsofAppMVP.Model.Abstraction;
using MedsofAppMVP.Model.entityModels;
using MedSoftAppRepo;
using MedSoftAppRepo.Model;
using MedSoftAppRepo.Reposotory;
using Microsoft.EntityFrameworkCore;

namespace MedsofAppMVP.Model.Implementation
{
    public class PatientModelRepo : GenericRepository<Patient>, IPatientModelRepo
    {
        IMapper _mapper;
        public PatientModelRepo(DataContext patientContext, IMapper _mapper) : base(patientContext)
        {
            this._mapper = _mapper;
        }

        public async void Add(AddPatientModel model)
        {
            var patientToAdd = _mapper.Map<Patient>(model);
            await this.AddAsync(patientToAdd);
        }

        public async void EditPatient(PatientDisplayModel model, int Id)
        {
            var patientToUpdate = await base.GetByIdAsync(Id);

            if (patientToUpdate != null)
            {
                base._dbContext.Entry(patientToUpdate).State = EntityState.Detached;
            }

            var updatedPatientModel = _mapper.Map<Patient>(model);

            updatedPatientModel.ID = Id;
            updatedPatientModel.GenderID = patientToUpdate.GenderID;
            base.Update(updatedPatientModel);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            var parients = await this.GetAllAsync();
            return parients;
        }

        public async Task<IEnumerable<Patient>> GetByValue(string value)
        {
            var result = await this.Search(value);
            //var patientToDisplay = _mapper.Map<Patient>(result);
            return (IEnumerable<Patient>)result;
        }

        public void RemovePatient(PatientDisplayModel model)
        {
            var patientToDelete = _mapper.Map<Patient>(model);
            var result = this.GetByIdAsync(patientToDelete.ID).Result;
            this.Remove(result);
        }

        public IEnumerable<Patient> SearchPatient(string value)
        {
            throw new NotImplementedException();
        }
    }
}
