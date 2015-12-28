using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace AzmanovRC1Update1.Migrations
{
    public partial class AzmanovRC1Update1_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autobiography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobiography", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ContactEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEntry", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    CultureCode = table.Column<string>(nullable: true),
                    Default = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    LongDisplay = table.Column<string>(nullable: true),
                    ShortDisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "MediaEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEvent", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    LongDisplay = table.Column<string>(nullable: true),
                    ShortDisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AutobiographyDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutobiographyId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutobiographyDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutobiographyDetail_Autobiography_AutobiographyId",
                        column: x => x.AutobiographyId,
                        principalTable: "Autobiography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "EventDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetail_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "EventPicture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPicture_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "GalleryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GalleryId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryDetail_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "LanguageDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    InLanguageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: true),
                    LongDisplay = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ShortDisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageDetail_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "MediaEventDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    MediaEventId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEventDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaEventDetail_MediaEvent_MediaEventId",
                        column: x => x.MediaEventId,
                        principalTable: "MediaEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: true),
                    Attribute = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    LongDisplay = table.Column<string>(nullable: true),
                    MenuId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ParentMenuItemId = table.Column<int>(nullable: false),
                    ShortDisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "EventPictureDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventPictureId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPictureDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPictureDetail_EventPicture_EventPictureId",
                        column: x => x.EventPictureId,
                        principalTable: "EventPicture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "MenuItemDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    InLanguageId = table.Column<int>(nullable: false),
                    LongDisplay = table.Column<string>(nullable: true),
                    MenuItemId = table.Column<int>(nullable: true),
                    ShortDisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemDetail_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AutobiographyDetail");
            migrationBuilder.DropTable("ContactEntry");
            migrationBuilder.DropTable("EventDetail");
            migrationBuilder.DropTable("EventPictureDetail");
            migrationBuilder.DropTable("GalleryDetail");
            migrationBuilder.DropTable("LanguageDetail");
            migrationBuilder.DropTable("MediaEventDetail");
            migrationBuilder.DropTable("MenuItemDetail");
            migrationBuilder.DropTable("Autobiography");
            migrationBuilder.DropTable("EventPicture");
            migrationBuilder.DropTable("Gallery");
            migrationBuilder.DropTable("Language");
            migrationBuilder.DropTable("MediaEvent");
            migrationBuilder.DropTable("MenuItem");
            migrationBuilder.DropTable("Event");
            migrationBuilder.DropTable("Menu");
        }
    }
}
