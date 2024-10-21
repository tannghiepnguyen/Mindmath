using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindmath.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Deposit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6994), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6995) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6991), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6988), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6981), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(6983) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(871), new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(857), new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(874), new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(868), new DateTime(2024, 10, 21, 9, 13, 56, 541, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(5259), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8528), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8510), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8522), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8519), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8525), new DateTime(2024, 10, 21, 9, 13, 56, 540, DateTimeKind.Local).AddTicks(8525) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Deposit");

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5506), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5503) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5500), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5491), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9811), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9801), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9804) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9815), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9808), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(9809) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(3644), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7193), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7173), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7186), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7182), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7189), new DateTime(2024, 10, 12, 14, 57, 10, 838, DateTimeKind.Local).AddTicks(7189) });
        }
    }
}
