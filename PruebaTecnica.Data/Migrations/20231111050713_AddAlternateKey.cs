using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica.Data.Migrations
{
    public partial class AddAlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesExperiences_Candidates_CandidateId",
                table: "CandidatesExperiences");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidates",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Candidates_Email",
                table: "Candidates",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesExperiences_Candidates_CandidateId",
                table: "CandidatesExperiences",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesExperiences_Candidates_CandidateId",
                table: "CandidatesExperiences");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Candidates_Email",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidates",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesExperiences_Candidates_CandidateId",
                table: "CandidatesExperiences",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
