namespace GraduateTraineeEnrollmentApi.Models
{
    public partial interface IAppDbContextProcedures
    {
        Task<List<TraineeEnrollmentReportResult>> TraineeEnrollmentReportAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
