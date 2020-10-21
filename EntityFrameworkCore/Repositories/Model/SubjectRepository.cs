using EntityFrameworkCore.Repositories.Internface;
using Microsoft.EntityFrameworkCore;
using ModelsCore.ContextModels;
using ModelsCore.TableModels;
namespace EntityFrameworkCore.Repositories.Model
{
    /// <summary>
    /// We create this Repository.
    /// Since it inherits generic functions we don't need to change it anymore
    /// 
    /// </summary>
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(SqlServerContext context) : base(context)
        {
        }
    }
}
