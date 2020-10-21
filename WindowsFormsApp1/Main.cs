using EntityFrameworkCore;
using EntityFrameworkCore.Repositories.Internface;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        private IStudentRepository StudentRepository { get; }

        /// <summary>
        /// We inject the student repository here
        /// </summary>
        /// <param name="studentRepository"></param>
        public Main(IStudentRepository studentRepository)
        {
            InitializeComponent();

            // Assign Repositories
            StudentRepository = studentRepository;
        }
 

        private async void button1_Click(object sender, System.EventArgs e)
        {
            var student = await StudentRepository.FirstOrDefault(x => true);

            if (student == null)
            {
                MessageBox.Show("Student is empty");
            } else
            {

            }
            MessageBox.Show($"{student.Name} is {student.Age} years old...");
        }
    }
}
