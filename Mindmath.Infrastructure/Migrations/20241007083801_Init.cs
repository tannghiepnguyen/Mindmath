using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mindmath.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ChapterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfInputs = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemTypes_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InputParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProblemTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputParameters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputParameters_ProblemTypes_ProblemTypeId",
                        column: x => x.ProblemTypeId,
                        principalTable: "ProblemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    InputParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solution_InputParameters_InputParameterId",
                        column: x => x.InputParameterId,
                        principalTable: "InputParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solution_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab84eb31-7aaa-4e44-8aa9-409be54014c8", null, "Teacher", "TEACHER" },
                    { "e2c41f1e-bc94-42f8-beb5-10d3a2a406dd", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), true, new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(7906), "The study of numbers, quantities, structures, shapes, space, and change. It involves abstract concepts as well as practical problem-solving techniques that are essential in various fields such as science, engineering, economics, and more.", "Mathematics", new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(7918) });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Name", "SubjectId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"), true, new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9861), "This chapter is a branch of mathematics that deals with the properties, relationships, and measurements of points, lines, shapes, and spaces. It is one of the oldest fields of mathematics and has wide applications in various fields, from art and architecture to engineering and physics", "Geometry", new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9861) },
                    { new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"), true, new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9857), "This chapter deals with algebra and its applications in solving problems related to equations and inequalities.", "Algebra", new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9858) },
                    { new Guid("93d95c83-6594-465d-a906-7f8f899a2bfc"), true, new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9854), "This chapter deals with calculus and its applications in solving problems related to rates of change and accumulation.", "Calculus", new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9854) },
                    { new Guid("cdf594dd-ccc1-4ea8-96a0-050373ef9798"), true, new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9846), "This chapter deals with trigonometry and its applications in solving problems related to triangles and other geometric shapes.", "Trigonometry", new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), new DateTime(2024, 10, 7, 15, 38, 1, 370, DateTimeKind.Local).AddTicks(9850) }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Active", "ChapterId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"), true, new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1626), "Explains the properties of circles, including radius, diameter, chord, tangent, secant, arc, and sector. Covers important theorems related to angles in circles, such as the Inscribed Angle Theorem and Tangent-Secant Theorem.", "Circles", new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1626) },
                    { new Guid("3e552a68-c165-4007-a361-adc57e728193"), true, new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1606), "Covers solving linear equations and inequalities. Focuses on understanding equality and inequality symbols and how to manipulate equations to isolate variables.", "Equations and Inequalities", new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1610) },
                    { new Guid("66942ddf-c7c3-4a36-b8d3-a4b037ef8d1a"), true, new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1619), "Introduction to quadratic equations and methods for solving them such as factoring, completing the square, and using the quadratic formula.", "Quadratic Equations", new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1619) },
                    { new Guid("d296dbc2-f3a9-4bcd-85c1-cbb8f89ed3a8"), true, new Guid("564396d4-d864-49c2-a16c-122114f2e9b4"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1614), "Deals with equations involving two variables. Focuses on graphing these equations on a coordinate plane and understanding their geometric interpretation.", "Linear Equations", new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1614) },
                    { new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), true, new Guid("32c1e4f7-36fc-44b8-9476-b2ac48f4504a"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1621), "Explains the classification of triangles based on sides (equilateral, isosceles, scalene) and angles (acute, obtuse, right). It also introduces the properties of triangles and the Triangle Inequality Theorem.", "Triangles", new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(1622) }
                });

            migrationBuilder.InsertData(
                table: "ProblemTypes",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Name", "NumberOfInputs", "TopicId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("16a537b0-b0f8-47a5-8098-bc86926e3aa1"), true, new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4321), "Use the formula to find the perimeter.", "Perimeter of a triangle", 3, new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4322) },
                    { new Guid("46e5e215-6d10-443d-9ce0-e5f7d3948232"), true, new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4307), "Use the formula to find the circumference.", "Circumference of a Circle", 1, new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4311) },
                    { new Guid("93b76880-6e22-42f3-ad53-aa5490b6b31a"), true, new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4324), "Use the formula to find the area.", "Area of a triangle", 2, new Guid("f5a42f20-64ef-43b6-aeef-a4686a3b19dd"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4325) },
                    { new Guid("9e6d4852-9316-4006-ac2d-2e116d1fa233"), true, new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4317), "Use the formula to find the area.", "Area of a Circle", 1, new Guid("37f7aef3-f5ec-4f95-bc88-ab929877b3d5"), new DateTime(2024, 10, 7, 15, 38, 1, 371, DateTimeKind.Local).AddTicks(4318) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SubjectId",
                table: "Chapters",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_UserId",
                table: "Deposit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InputParameters_ProblemTypeId",
                table: "InputParameters",
                column: "ProblemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputParameters_UserId",
                table: "InputParameters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemTypes_TopicId",
                table: "ProblemTypes",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Solution_InputParameterId",
                table: "Solution",
                column: "InputParameterId",
                unique: true,
                filter: "[InputParameterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Solution_TransactionId",
                table: "Solution",
                column: "TransactionId",
                unique: true,
                filter: "[TransactionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ChapterId",
                table: "Topics",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Solution");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "InputParameters");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ProblemTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
