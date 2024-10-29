using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindmath.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(6511));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 15, 19, 25, 785, DateTimeKind.Local).AddTicks(6514));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9214));
        }
    }
}
