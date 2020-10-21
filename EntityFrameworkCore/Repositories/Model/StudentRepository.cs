using EntityFrameworkCore.Repositories.Internface;
using Microsoft.EntityFrameworkCore;
using ModelsCore.ContextModels;
using ModelsCore.TableModels;

namespace EntityFrameworkCore.Repositories.Model
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SqlServerContext context) : base(context)
        {
        }
    }
}
