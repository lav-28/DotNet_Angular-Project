using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GraduateTraineeEnrollmentApi.Models
{
    public partial class AppDbContext
    {
        private IAppDbContextProcedures _procedures;

        public virtual IAppDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new AppDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IAppDbContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TraineeEnrollmentReportResult>().HasNoKey().ToView(null);
        }
    }

    public partial class AppDbContextProcedures : IAppDbContextProcedures
    {
        private readonly AppDbContext _context;

        public AppDbContextProcedures(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<TraineeEnrollmentReportResult>> TraineeEnrollmentReportAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<TraineeEnrollmentReportResult>("EXEC @returnValue = [dbo].[TraineeEnrollmentReport]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }


    }
}
