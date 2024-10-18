using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Implementation
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly AppDbContext _context;
        public DegreeRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IEnumerable<Degree> GetAll()
        {
            List<Degree> degrees = _context.Degree.ToList();
            return degrees;
        }
        public bool InsertDegree(Degree degree)
        {
            bool result = false;
            if (degree != null)
            {
                _context.Degree.Add(degree);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateDegree(Degree degree)
        {
            var result = false;
            if (degree != null)
            {
                _context.Degree.Update(degree);
                //_appDbContext.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteDegree(int id)
        {
            var result = false;
            var degree = _context.Degree.Find(id);
            if (degree != null)
            {
                _context.Degree.Remove(degree);
                _context.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool DegreeExists(string name)
        {
            var degree = _context.Degree.FirstOrDefault(c => c.DegreeName == name);
            if (degree != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DegreeExists(int degreeId, string name)
        {
            var degree = _context.Degree.FirstOrDefault(c => c.DegreeId != degreeId && c.DegreeName == name);
            if (degree != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Degree? GetDegree(int id)
        {
            var degree = _context.Degree.FirstOrDefault(c => c.DegreeId == id);
            return degree;
        }
    }
}
