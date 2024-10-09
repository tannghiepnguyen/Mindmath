using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindmath.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4598), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4594), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4531), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4523), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(4526) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8289), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8289) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8277), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8291), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8285), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(3135), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(3146) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6052), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6053) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6035), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6046), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6047) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6043), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6043) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6049), new DateTime(2024, 10, 9, 9, 15, 19, 929, DateTimeKind.Local).AddTicks(6050) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9861), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9861) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9857), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9854), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9854) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9846), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4321), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4307), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4324), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4325) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4317), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(7906), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(7918) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1626), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1606), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1619), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1619) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1614), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1621), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1622) });
        }
    }
}
