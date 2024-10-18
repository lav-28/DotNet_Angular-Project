using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateTraineeEnrollmentApi.Migrations
{
    public partial class SeedProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[TraineeEnrollmentReport]
                                    AS
                                    BEGIN
	                                    SELECT d.DegreeName, s.StreamName,COUNT(gt.TraineeName) as TotalTraineeCount  FROM GraduateTrainees gt 
	                                    JOIN Degree d on d.DegreeId = gt.DegreeId
	                                    JOIN Streams s on s.StreamId = gt.StreamId
	                                    GROUP BY d.DegreeName , s.StreamName
                                    END
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS TraineeEnrollmentReport");
        }
    }
}
