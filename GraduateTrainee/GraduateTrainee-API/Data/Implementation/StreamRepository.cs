using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduateTraineeEnrollmentApi.Data.Implementation
{
    public class StreamRepository : IStreamRepository
    {
        private readonly AppDbContext _appDbContext;
        public StreamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Streams> GetPaginatedStream(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _appDbContext.Streams
                .OrderBy(c => c.StreamId)
                .Include(c => c.Degree)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }
        public IEnumerable<Streams> GetStreamsByDegreeId(int id)
        {
            var stream = _appDbContext.Streams.Where(s => s.DegreeId == id).ToList();
            return stream;
        }
        public int TotalNoOfStreams()
        {
            return _appDbContext.Streams.Count();
        }
        public IEnumerable<Streams> GetAllStreams()
        {
            var streams = new List<Streams>();
            streams = _appDbContext.Streams.Include(s => s.Degree).ToList();
            return streams;
        }
        public Streams GetStreamById(int id)
        {
            var stream = _appDbContext.Streams.Include(s => s.Degree).FirstOrDefault(s => s.StreamId == id);
            return stream;
        }
        public bool InsertStream(Streams stream)
        {
            bool result = false;
            if (stream != null)
            {
                _appDbContext.Streams.Add(stream);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateStream(Streams stream)
        {
            var result = false;
            if (stream != null)
            {
                _appDbContext.Streams.Update(stream);
                //_appDbContext.Entry(category).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteStream(int id)
        {
            var result = false;
            var stream = _appDbContext.Streams.Find(id);
            if (stream != null)
            {
                _appDbContext.Streams.Remove(stream);
                _appDbContext.SaveChanges();
                result = true;
            }

            return result;
        }
        public bool StreamExists(string name, int degreeId)
        {
            var stream = _appDbContext.Streams.FirstOrDefault(c => c.StreamName == name && c.DegreeId == degreeId);
            if (stream != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool StreamExists(int categoryId, string name, int degreeId)
        {
            var stream = _appDbContext.Streams.FirstOrDefault(c => c.StreamId != categoryId && c.StreamName == name && c.DegreeId == degreeId);
            if (stream != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
