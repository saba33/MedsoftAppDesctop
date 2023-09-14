using AutoMapper;
using MedsofAppMVP.Infrastructure.Mapping;
using MedsofAppMVP.Model.Abstraction;
using MedsofAppMVP.Model.entityModels;
using MedsofAppMVP.View;
using MedSoftAppRepo.Model;

namespace MedsofAppMVP.Presenter
{
    public class PatientPresenter
    {
        private IPatientView view;
        private IPatientModelRepo repo;
        private IAddPatientView addPatientView = new AddPatientView();
        private BindingSource patientsBindingSource;
        private IEnumerable<PatientDisplayModel> patientList;
        private IEnumerable<Patient> Patients;
        AutoMapper.IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingInitializer>()).CreateMapper();
        public PatientPresenter(IPatientView view, IPatientModelRepo repo)
        {
            this.patientsBindingSource = new BindingSource();
            this.view = view;
            this.repo = repo;
            this.addPatientView.AddPatientToListEvent += AddToDb;
            this.view.SearchEvent += SearchPatient;
            this.view.AddNewEvent += AddPatient;
            this.view.EditEvent += LoadSelectedPatientToEdit;
            this.view.RemoveEvent += RemoveSelectedPatient;

            this.view.SetPatientListBindingSource(patientsBindingSource);
            LoadAllPatientList();
            this.view.Show();
        }
        public void LoadAllPatientList()
        {
            Patients = repo.GetAll().Result;
            var dataToDisplay = mapper.Map<IEnumerable<PatientDisplayModel>>(Patients);
            patientsBindingSource.DataSource = dataToDisplay;
        }

        private void SearchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                Patients = repo.GetByValue(this.view.SearchValue).Result;
                patientList = mapper.Map<IEnumerable<PatientDisplayModel>>(Patients);
            }

            else
            {
                var list = repo.GetAll().Result;
                patientList = mapper.Map<IEnumerable<PatientDisplayModel>>(list);
            }
            patientsBindingSource.DataSource = patientList;
        }

        private void AddToDb(object sender, EventArgs e)
        {

            AddPatientModel model = new AddPatientModel
            {
                Address = this.addPatientView.Address,
                Dob = this.addPatientView.Dob,
                Fullname = this.addPatientView.FullName,
                Gender = this.addPatientView.Gender,
                Mail = this.addPatientView.Mail,
                Phone = this.addPatientView.Phone,
                PrivateNumber = this.addPatientView.PrivateNumber,
            };
            repo.Add(model);
            LoadAllPatientList();
        }

        private void RemoveSelectedPatient(object sender, EventArgs e)
        {
            PatientDisplayModel result = (PatientDisplayModel)patientsBindingSource.Current;
            repo.RemovePatient(result);
            LoadAllPatientList();
        }

        private void LoadSelectedPatientToEdit(object sender, EventArgs e)
        {
            PatientDisplayModel result = (PatientDisplayModel)patientsBindingSource.Current;
            int id = result.Id;
            repo.EditPatient(result, id);
            LoadAllPatientList();
        }

        private void AddPatient(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
