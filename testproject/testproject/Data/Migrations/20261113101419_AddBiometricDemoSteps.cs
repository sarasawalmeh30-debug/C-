using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBiometricDemoSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BiometricDemoConsentAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FaceDemoCompleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FingerprintDemoCompleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql("UPDATE [AspNetUsers] SET [OnboardingStatus] = N'InProgress' WHERE [Email] IN (N'manager@demo.local', N'officer@demo.local', N'committee@demo.local', N'topcommittee@demo.local') AND [OnboardingStatus] = N'Completed'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiometricDemoConsentAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FaceDemoCompleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FingerprintDemoCompleted",
                table: "AspNetUsers");
        }
    }
}
