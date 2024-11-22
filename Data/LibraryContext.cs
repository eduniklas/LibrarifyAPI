using LibrarifyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarifyAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) 
            :   base(options)
        {
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "frodo.baggins@shire.com",
                    Password = "Frodo1234",
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    UserName = "frodo_the_ringbearer",
                    DateJoined = new DateTime(2024, 11, 01),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 2,
                    Email = "aragorn@numenor.com",
                    Password = "Aragorn1234",
                    FirstName = "Aragorn",
                    LastName = "Elessar",
                    UserName = "king_elessar",
                    DateJoined = new DateTime(2024, 11, 02),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 3,
                    Email = "gandalf@wizardry.com",
                    Password = "Gandalf1234",
                    FirstName = "Gandalf",
                    LastName = "The Grey",
                    UserName = "gandalf_the_wise",
                    DateJoined = new DateTime(2024, 11, 03),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 4,
                    Email = "legolas@woodland.com",
                    Password = "Legolas1234",
                    FirstName = "Legolas",
                    LastName = "Greenleaf",
                    UserName = "elven_archer",
                    DateJoined = new DateTime(2024, 11, 04),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 5,
                    Email = "gimli@dwarvenrealm.com",
                    Password = "Gimli1234",
                    FirstName = "Gimli",
                    LastName = "Son of Glóin",
                    UserName = "gimli_the_dwarf",
                    DateJoined = new DateTime(2024, 11, 05),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 6,
                    Email = "samwise.gamgee@shire.com",
                    Password = "Samwise1234",
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    UserName = "loyal_sam",
                    DateJoined = new DateTime(2024, 11, 06),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 7,
                    Email = "merry.brandybuck@shire.com",
                    Password = "Merry1234",
                    FirstName = "Meriadoc",
                    LastName = "Brandybuck",
                    UserName = "merry_mischief",
                    DateJoined = new DateTime(2024, 11, 07),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 8,
                    Email = "pippin.took@shire.com",
                    Password = "Pippin1234",
                    FirstName = "Peregrin",
                    LastName = "Took",
                    UserName = "pippin_the_fool",
                    DateJoined = new DateTime(2024, 11, 08),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 9,
                    Email = "boromir@gondor.com",
                    Password = "Boromir1234",
                    FirstName = "Boromir",
                    LastName = "Son of Denethor",
                    UserName = "boromir_of_gondor",
                    DateJoined = new DateTime(2024, 11, 09),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 10,
                    Email = "saruman@isengard.com",
                    Password = "Saruman1234",
                    FirstName = "Saruman",
                    LastName = "The White",
                    UserName = "saruman_the_white",
                    DateJoined = new DateTime(2024, 11, 10),
                    IsAccountActive = false
                },
                new User
                {
                    Id = 11,
                    Email = "elrond@rivendell.com",
                    Password = "Elrond1234",
                    FirstName = "Elrond",
                    LastName = "Half-elven",
                    UserName = "lord_of_rivendell",
                    DateJoined = new DateTime(2024, 11, 11),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 12,
                    Email = "arwen@rivendell.com",
                    Password = "Arwen1234",
                    FirstName = "Arwen",
                    LastName = "Undómiel",
                    UserName = "evenstar",
                    DateJoined = new DateTime(2024, 11, 12),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 13,
                    Email = "galadriel@lorien.com",
                    Password = "Galadriel1234",
                    FirstName = "Galadriel",
                    LastName = "Lady of Light",
                    UserName = "lady_galadriel",
                    DateJoined = new DateTime(2024, 11, 13),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 14,
                    Email = "eowyn@rohan.com",
                    Password = "Eowyn1234",
                    FirstName = "Éowyn",
                    LastName = "Shieldmaiden",
                    UserName = "eowyn_shieldmaiden",
                    DateJoined = new DateTime(2024, 11, 14),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 15,
                    Email = "theoden@rohan.com",
                    Password = "Theoden1234",
                    FirstName = "Théoden",
                    LastName = "King of Rohan",
                    UserName = "king_theoden",
                    DateJoined = new DateTime(2024, 11, 15),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 16,
                    Email = "faramir@gondor.com",
                    Password = "Faramir1234",
                    FirstName = "Faramir",
                    LastName = "Son of Denethor",
                    UserName = "faramir_of_gondor",
                    DateJoined = new DateTime(2024, 11, 16),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 17,
                    Email = "gollum@stoor.com",
                    Password = "Gollum1234",
                    FirstName = "Gollum",
                    LastName = "Smeagol",
                    UserName = "my_precious",
                    DateJoined = new DateTime(2024, 11, 17),
                    IsAccountActive = false
                },
                new User
                {
                    Id = 18,
                    Email = "bilbo.baggins@shire.com",
                    Password = "Bilbo1234",
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    UserName = "burglar_bilbo",
                    DateJoined = new DateTime(2024, 11, 18),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 19,
                    Email = "treebeard@fangorn.com",
                    Password = "Treebeard1234",
                    FirstName = "Treebeard",
                    LastName = "The Ent",
                    UserName = "treebeard_ent",
                    DateJoined = new DateTime(2024, 11, 19),
                    IsAccountActive = true
                },
                new User
                {
                    Id = 20,
                    Email = "eomer@rohan.com",
                    Password = "Eomer1234",
                    FirstName = "Éomer",
                    LastName = "Marshal of the Mark",
                    UserName = "marshal_eomer",
                    DateJoined = new DateTime(2024, 11, 20),
                    IsAccountActive = true
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Fellowship of the Ring",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780261103573",
                    PublishedDate = new DateTime(1954, 07, 29),
                    Genre = "Fantasy",
                    Description = "The first part of J.R.R. Tolkien's epic adventure, The Lord of the Rings.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/fellowship-ring"
                },
                new Book
                {
                    Id = 2,
                    Title = "The Two Towers",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780261102361",
                    PublishedDate = new DateTime(1954, 11, 11),
                    Genre = "Fantasy",
                    Description = "The second part of J.R.R. Tolkien's epic adventure, The Lord of the Rings.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/two-towers"
                },
                new Book
                {
                    Id = 3,
                    Title = "The Return of the King",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780261102378",
                    PublishedDate = new DateTime(1955, 10, 20),
                    Genre = "Fantasy",
                    Description = "The final part of J.R.R. Tolkien's epic adventure, The Lord of the Rings.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/return-king"
                },
                new Book
                {
                    Id = 4,
                    Title = "Murder on the Orient Express",
                    Author = "Agatha Christie",
                    ISBN = "9780062693662",
                    PublishedDate = new DateTime(1934, 01, 01),
                    Genre = "Mystery",
                    Description = "Detective Hercule Poirot investigates a murder aboard a luxury train.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/orient-express"
                },
                new Book
                {
                    Id = 5,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    ISBN = "9780441013593",
                    PublishedDate = new DateTime(1965, 08, 01),
                    Genre = "Science Fiction",
                    Description = "A science fiction epic set on the desert planet Arrakis.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/dune"
                },
                new Book
                {
                    Id = 6,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    ISBN = "9780141199078",
                    PublishedDate = new DateTime(1813, 01, 28),
                    Genre = "Romance",
                    Description = "A classic romantic novel about love and society.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/pride-prejudice"
                },
                new Book
                {
                    Id = 7,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "9780061120084",
                    PublishedDate = new DateTime(1960, 07, 11),
                    Genre = "Fiction",
                    Description = "A story of racial injustice in the Deep South.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/mockingbird"
                },
                new Book
                {
                    Id = 8,
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "9780451524935",
                    PublishedDate = new DateTime(1949, 06, 08),
                    Genre = "Dystopian",
                    Description = "A novel depicting a totalitarian society under constant surveillance.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/1984"
                },
                new Book
                {
                    Id = 9,
                    Title = "Moby-Dick",
                    Author = "Herman Melville",
                    ISBN = "9781503280786",
                    PublishedDate = new DateTime(1851, 10, 18),
                    Genre = "Adventure",
                    Description = "A seafaring tale of obsession and revenge.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/moby-dick"
                },
                new Book
                {
                    Id = 10,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    ISBN = "9780743273565",
                    PublishedDate = new DateTime(1925, 04, 10),
                    Genre = "Classic",
                    Description = "A novel about the American Dream and the roaring twenties.",
                    IsAvailable = false,
                    DigitalUrl = "https://example.com/gatsby"
                },
                new Book
                {
                    Id = 11,
                    Title = "Dracula",
                    Author = "Bram Stoker",
                    ISBN = "9780486411095",
                    PublishedDate = new DateTime(1897, 05, 26),
                    Genre = "Horror",
                    Description = "The tale of Count Dracula's attempt to spread vampirism.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/dracula"
                },
                new Book
                {
                    Id = 12,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780547928227",
                    PublishedDate = new DateTime(1937, 09, 21),
                    Genre = "Fantasy",
                    Description = "A prequel to The Lord of the Rings, following Bilbo's journey.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/hobbit"
                },
                new Book
                {
                    Id = 13,
                    Title = "Brave New World",
                    Author = "Aldous Huxley",
                    ISBN = "9780060850524",
                    PublishedDate = new DateTime(1932, 08, 31),
                    Genre = "Dystopian",
                    Description = "A futuristic society where individuality is suppressed.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/brave-new-world"
                },
                new Book
                {
                    Id = 14,
                    Title = "War and Peace",
                    Author = "Leo Tolstoy",
                    ISBN = "9780307266934",
                    PublishedDate = new DateTime(1869, 01, 01),
                    Genre = "Historical Fiction",
                    Description = "An epic tale of Russian society during the Napoleonic Wars.",
                    IsAvailable = false,
                    DigitalUrl = "https://example.com/war-peace"
                },
                new Book
                {
                    Id = 15,
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    ISBN = "9780307474278",
                    PublishedDate = new DateTime(2003, 03, 18),
                    Genre = "Thriller",
                    Description = "A modern thriller involving secret societies and hidden messages.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/da-vinci-code"
                },
                new Book
                {
                    Id = 16,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    ISBN = "9780316769488",
                    PublishedDate = new DateTime(1951, 07, 16),
                    Genre = "Fiction",
                    Description = "A classic novel about teenage angst and rebellion.",
                    IsAvailable = false,
                    DigitalUrl = "https://example.com/catcher-rye"
                }
                ,new Book
                {
                    Id = 17,
                    Title = "The Adventures of Sherlock Holmes",
                    Author = "Arthur Conan Doyle",
                    ISBN = "9781508475316",
                    PublishedDate = new DateTime(1892, 10, 14),
                    Genre = "Mystery",
                    Description = "A collection of short stories featuring Sherlock Holmes and his detective work.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/sherlock-holmes"
                },
                new Book
                {
                    Id = 18,
                    Title = "The Road",
                    Author = "Cormac McCarthy",
                    ISBN = "9780307387899",
                    PublishedDate = new DateTime(2006, 09, 26),
                    Genre = "Post-Apocalyptic Fiction",
                    Description = "A haunting novel about a father and son's journey through a post-apocalyptic world.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/the-road",
                },
                new Book
                {
                    Id = 19,
                    Title = "Frankenstein",
                    Author = "Mary Shelley",
                    ISBN = "9780486282114",
                    PublishedDate = new DateTime(1818, 01, 01),
                    Genre = "Horror",
                    Description = "A novel exploring the consequences of scientific ambition and creation.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/frankenstein"
                },
                new Book
                {
                    Id = 20,
                    Title = "The Odyssey",
                    Author = "Homer",
                    ISBN = "9780140268867",
                    PublishedDate = new DateTime(700, 01, 01),
                    Genre = "Epic",
                    Description = "An ancient Greek epic following Odysseus's journey home after the Trojan War.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/odyssey"
                },
                new Book
                {
                    Id = 21,
                    Title = "Anna Karenina",
                    Author = "Leo Tolstoy",
                    ISBN = "9780143035008",
                    PublishedDate = new DateTime(1877, 01, 01),
                    Genre = "Literary Fiction",
                    Description = "A novel about a tragic love affair set against Russian high society.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/anna-karenina"
                },
                new Book
                {
                    Id = 22,
                    Title = "The Alchemist",
                    Author = "Paulo Coelho",
                    ISBN = "9780061122418",
                    PublishedDate = new DateTime(1988, 01, 01),
                    Genre = "Philosophical Fiction",
                    Description = "A story of a shepherd's journey to fulfill his personal legend.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/alchemist"
                },
                new Book
                {
                    Id = 23,
                    Title = "Don Quixote",
                    Author = "Miguel de Cervantes",
                    ISBN = "9780060934340",
                    PublishedDate = new DateTime(1605, 01, 16),
                    Genre = "Classic",
                    Description = "A comedic tale of a man who believes he's a knight and his adventures.",
                    IsAvailable = false,
                    DigitalUrl = "https://example.com/don-quixote"
                },
                new Book
                {
                    Id = 24,
                    Title = "Wuthering Heights",
                    Author = "Emily Brontë",
                    ISBN = "9780141439556",
                    PublishedDate = new DateTime(1847, 12, 01),
                    Genre = "Gothic Fiction",
                    Description = "A novel about intense and tragic love on the English moors.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/wuthering-heights"
                },
                new Book
                {
                    Id = 25,
                    Title = "The Count of Monte Cristo",
                    Author = "Alexandre Dumas",
                    ISBN = "9780140449266",
                    PublishedDate = new DateTime(1844, 01, 01),
                    Genre = "Adventure",
                    Description = "A tale of betrayal, imprisonment, and revenge.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/monte-cristo"
                },
                new Book
                {
                    Id = 26,
                    Title = "The Brothers Karamazov",
                    Author = "Fyodor Dostoevsky",
                    ISBN = "9780374528379",
                    PublishedDate = new DateTime(1880, 01, 01),
                    Genre = "Philosophical Fiction",
                    Description = "A Russian novel about morality, faith, and familial bonds.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/brothers-karamazov"
                },
                new Book
                {
                    Id = 27,
                    Title = "The Picture of Dorian Gray",
                    Author = "Oscar Wilde",
                    ISBN = "9780141439570",
                    PublishedDate = new DateTime(1890, 06, 20),
                    Genre = "Philosophical Fiction",
                    Description = "A novel about vanity, moral corruption, and the supernatural.",
                    IsAvailable = false,
                    DigitalUrl = "https://example.com/dorian-gray"
                },
                new Book
                {
                    Id = 28,
                    Title = "Les Misérables",
                    Author = "Victor Hugo",
                    ISBN = "9780451419439",
                    PublishedDate = new DateTime(1862, 01, 01),
                    Genre = "Historical Fiction",
                    Description = "A tale of social justice, love, and redemption in 19th century France.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/les-miserables"
                },
                new Book
                {
                    Id = 29,
                    Title = "A Tale of Two Cities",
                    Author = "Charles Dickens",
                    ISBN = "9780486406510",
                    PublishedDate = new DateTime(1859, 04, 30),
                    Genre = "Historical Fiction",
                    Description = "A novel set during the French Revolution, exploring themes of sacrifice and resurrection.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/tale-two-cities"
                },
                new Book
                {
                    Id = 30,
                    Title = "Ulysses",
                    Author = "James Joyce",
                    ISBN = "9780394703800",
                    PublishedDate = new DateTime(1922, 02, 02),
                    Genre = "Modernist",
                    Description = "A groundbreaking novel that captures a single day in the life of Leopold Bloom in Dublin.",
                    IsAvailable = false,
                    DigitalUrl = "https://example.com/ulysses"
                },
                new Book
                {
                    Id = 31,
                    Title = "The Divine Comedy",
                    Author = "Dante Alighieri",
                    ISBN = "9780142437223",
                    PublishedDate = new DateTime(1320, 01, 01),
                    Genre = "Epic Poetry",
                    Description = "An allegorical journey through Hell, Purgatory, and Paradise.",
                    IsAvailable = true,
                    DigitalUrl = "https://example.com/divine-comedy"
                }
            );
            modelBuilder.Entity<Loan>().HasData(
                new Loan
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    LoanDate = new DateTime(2024, 11, 01),
                    DueDate = new DateTime(2024, 11, 15),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 2,
                    LoanDate = new DateTime(2024, 11, 02),
                    DueDate = new DateTime(2024, 11, 16),
                    IsExtended = true
                },
                new Loan
                {
                    Id = 3,
                    UserId = 2,
                    BookId = 3,
                    LoanDate = new DateTime(2024, 11, 03),
                    DueDate = new DateTime(2024, 11, 17),
                    ReturnDate = new DateTime(2024, 11, 10),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 4,
                    UserId = 2,
                    BookId = 4,
                    LoanDate = new DateTime(2024, 11, 04),
                    DueDate = new DateTime(2024, 11, 18),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 5,
                    UserId = 3,
                    BookId = 5,
                    LoanDate = new DateTime(2024, 11, 05),
                    DueDate = new DateTime(2024, 11, 19),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 6,
                    UserId = 3,
                    BookId = 6,
                    LoanDate = new DateTime(2024, 11, 06),
                    DueDate = new DateTime(2024, 11, 20),
                    IsExtended = true
                },
                new Loan
                {
                    Id = 7,
                    UserId = 4,
                    BookId = 7,
                    LoanDate = new DateTime(2024, 11, 07),
                    DueDate = new DateTime(2024, 11, 21),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 8,
                    UserId = 5,
                    BookId = 8,
                    LoanDate = new DateTime(2024, 11, 08),
                    DueDate = new DateTime(2024, 11, 22),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 9,
                    UserId = 5,
                    BookId = 9,
                    LoanDate = new DateTime(2024, 11, 09),
                    DueDate = new DateTime(2024, 11, 23),
                    IsExtended = true
                },
                new Loan
                {
                    Id = 10,
                    UserId = 6,
                    BookId = 10,
                    LoanDate = new DateTime(2024, 11, 10),
                    DueDate = new DateTime(2024, 11, 24),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 11,
                    UserId = 7,
                    BookId = 1,
                    LoanDate = new DateTime(2024, 11, 11),
                    DueDate = new DateTime(2024, 11, 25),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 12,
                    UserId = 8,
                    BookId = 2,
                    LoanDate = new DateTime(2024, 11, 12),
                    DueDate = new DateTime(2024, 11, 26),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 13,
                    UserId = 9,
                    BookId = 3,
                    LoanDate = new DateTime(2024, 11, 13),
                    DueDate = new DateTime(2024, 11, 27),
                    IsExtended = true
                },
                new Loan
                {
                    Id = 14,
                    UserId = 10,
                    BookId = 4,
                    LoanDate = new DateTime(2024, 11, 14),
                    DueDate = new DateTime(2024, 11, 28),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 15,
                    UserId = 1,
                    BookId = 5,
                    LoanDate = new DateTime(2024, 11, 15),
                    DueDate = new DateTime(2024, 11, 29),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 16,
                    UserId = 2,
                    BookId = 6,
                    LoanDate = new DateTime(2024, 11, 16),
                    DueDate = new DateTime(2024, 11, 30),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 17,
                    UserId = 3,
                    BookId = 7,
                    LoanDate = new DateTime(2024, 11, 17),
                    DueDate = new DateTime(2024, 12, 01),
                    ReturnDate = new DateTime(2024, 11, 25),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 18,
                    UserId = 4,
                    BookId = 8,
                    LoanDate = new DateTime(2024, 11, 18),
                    DueDate = new DateTime(2024, 12, 02),
                    IsExtended = true
                },
                new Loan
                {
                    Id = 19,
                    UserId = 5,
                    BookId = 9,
                    LoanDate = new DateTime(2024, 11, 19),
                    DueDate = new DateTime(2024, 12, 03),
                    IsExtended = false
                },
                new Loan
                {
                    Id = 20,
                    UserId = 6,
                    BookId = 10,
                    LoanDate = new DateTime(2024, 11, 20),
                    DueDate = new DateTime(2024, 12, 04),
                    IsExtended = false
                }
            );
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    Rating = 5,
                    Comment = "An epic journey full of adventure and friendship!",
                    ReviewDate = new DateTime(2024, 11, 01)
                },
                new Review
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 2,
                    Rating = 4,
                    Comment = "A beautifully written tale, but a bit slow at times.",
                    ReviewDate = new DateTime(2024, 11, 02)
                },
                new Review
                {
                    Id = 3,
                    UserId = 2,
                    BookId = 3,
                    Rating = 5,
                    Comment = "A haunting and powerful story that stays with you.",
                    ReviewDate = new DateTime(2024, 11, 03)
                },
                new Review
                {
                    Id = 4,
                    UserId = 2,
                    BookId = 4,
                    Rating = 3,
                    Comment = "Interesting concept but lacked depth in character development.",
                    ReviewDate = new DateTime(2024, 11, 04)
                },
                new Review
                {
                    Id = 5,
                    UserId = 3,
                    BookId = 5,
                    Rating = 4,
                    Comment = "A thrilling ride from start to finish!",
                    ReviewDate = new DateTime(2024, 11, 05)
                },
                new Review
                {
                    Id = 6,
                    UserId = 3,
                    BookId = 6,
                    Rating = 5,
                    Comment = "A masterpiece of literature, highly recommend.",
                    ReviewDate = new DateTime(2024, 11, 06)
                },
                new Review
                {
                    Id = 7,
                    UserId = 4,
                    BookId = 7,
                    Rating = 2,
                    Comment = "I struggled to get through this one.",
                    ReviewDate = new DateTime(2024, 11, 07)
                },
                new Review
                {
                    Id = 8,
                    UserId = 5,
                    BookId = 8,
                    Rating = 4,
                    Comment = "Very engaging and well-written.",
                    ReviewDate = new DateTime(2024, 11, 08)
                },
                new Review
                {
                    Id = 9,
                    UserId = 5,
                    BookId = 9,
                    Rating = 5,
                    Comment = "An absolute must-read for everyone!",
                    ReviewDate = new DateTime(2024, 11, 09)
                },
                new Review
                {
                    Id = 10,
                    UserId = 6,
                    BookId = 10,
                    Rating = 3,
                    Comment = "Good, but I've read better.",
                    ReviewDate = new DateTime(2024, 11, 10)
                },
                new Review
                {
                    Id = 11,
                    UserId = 7,
                    BookId = 1,
                    Rating = 4,
                    Comment = "An adventure that was very well done!",
                    ReviewDate = new DateTime(2024, 11, 11)
                },
                new Review
                {
                    Id = 12,
                    UserId = 8,
                    BookId = 2,
                    Rating = 5,
                    Comment = "Absolutely loved this book!",
                    ReviewDate = new DateTime(2024, 11, 12)
                },
                new Review
                {
                    Id = 13,
                    UserId = 9,
                    BookId = 3,
                    Rating = 4,
                    Comment = "Powerful themes and great writing.",
                    ReviewDate = new DateTime(2024, 11, 13)
                },
                new Review
                {
                    Id = 14,
                    UserId = 10,
                    BookId = 4,
                    Rating = 3,
                    Comment = "Had potential, but it fell flat in some areas.",
                    ReviewDate = new DateTime(2024, 11, 14)
                },
                new Review
                {
                    Id = 15,
                    UserId = 1,
                    BookId = 5,
                    Rating = 4,
                    Comment = "Very enjoyable read!",
                    ReviewDate = new DateTime(2024, 11, 15)
                },
                new Review
                {
                    Id = 16,
                    UserId = 2,
                    BookId = 6,
                    Rating = 5,
                    Comment = "A work of art that deserves recognition.",
                    ReviewDate = new DateTime(2024, 11, 16)
                },
                new Review
                {
                    Id = 17,
                    UserId = 3,
                    BookId = 7,
                    Rating = 2,
                    Comment = "Did not meet my expectations.",
                    ReviewDate = new DateTime(2024, 11, 17)
                },
                new Review
                {
                    Id = 18,
                    UserId = 4,
                    BookId = 8,
                    Rating = 4,
                    Comment = "A solid read, very entertaining.",
                    ReviewDate = new DateTime(2024, 11, 18)
                },
                new Review
                {
                    Id = 19,
                    UserId = 5,
                    BookId = 9,
                    Rating = 5,
                    Comment = "Incredible story, I couldn't put it down!",
                    ReviewDate = new DateTime(2024, 11, 19)
                },
                new Review
                {
                    Id = 20,
                    UserId = 6,
                    BookId = 10,
                    Rating = 3,
                    Comment = "An average book, not my favorite.",
                    ReviewDate = new DateTime(2024, 11, 20)
                }
            );
        }
    }
}
