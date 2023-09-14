using MedsofAppMVP;
using MedsofAppMVP.View;

namespace AddPatientePage.View
{
    public partial class MainPageForm : Form, IPatientView
    {
        private bool isSuccessful;
        private string message;
        private bool isEdit;

        public MainPageForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            SearchBtn.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            Search.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            AddBtn.Click += delegate
            {
                var addPatientForm = new AddPatientView();
                addPatientForm.ShowDialog();
            };

            EditBtn.Click += delegate
            {
                var result = MessageBox.Show("ნამდვილად გსურთ პაციენტის რედაქტირება ? ",
                    MessageBoxButtons.YesNo.ToString(), MessageBoxButtons.OKCancel);
                EditEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("პაციენტი რედაქტირებულია");
            };

            RemoveBtn.Click += delegate
            {
                var result = MessageBox.Show("ნამდვილად გსურთ პაციენტის წაშლა ? ",
                    MessageBoxButtons.YesNo.ToString(), MessageBoxButtons.OKCancel);
                RemoveEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("პაციენტი წაიშალა ბაზიდან");
            };


        }


        public string SearchValue { get => Search.Text; set => Search.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }


        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler RemoveEvent;


        public void SetPatientListBindingSource(BindingSource PatientList)
        {
            guna2DataGridView1.DataSource = PatientList;
        }

        private void MainPageForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
