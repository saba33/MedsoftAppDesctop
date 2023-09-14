using AddPatientePage.View;
using AutoMapper;
using MedsofAppMVP;
using MedsofAppMVP.Infrastructure.Mapping;
using MedsofAppMVP.Model.Abstraction;
using MedsofAppMVP.Model.Implementation;
using MedsofAppMVP.Presenter;
using MedsofAppMVP.View;
using MedSoftAppRepo;
using MedSoftAppRepo.Model;
using MedSoftAppRepo.Reposotory;
using System.Configuration;

namespace AddPatientePage
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            DataContext con = new DataContext();
            ApplicationConfiguration.Initialize();
            IPatientView View = new MainPageForm();
            IAddPatientView AddView = new AddPatientView();
            AutoMapper.IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingInitializer>()).CreateMapper();
            string sqlString = ConfigurationManager.ConnectionStrings["SqlConString"].ConnectionString;
            IPatientModelRepo repository = new PatientModelRepo(con, mapper);
            IGenericRepository<Patient> genericRepo = new GenericRepository<Patient>(con);
            new PatientPresenter(View, repository);

            try
            {
                Application.Run((Form)View);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}