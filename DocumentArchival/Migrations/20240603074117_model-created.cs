using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentArchival.Migrations
{
    /// <inheritdoc />
    public partial class modelcreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dep01departments",
                columns: table => new
                {
                    dep01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dep01title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dep01code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dep01status = table.Column<bool>(type: "bit", nullable: false),
                    dep01deleted = table.Column<bool>(type: "bit", nullable: false),
                    dep01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dep01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dep01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dep01updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dep01departments", x => x.dep01uin);
                });

            migrationBuilder.CreateTable(
                name: "des01designations",
                columns: table => new
                {
                    des01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    des01code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des01title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des01description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des01status = table.Column<bool>(type: "bit", nullable: false),
                    des01deleted = table.Column<bool>(type: "bit", nullable: false),
                    des01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    des01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    des01updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_des01designations", x => x.des01uin);
                });

            migrationBuilder.CreateTable(
                name: "des02functional_titles",
                columns: table => new
                {
                    des02uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    des02code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des02title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des02remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des02status = table.Column<bool>(type: "bit", nullable: false),
                    des02deleted = table.Column<bool>(type: "bit", nullable: false),
                    des02created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des02created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    des02updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    des02updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_des02functional_titles", x => x.des02uin);
                });

            migrationBuilder.CreateTable(
                name: "lvl01employee_levels",
                columns: table => new
                {
                    lvl01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lvl01title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lvl01description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lvl01code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lvl01status = table.Column<bool>(type: "bit", nullable: false),
                    lvl01deleted = table.Column<bool>(type: "bit", nullable: false),
                    lvl01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lvl01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lvl01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lvl01updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lvl01employee_levels", x => x.lvl01uin);
                });

            migrationBuilder.CreateTable(
                name: "set03provinces",
                columns: table => new
                {
                    set03uin = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    set03code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set03title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set03remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set03status = table.Column<bool>(type: "bit", nullable: false),
                    set03deleted = table.Column<bool>(type: "bit", nullable: false),
                    set03created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set03created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    set03updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set03updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set03provinces", x => x.set03uin);
                });

            migrationBuilder.CreateTable(
                name: "set04districts",
                columns: table => new
                {
                    set04uin = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    set04set03uin = table.Column<byte>(type: "tinyint", nullable: false),
                    set04code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set04title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set04remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set04status = table.Column<bool>(type: "bit", nullable: false),
                    set04deleted = table.Column<bool>(type: "bit", nullable: false),
                    set04created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set04created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    set04updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set04updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set04districts", x => x.set04uin);
                    table.ForeignKey(
                        name: "FK_set04districts_set03provinces_set04set03uin",
                        column: x => x.set04set03uin,
                        principalTable: "set03provinces",
                        principalColumn: "set03uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "set05municipalities",
                columns: table => new
                {
                    set05uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    set05set04uin = table.Column<byte>(type: "tinyint", nullable: false),
                    set05code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set05type = table.Column<byte>(type: "tinyint", nullable: false),
                    set05title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set05remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set05address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set05telphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set05status = table.Column<bool>(type: "bit", nullable: false),
                    set05deleted = table.Column<bool>(type: "bit", nullable: false),
                    set05created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set05created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    set05updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    set05updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set05municipalities", x => x.set05uin);
                    table.ForeignKey(
                        name: "FK_set05municipalities_set04districts_set05set04uin",
                        column: x => x.set05set04uin,
                        principalTable: "set04districts",
                        principalColumn: "set04uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bra01branches",
                columns: table => new
                {
                    bra01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bra01name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bra01address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bra01telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bra01status = table.Column<bool>(type: "bit", nullable: false),
                    bra01deleted = table.Column<bool>(type: "bit", nullable: false),
                    bra01code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bra01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bra01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bra01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bra01updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bra01set05uin_muncipality = table.Column<int>(type: "int", nullable: false),
                    bra01is_head_office = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bra01branches", x => x.bra01uin);
                    table.ForeignKey(
                        name: "FK_bra01branches_set05municipalities_bra01set05uin_muncipality",
                        column: x => x.bra01set05uin_muncipality,
                        principalTable: "set05municipalities",
                        principalColumn: "set05uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emp01employees",
                columns: table => new
                {
                    emp01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp01code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp01des01uin = table.Column<int>(type: "int", nullable: false),
                    emp01dep01uin = table.Column<int>(type: "int", nullable: false),
                    emp01lvl01uin = table.Column<int>(type: "int", nullable: false),
                    emp01bra01uin = table.Column<int>(type: "int", nullable: false),
                    emp01des02uin = table.Column<int>(type: "int", nullable: false),
                    emp01name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp01address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp01email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp01mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp01status = table.Column<bool>(type: "bit", nullable: false),
                    emp01deleted = table.Column<bool>(type: "bit", nullable: false),
                    emp01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    emp01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp01updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    emp01is_on_leave = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp01employees", x => x.emp01uin);
                    table.ForeignKey(
                        name: "FK_emp01employees_bra01branches_emp01bra01uin",
                        column: x => x.emp01bra01uin,
                        principalTable: "bra01branches",
                        principalColumn: "bra01uin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emp01employees_dep01departments_emp01dep01uin",
                        column: x => x.emp01dep01uin,
                        principalTable: "dep01departments",
                        principalColumn: "dep01uin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emp01employees_des01designations_emp01des01uin",
                        column: x => x.emp01des01uin,
                        principalTable: "des01designations",
                        principalColumn: "des01uin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emp01employees_des02functional_titles_emp01des02uin",
                        column: x => x.emp01des02uin,
                        principalTable: "des02functional_titles",
                        principalColumn: "des02uin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emp01employees_lvl01employee_levels_emp01lvl01uin",
                        column: x => x.emp01lvl01uin,
                        principalTable: "lvl01employee_levels",
                        principalColumn: "lvl01uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fil01document_summaries",
                columns: table => new
                {
                    fil01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil01bra01uin = table.Column<int>(type: "int", nullable: false),
                    fil01dep01uin = table.Column<int>(type: "int", nullable: false),
                    fil01owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    file01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil01updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    file01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil01document_summaries", x => x.fil01uin);
                    table.ForeignKey(
                        name: "FK_fil01document_summaries_bra01branches_fil01bra01uin",
                        column: x => x.fil01bra01uin,
                        principalTable: "bra01branches",
                        principalColumn: "bra01uin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fil01document_summaries_dep01departments_fil01dep01uin",
                        column: x => x.fil01dep01uin,
                        principalTable: "dep01departments",
                        principalColumn: "dep01uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rol01roles",
                columns: table => new
                {
                    rol01uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol01emp01uin = table.Column<int>(type: "int", nullable: false),
                    rol01title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol01deleted = table.Column<bool>(type: "bit", nullable: false),
                    rol01created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rol01created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol01updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rol01updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol01roles", x => x.rol01uin);
                    table.ForeignKey(
                        name: "FK_rol01roles_emp01employees_rol01emp01uin",
                        column: x => x.rol01emp01uin,
                        principalTable: "emp01employees",
                        principalColumn: "emp01uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fil02Document_Details",
                columns: table => new
                {
                    fil02uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil02fil01uin = table.Column<int>(type: "int", nullable: false),
                    fil02doctitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil02doctype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil02expirydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil02isconfidential = table.Column<bool>(type: "bit", nullable: false),
                    fil02version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil02docphysicallocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil02created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    file02created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil02updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    file02updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil02Document_Details", x => x.fil02uin);
                    table.ForeignKey(
                        name: "FK_fil02Document_Details_fil01document_summaries_fil02fil01uin",
                        column: x => x.fil02fil01uin,
                        principalTable: "fil01document_summaries",
                        principalColumn: "fil01uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fil03attach_documents",
                columns: table => new
                {
                    fil03uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil03fil02uin = table.Column<int>(type: "int", nullable: false),
                    fil03name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil03category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil03size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file03path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil03created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil03created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil03updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    file03updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil03attach_documents", x => x.fil03uin);
                    table.ForeignKey(
                        name: "FK_fil03attach_documents_fil02Document_Details_fil03fil02uin",
                        column: x => x.fil03fil02uin,
                        principalTable: "fil02Document_Details",
                        principalColumn: "fil02uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fil04tags",
                columns: table => new
                {
                    fil04uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil04title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil04fil02uin = table.Column<int>(type: "int", nullable: true),
                    fil04created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil04created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil04updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil04updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil04tags", x => x.fil04uin);
                    table.ForeignKey(
                        name: "FK_fil04tags_fil02Document_Details_fil04fil02uin",
                        column: x => x.fil04fil02uin,
                        principalTable: "fil02Document_Details",
                        principalColumn: "fil02uin");
                });

            migrationBuilder.CreateTable(
                name: "fil05branch_permissions",
                columns: table => new
                {
                    fil05uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil05bra01uin = table.Column<int>(type: "int", nullable: false),
                    fil05fil03uin = table.Column<int>(type: "int", nullable: false),
                    fil05permission_type = table.Column<int>(type: "int", nullable: false),
                    fil05created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil05created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil05updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil05updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil05branch_permissions", x => x.fil05uin);
                    table.ForeignKey(
                        name: "FK_fil05branch_permissions_bra01branches_fil05bra01uin",
                        column: x => x.fil05bra01uin,
                        principalTable: "bra01branches",
                        principalColumn: "bra01uin",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_fil05branch_permissions_fil03attach_documents_fil05fil03uin",
                        column: x => x.fil05fil03uin,
                        principalTable: "fil03attach_documents",
                        principalColumn: "fil03uin",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "fil06department_permissions",
                columns: table => new
                {
                    fil06uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil06dep01uin = table.Column<int>(type: "int", nullable: false),
                    fil06fil03uin = table.Column<int>(type: "int", nullable: false),
                    fil06permission_type = table.Column<int>(type: "int", nullable: false),
                    fil06created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil06created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil06updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil06updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil06department_permissions", x => x.fil06uin);
                    table.ForeignKey(
                        name: "FK_fil06department_permissions_dep01departments_fil06dep01uin",
                        column: x => x.fil06dep01uin,
                        principalTable: "dep01departments",
                        principalColumn: "dep01uin",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_fil06department_permissions_fil03attach_documents_fil06fil03uin",
                        column: x => x.fil06fil03uin,
                        principalTable: "fil03attach_documents",
                        principalColumn: "fil03uin",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "fil07role_permissions",
                columns: table => new
                {
                    fil07uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil07rol01uin = table.Column<int>(type: "int", nullable: false),
                    fil07fil03uin = table.Column<int>(type: "int", nullable: false),
                    fil07permission_type = table.Column<int>(type: "int", nullable: false),
                    fil07created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil07created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil07updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil07updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil07role_permissions", x => x.fil07uin);
                    table.ForeignKey(
                        name: "FK_fil07role_permissions_fil03attach_documents_fil07fil03uin",
                        column: x => x.fil07fil03uin,
                        principalTable: "fil03attach_documents",
                        principalColumn: "fil03uin",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_fil07role_permissions_rol01roles_fil07rol01uin",
                        column: x => x.fil07rol01uin,
                        principalTable: "rol01roles",
                        principalColumn: "rol01uin",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "fil08User_Permissions",
                columns: table => new
                {
                    fil08uin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fil08dep01uin = table.Column<int>(type: "int", nullable: false),
                    fil08fil03uin = table.Column<int>(type: "int", nullable: false),
                    fil08permission_type = table.Column<int>(type: "int", nullable: false),
                    fil08created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fil08created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fil08updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fil08updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fil08User_Permissions", x => x.fil08uin);
                    table.ForeignKey(
                        name: "FK_fil08User_Permissions_emp01employees_fil08dep01uin",
                        column: x => x.fil08dep01uin,
                        principalTable: "emp01employees",
                        principalColumn: "emp01uin",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_fil08User_Permissions_fil03attach_documents_fil08fil03uin",
                        column: x => x.fil08fil03uin,
                        principalTable: "fil03attach_documents",
                        principalColumn: "fil03uin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bra01branches_bra01set05uin_muncipality",
                table: "bra01branches",
                column: "bra01set05uin_muncipality");

            migrationBuilder.CreateIndex(
                name: "IX_emp01employees_emp01bra01uin",
                table: "emp01employees",
                column: "emp01bra01uin");

            migrationBuilder.CreateIndex(
                name: "IX_emp01employees_emp01dep01uin",
                table: "emp01employees",
                column: "emp01dep01uin");

            migrationBuilder.CreateIndex(
                name: "IX_emp01employees_emp01des01uin",
                table: "emp01employees",
                column: "emp01des01uin");

            migrationBuilder.CreateIndex(
                name: "IX_emp01employees_emp01des02uin",
                table: "emp01employees",
                column: "emp01des02uin");

            migrationBuilder.CreateIndex(
                name: "IX_emp01employees_emp01lvl01uin",
                table: "emp01employees",
                column: "emp01lvl01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil01document_summaries_fil01bra01uin",
                table: "fil01document_summaries",
                column: "fil01bra01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil01document_summaries_fil01dep01uin",
                table: "fil01document_summaries",
                column: "fil01dep01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil02Document_Details_fil02fil01uin",
                table: "fil02Document_Details",
                column: "fil02fil01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil03attach_documents_fil03fil02uin",
                table: "fil03attach_documents",
                column: "fil03fil02uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil04tags_fil04fil02uin",
                table: "fil04tags",
                column: "fil04fil02uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil05branch_permissions_fil05bra01uin",
                table: "fil05branch_permissions",
                column: "fil05bra01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil05branch_permissions_fil05fil03uin",
                table: "fil05branch_permissions",
                column: "fil05fil03uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil06department_permissions_fil06dep01uin",
                table: "fil06department_permissions",
                column: "fil06dep01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil06department_permissions_fil06fil03uin",
                table: "fil06department_permissions",
                column: "fil06fil03uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil07role_permissions_fil07fil03uin",
                table: "fil07role_permissions",
                column: "fil07fil03uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil07role_permissions_fil07rol01uin",
                table: "fil07role_permissions",
                column: "fil07rol01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil08User_Permissions_fil08dep01uin",
                table: "fil08User_Permissions",
                column: "fil08dep01uin");

            migrationBuilder.CreateIndex(
                name: "IX_fil08User_Permissions_fil08fil03uin",
                table: "fil08User_Permissions",
                column: "fil08fil03uin");

            migrationBuilder.CreateIndex(
                name: "IX_rol01roles_rol01emp01uin",
                table: "rol01roles",
                column: "rol01emp01uin");

            migrationBuilder.CreateIndex(
                name: "IX_set04districts_set04set03uin",
                table: "set04districts",
                column: "set04set03uin");

            migrationBuilder.CreateIndex(
                name: "IX_set05municipalities_set05set04uin",
                table: "set05municipalities",
                column: "set05set04uin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fil04tags");

            migrationBuilder.DropTable(
                name: "fil05branch_permissions");

            migrationBuilder.DropTable(
                name: "fil06department_permissions");

            migrationBuilder.DropTable(
                name: "fil07role_permissions");

            migrationBuilder.DropTable(
                name: "fil08User_Permissions");

            migrationBuilder.DropTable(
                name: "rol01roles");

            migrationBuilder.DropTable(
                name: "fil03attach_documents");

            migrationBuilder.DropTable(
                name: "emp01employees");

            migrationBuilder.DropTable(
                name: "fil02Document_Details");

            migrationBuilder.DropTable(
                name: "des01designations");

            migrationBuilder.DropTable(
                name: "des02functional_titles");

            migrationBuilder.DropTable(
                name: "lvl01employee_levels");

            migrationBuilder.DropTable(
                name: "fil01document_summaries");

            migrationBuilder.DropTable(
                name: "bra01branches");

            migrationBuilder.DropTable(
                name: "dep01departments");

            migrationBuilder.DropTable(
                name: "set05municipalities");

            migrationBuilder.DropTable(
                name: "set04districts");

            migrationBuilder.DropTable(
                name: "set03provinces");
        }
    }
}
