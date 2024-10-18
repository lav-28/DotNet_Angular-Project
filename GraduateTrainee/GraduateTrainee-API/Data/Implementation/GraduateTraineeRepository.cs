using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduateTraineeEnrollmentApi.Data.Implementation
{
    public class GraduateTraineeRepository : IGraduateTraineeRepository
    {
        private readonly AppDbContext _appDbContext;
        public GraduateTraineeRepository(AppDbContext appDbContext)
        {
            _appDbContext  = appDbContext;
        }
        public IEnumerable<GraduateTrainees> GetAll()
        {
            var trainees = new List<GraduateTrainees>();
            trainees = _appDbContext.GraduateTrainees.Include(p => p.Stream).Include(p => p.Degree).ToList();
            return trainees;
        }
        public GraduateTrainees? GetGraduateTraineeById(int id)
        {
            var graduatetrainee = _appDbContext.GraduateTrainees.Include(p => p.Stream).Include(p => p.Degree).FirstOrDefault(c => c.GraduateTraineeId == id);
            return graduatetrainee;
        }
        public bool InsertGraduateTrainee(GraduateTrainees trainee)
        {
            bool result = false;
            if (trainee != null)
            {
                _appDbContext.GraduateTrainees.Add(trainee);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateGraduateTrainee(GraduateTrainees trainee)
        {
            var result = false;
            if (trainee != null)
            {
                _appDbContext.GraduateTrainees.Update(trainee);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool GraduateTraineeExists(string name)
        {
            var graduateTrainee = _appDbContext.GraduateTrainees.FirstOrDefault(c => c.TraineeEmail == name);
            if (graduateTrainee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GraduateTraineeExists(int graduateTraineeId, string name)
        {
            var trainee = _appDbContext.GraduateTrainees.FirstOrDefault(c => c.GraduateTraineeId != graduateTraineeId && c.TraineeEmail == name);
            if (trainee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsDateValid(DateTime dateTime)
        {
            var date = _appDbContext.GraduateTrainees.FirstOrDefault(c=> c.DateOfApplication == dateTime);
            if(dateTime > DateTime.Now)
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        public bool IsLastSemsterPending(bool res)
        {
            bool result = true;
            var trainesLastSem = _appDbContext.GraduateTrainees.Where(c=>c.IsLastSemesterPending).ToString();
            if(trainesLastSem == "true")
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }
        public IEnumerable<TraineeEnrollmentReportResult> TraineeEnrollmentReport()
        {
            List<TraineeEnrollmentReportResult> report = _appDbContext.TraineeEnrollmentReport().ToList();
            return report;
        }
        public bool DeleteGraduateTrainee(int id)
        {
            var result = false;
            var trainee = _appDbContext.GraduateTrainees.Find(id);
            if (trainee != null)
            {
                _appDbContext.GraduateTrainees.Remove(trainee);
                _appDbContext.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}
