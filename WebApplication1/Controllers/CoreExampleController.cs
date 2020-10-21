using System.Threading.Tasks;
using EntityFrameworkCore.Repositories.Internface;
using Microsoft.AspNetCore.Mvc;
using ModelsCore.TableModels;

namespace WebApplicationCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreExampleController : ControllerBase
    {
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }

        /// <summary>
        /// Here we inject the requirements
        /// </summary>
        /// <param name="studentRepository"></param>
        /// <param name="subjectRepository"></param>
        public CoreExampleController (IStudentRepository studentRepository, ISubjectRepository subjectRepository)
        {
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
        }


        /// <summary>
        /// Retrieve the student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Student/{id}")]
        public async Task<Student> GetStudentAsync ([FromRoute] int id)
        {
            return await StudentRepository.FindAsync(id);
        }

        /// <summary>
        /// Get the Subject by its code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("Subject/{code}")]
        public async Task<Subject> GetSubjectAsync([FromRoute] string code)
        {
            return await SubjectRepository.FindAsync(code);
        }
    }
}
