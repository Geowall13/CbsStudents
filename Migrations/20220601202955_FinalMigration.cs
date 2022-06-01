using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CbsStudents.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participant_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "d2021de6-ad48-4d6b-a327-91567526af82", "rasm05n1@stud.kea.dk", true, false, null, "RASM05N1@STUD.KEA.DK", "RASM05N1@STUD.KEA.DK", "AQAAAAEAACcQAAAAEKg/kTFXl4oR787TwsYRIqi/NWhx8TGnRJ+/Zr3wV7c3RKc7CXcbmMPgwqp0SvXwMA==", null, false, "2c81a5d3-bbb9-4baa-a4f0-96520100ccb4", false, "rasm05n1@stud.kea.dk" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "a005aae2-a1ba-4242-aed3-8a6ebb420911", "test@kea.dk", true, false, null, "TEST@KEA.DK", "TEST@KEA.DK", "AQAAAAEAACcQAAAAEJqPqK4MXcMP+nwttQ2PvGhcMBouyx27bQqgrtj/djEgDpaym3rb94jDlXGlbyWMnw==", null, false, "cfe784fe-9d82-462c-af44-924d84680ca1", false, "test@kea.dk" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Description", "EndTime", "Location", "StartTime", "Title", "UserId" },
                values: new object[] { 1, "Ses på grillen, det bliver super fedt", new DateTime(2022, 7, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), "Grillen", new DateTime(2022, 7, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "Grillfest", "1" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Description", "EndTime", "Location", "StartTime", "Title", "UserId" },
                values: new object[] { 2, "Vi spiller brætspil", new DateTime(2022, 6, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), "Brætspilscafeen", new DateTime(2022, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Brætspilshygge", "2" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Description", "EndTime", "Location", "StartTime", "Title", "UserId" },
                values: new object[] { 3, "Lad os studere ASP.NET sammen", new DateTime(2022, 5, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), "Hjemme hos mig", new DateTime(2022, 5, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), "Studieaften", "1" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Description", "EndTime", "Location", "StartTime", "Title", "UserId" },
                values: new object[] { 4, "Der skal drikkes bajer", null, "Guldbar", new DateTime(2022, 5, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), "Guldbar fest", "2" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "Created", "Status", "Text", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1137), 0, "This is the seeded post 1", "Post number 1", "1" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "Created", "Status", "Text", "Title", "UserId" },
                values: new object[] { 2, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1173), 0, "This is the seeded post 2", "Post number 2", "1" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "Created", "Status", "Text", "Title", "UserId" },
                values: new object[] { 3, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1175), 0, "This is the seeded post 3", "Post number 3", "2" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "Created", "PostId", "Text", "UserId" },
                values: new object[] { 1, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1192), 1, "First POGGERS", "1" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "Created", "PostId", "Text", "UserId" },
                values: new object[] { 2, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1196), 1, "Second Sadge", "2" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "Created", "PostId", "Text", "UserId" },
                values: new object[] { 3, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1198), 2, "First GigaChad", "1" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "Created", "PostId", "Text", "UserId" },
                values: new object[] { 4, new DateTime(2022, 6, 1, 22, 29, 55, 779, DateTimeKind.Local).AddTicks(1201), 1, "So many comments", "1" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 1, 1, "Rasmus Roth" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 2, 1, "Janus Pedersen" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 3, 1, "Barack Obama" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 4, 2, "Rasmus Roth" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 5, 2, "Janus Pedersen" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 6, 3, "Rasmus Roth" });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "EventId", "Name" },
                values: new object[] { 7, 4, "Rasmus Roth" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_EventId",
                table: "Participant",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");
        }

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
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
