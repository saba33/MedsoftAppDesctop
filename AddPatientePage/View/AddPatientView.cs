using MedsofAppMVP.View;
using MedSoftAppRepo;
using MedSoftAppRepo.Model;
using MedSoftAppRepo.Reposotory;

namespace MedsofAppMVP
{
    public partial class AddPatientView : Form, IAddPatientView
    {
        GenericRepository<Patient> repository;

        public AddPatientView()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            DataContext con = new DataContext();
            repository = new GenericRepository<Patient>(con);
        }

        public void AssociateAndRaiseEvents()
        {
            SaveBtn.Click += delegate
            {
                AddPatientToListEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        string IAddPatientView.FullName { get => FullName.Text; set => FullName.Text = value; }
        DateTime IAddPatientView.Dob { get => DateTime.Parse(Dob.Text); set => Dob.Text = value.ToString(); }
        string IAddPatientView.Gender { get => Gender.Text; set => Gender.Text = value; }
        string IAddPatientView.Phone { get => Phone.Text; set => Phone.Text = value; }
        string IAddPatientView.Address { get => Address.Text; set => Address.Text = value; }
        string IAddPatientView.PrivateNumber { get => PrivateNumber.Text; set => PrivateNumber.Text = value; }
        string IAddPatientView.Mail { get => Mail.Text; set => Mail.Text = value; }

        public event EventHandler AddPatientToListEvent;

        private void AddPatientView_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ნამდვილად გსურთ პაციენტის დამატება ?",
                   MessageBoxButtons.YesNo.ToString(), MessageBoxButtons.OKCancel);
            repository.Add(new Patient
            {
                Address = Address.Text,
                FullName = FullName.Text,
                Dob = DateTime.Parse(Dob.Text),
                Gender = new Gender { GenderName = Gender.Text },
                Mail = Mail.Text,
                Phone = Phone.Text,
                PrivateNumber = PrivateNumber.Text,
            });
            MessageBox.Show($"პაციენტი პირადი ნომრით {PrivateNumber.Text} წარმატებით დაემატა ბაზაში");
        }
    }
}
