using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibrarifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class modelAndSeeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DigitalUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccountActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsExtended = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fee_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fee_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "DigitalUrl", "Genre", "ISBN", "ImageUrl", "IsAvailable", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", "The first part of J.R.R. Tolkien's epic adventure, The Lord of the Rings.", "https://example.com/fellowship-ring", "Fantasy", "9780261103573", null, true, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Fellowship of the Ring" },
                    { 2, "J.R.R. Tolkien", "The second part of J.R.R. Tolkien's epic adventure, The Lord of the Rings.", "https://example.com/two-towers", "Fantasy", "9780261102361", null, true, new DateTime(1954, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Two Towers" },
                    { 3, "J.R.R. Tolkien", "The final part of J.R.R. Tolkien's epic adventure, The Lord of the Rings.", "https://example.com/return-king", "Fantasy", "9780261102378", null, true, new DateTime(1955, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Return of the King" },
                    { 4, "Agatha Christie", "Detective Hercule Poirot investigates a murder aboard a luxury train.", "https://example.com/orient-express", "Mystery", "9780062693662", null, true, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murder on the Orient Express" },
                    { 5, "Frank Herbert", "A science fiction epic set on the desert planet Arrakis.", "https://example.com/dune", "Science Fiction", "9780441013593", null, true, new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune" },
                    { 6, "Jane Austen", "A classic romantic novel about love and society.", "https://example.com/pride-prejudice", "Romance", "9780141199078", null, true, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { 7, "Harper Lee", "A story of racial injustice in the Deep South.", "https://example.com/mockingbird", "Fiction", "9780061120084", null, true, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird" },
                    { 8, "George Orwell", "A novel depicting a totalitarian society under constant surveillance.", "https://example.com/1984", "Dystopian", "9780451524935", null, true, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { 9, "Herman Melville", "A seafaring tale of obsession and revenge.", "https://example.com/moby-dick", "Adventure", "9781503280786", null, true, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moby-Dick" },
                    { 10, "F. Scott Fitzgerald", "A novel about the American Dream and the roaring twenties.", "https://example.com/gatsby", "Classic", "9780743273565", null, false, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 11, "Bram Stoker", "The tale of Count Dracula's attempt to spread vampirism.", "https://example.com/dracula", "Horror", "9780486411095", null, true, new DateTime(1897, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dracula" },
                    { 12, "J.R.R. Tolkien", "A prequel to The Lord of the Rings, following Bilbo's journey.", "https://example.com/hobbit", "Fantasy", "9780547928227", null, true, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" },
                    { 13, "Aldous Huxley", "A futuristic society where individuality is suppressed.", "https://example.com/brave-new-world", "Dystopian", "9780060850524", null, true, new DateTime(1932, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brave New World" },
                    { 14, "Leo Tolstoy", "An epic tale of Russian society during the Napoleonic Wars.", "https://example.com/war-peace", "Historical Fiction", "9780307266934", null, false, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "War and Peace" },
                    { 15, "Dan Brown", "A modern thriller involving secret societies and hidden messages.", "https://example.com/da-vinci-code", "Thriller", "9780307474278", null, true, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Da Vinci Code" },
                    { 16, "J.D. Salinger", "A classic novel about teenage angst and rebellion.", "https://example.com/catcher-rye", "Fiction", "9780316769488", null, false, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye" },
                    { 17, "Arthur Conan Doyle", "A collection of short stories featuring Sherlock Holmes and his detective work.", "https://example.com/sherlock-holmes", "Mystery", "9781508475316", null, true, new DateTime(1892, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Adventures of Sherlock Holmes" },
                    { 18, "Cormac McCarthy", "A haunting novel about a father and son's journey through a post-apocalyptic world.", "https://example.com/the-road", "Post-Apocalyptic Fiction", "9780307387899", null, true, new DateTime(2006, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Road" },
                    { 19, "Mary Shelley", "A novel exploring the consequences of scientific ambition and creation.", "https://example.com/frankenstein", "Horror", "9780486282114", null, true, new DateTime(1818, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frankenstein" },
                    { 20, "Homer", "An ancient Greek epic following Odysseus's journey home after the Trojan War.", "https://example.com/odyssey", "Epic", "9780140268867", null, true, new DateTime(700, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Odyssey" },
                    { 21, "Leo Tolstoy", "A novel about a tragic love affair set against Russian high society.", "https://example.com/anna-karenina", "Literary Fiction", "9780143035008", null, true, new DateTime(1877, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Karenina" },
                    { 22, "Paulo Coelho", "A story of a shepherd's journey to fulfill his personal legend.", "https://example.com/alchemist", "Philosophical Fiction", "9780061122418", null, true, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Alchemist" },
                    { 23, "Miguel de Cervantes", "A comedic tale of a man who believes he's a knight and his adventures.", "https://example.com/don-quixote", "Classic", "9780060934340", null, false, new DateTime(1605, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Quixote" },
                    { 24, "Emily Brontë", "A novel about intense and tragic love on the English moors.", "https://example.com/wuthering-heights", "Gothic Fiction", "9780141439556", null, true, new DateTime(1847, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wuthering Heights" },
                    { 25, "Alexandre Dumas", "A tale of betrayal, imprisonment, and revenge.", "https://example.com/monte-cristo", "Adventure", "9780140449266", null, true, new DateTime(1844, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Count of Monte Cristo" },
                    { 26, "Fyodor Dostoevsky", "A Russian novel about morality, faith, and familial bonds.", "https://example.com/brothers-karamazov", "Philosophical Fiction", "9780374528379", null, true, new DateTime(1880, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Brothers Karamazov" },
                    { 27, "Oscar Wilde", "A novel about vanity, moral corruption, and the supernatural.", "https://example.com/dorian-gray", "Philosophical Fiction", "9780141439570", null, false, new DateTime(1890, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Picture of Dorian Gray" },
                    { 28, "Victor Hugo", "A tale of social justice, love, and redemption in 19th century France.", "https://example.com/les-miserables", "Historical Fiction", "9780451419439", null, true, new DateTime(1862, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les Misérables" },
                    { 29, "Charles Dickens", "A novel set during the French Revolution, exploring themes of sacrifice and resurrection.", "https://example.com/tale-two-cities", "Historical Fiction", "9780486406510", null, true, new DateTime(1859, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Tale of Two Cities" },
                    { 30, "James Joyce", "A groundbreaking novel that captures a single day in the life of Leopold Bloom in Dublin.", "https://example.com/ulysses", "Modernist", "9780394703800", null, false, new DateTime(1922, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ulysses" },
                    { 31, "Dante Alighieri", "An allegorical journey through Hell, Purgatory, and Paradise.", "https://example.com/divine-comedy", "Epic Poetry", "9780142437223", null, true, new DateTime(1320, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Divine Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateJoined", "Email", "FirstName", "IsAccountActive", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "frodo.baggins@shire.com", "Frodo", true, "Baggins", "Frodo1234", "frodo_the_ringbearer" },
                    { 2, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aragorn@numenor.com", "Aragorn", true, "Elessar", "Aragorn1234", "king_elessar" },
                    { 3, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "gandalf@wizardry.com", "Gandalf", true, "The Grey", "Gandalf1234", "gandalf_the_wise" },
                    { 4, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "legolas@woodland.com", "Legolas", true, "Greenleaf", "Legolas1234", "elven_archer" },
                    { 5, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "gimli@dwarvenrealm.com", "Gimli", true, "Son of Glóin", "Gimli1234", "gimli_the_dwarf" },
                    { 6, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "samwise.gamgee@shire.com", "Samwise", true, "Gamgee", "Samwise1234", "loyal_sam" },
                    { 7, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "merry.brandybuck@shire.com", "Meriadoc", true, "Brandybuck", "Merry1234", "merry_mischief" },
                    { 8, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pippin.took@shire.com", "Peregrin", true, "Took", "Pippin1234", "pippin_the_fool" },
                    { 9, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "boromir@gondor.com", "Boromir", true, "Son of Denethor", "Boromir1234", "boromir_of_gondor" },
                    { 10, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "saruman@isengard.com", "Saruman", false, "The White", "Saruman1234", "saruman_the_white" },
                    { 11, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "elrond@rivendell.com", "Elrond", true, "Half-elven", "Elrond1234", "lord_of_rivendell" },
                    { 12, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "arwen@rivendell.com", "Arwen", true, "Undómiel", "Arwen1234", "evenstar" },
                    { 13, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "galadriel@lorien.com", "Galadriel", true, "Lady of Light", "Galadriel1234", "lady_galadriel" },
                    { 14, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "eowyn@rohan.com", "Éowyn", true, "Shieldmaiden", "Eowyn1234", "eowyn_shieldmaiden" },
                    { 15, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "theoden@rohan.com", "Théoden", true, "King of Rohan", "Theoden1234", "king_theoden" },
                    { 16, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "faramir@gondor.com", "Faramir", true, "Son of Denethor", "Faramir1234", "faramir_of_gondor" },
                    { 17, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gollum@stoor.com", "Gollum", false, "Smeagol", "Gollum1234", "my_precious" },
                    { 18, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "bilbo.baggins@shire.com", "Bilbo", true, "Baggins", "Bilbo1234", "burglar_bilbo" },
                    { 19, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "treebeard@fangorn.com", "Treebeard", true, "The Ent", "Treebeard1234", "treebeard_ent" },
                    { 20, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "eomer@rohan.com", "Éomer", true, "Marshal of the Mark", "Eomer1234", "marshal_eomer" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookId", "DueDate", "IsExtended", "LoanDate", "ReturnDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, 2, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 3, 3, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 5, 5, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 6, 6, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 7, 7, new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 },
                    { 8, 8, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 },
                    { 9, 9, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 },
                    { 10, 10, new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6 },
                    { 11, 1, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7 },
                    { 12, 2, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8 },
                    { 13, 3, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9 },
                    { 14, 4, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10 },
                    { 15, 5, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 16, 6, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 17, 7, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, 8, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 },
                    { 19, 9, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 },
                    { 20, 10, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "Rating", "ReviewDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "An epic journey full of adventure and friendship!", 5, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, "A beautifully written tale, but a bit slow at times.", 4, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, "A haunting and powerful story that stays with you.", 5, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 4, "Interesting concept but lacked depth in character development.", 3, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 5, "A thrilling ride from start to finish!", 4, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 6, "A masterpiece of literature, highly recommend.", 5, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 7, "I struggled to get through this one.", 2, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 8, "Very engaging and well-written.", 4, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 9, 9, "An absolute must-read for everyone!", 5, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 10, 10, "Good, but I've read better.", 3, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 11, 1, "An adventure that was very well done!", 4, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 12, 2, "Absolutely loved this book!", 5, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 13, 3, "Powerful themes and great writing.", 4, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 14, 4, "Had potential, but it fell flat in some areas.", 3, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 15, 5, "Very enjoyable read!", 4, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 6, "A work of art that deserves recognition.", 5, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 7, "Did not meet my expectations.", 2, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, 8, "A solid read, very entertaining.", 4, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 19, 9, "Incredible story, I couldn't put it down!", 5, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 20, 10, "An average book, not my favorite.", 3, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fee_LoanId",
                table: "Fee",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_UserId",
                table: "Fee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
