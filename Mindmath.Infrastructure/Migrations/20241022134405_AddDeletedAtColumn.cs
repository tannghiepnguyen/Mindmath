using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mindmath.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "InputParameters");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "AspNetUsers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "AspNetUsers",
                newName: "DeletedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Topics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Subjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Subjects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Subjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Solution",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Solution",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Solution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProblemTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProblemTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ProblemTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InputParameters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "InputParameters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "InputParameters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Chapters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Chapters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Chapters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7561), null, null });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7558), null, null });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7554), null, null });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(7547), null, null });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1829), null, null });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1816), null, null });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1832), null, null });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 765, DateTimeKind.Local).AddTicks(1826), null, null });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(5620), null, null });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9218), null, null });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9199), null, null });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9211), null, null });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9208), null, null });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 22, 20, 44, 4, 764, DateTimeKind.Local).AddTicks(9214), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ProblemTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "InputParameters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "InputParameters");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "AspNetUsers",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "AspNetUsers",
                newName: "CreateAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Solution",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Solution",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProblemTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProblemTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InputParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "InputParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Chapters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Chapters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2706), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2707) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2703), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2704) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2698), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2699) });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2692), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(2695) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6361), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6361) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6350), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6353) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6364), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6364) });

            migrationBuilder.UpdateData(
                table: "ProblemTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6358), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(6358) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(1188), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4218), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("3e552a68-c165-4007-a361-adc57e728193"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4201), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4212), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4209), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4215), new DateTime(2024, 10, 21, 21, 18, 16, 658, DateTimeKind.Local).AddTicks(4215) });
        }
    }
}
