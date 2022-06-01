using Microsoft.EntityFrameworkCore;
using CbsStudents.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CbsStudents.Data
{
    public class CbsStudentsContext : IdentityDbContext
    {
        public CbsStudentsContext (DbContextOptions<CbsStudentsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
            this.SeedUsers(builder);
            this.SeedPosts(builder);
            this.SeedComments(builder);
            this.SeedEvents(builder);
            this.SeedParticipants(builder);
        } 

        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Participant> Participant { get; set; }

        private void SeedUsers(ModelBuilder builder) {

            var user1 = new IdentityUser{
                Id = "1",
                Email = "rasm05n1@stud.kea.dk",
                NormalizedEmail = "RASM05N1@STUD.KEA.DK",
                EmailConfirmed = true,
                UserName = "rasm05n1@stud.kea.dk",
                NormalizedUserName = "RASM05N1@STUD.KEA.DK"
            };

            var user2 = new IdentityUser{
                Id = "2",
                Email = "test@kea.dk",
                NormalizedEmail = "TEST@KEA.DK",
                EmailConfirmed = true,
                UserName = "test@kea.dk",
                NormalizedUserName = "TEST@KEA.DK"
            };

            PasswordHasher<IdentityUser> passHash = new PasswordHasher<IdentityUser>();

            user1.PasswordHash = passHash.HashPassword(user1, "aA123456!");
            user2.PasswordHash = passHash.HashPassword(user2, "aA123456!");

            builder.Entity<IdentityUser>().HasData(user1, user2);
        }

        private void SeedPosts(ModelBuilder builder) {
            builder.Entity<Post>().HasData(
                new Post() {
                    PostId=1,
                    Created=DateTime.Now,
                    Text="This is the seeded post 1",
                    Title="Post number 1",
                    Status = Models.PostStatus.DRAFT,
                    UserId="1"
                }, 
                new Post() {
                    PostId=2,
                    Created=DateTime.Now,
                    Text="This is the seeded post 2",
                    Title="Post number 2",
                    Status = Models.PostStatus.DRAFT,
                    UserId="1"
                }, 
                new Post() {
                    PostId=3,
                    Created=DateTime.Now,
                    Text="This is the seeded post 3",
                    Title="Post number 3",
                    Status = Models.PostStatus.DRAFT,
                    UserId="2"
                }
            ); 
        }

        private void SeedComments(ModelBuilder builder) {
            builder.Entity<Comment>().HasData(
                new Comment() {
                    CommentId=1,
                    Text="First POGGERS",
                    Created=DateTime.Now,
                    PostId=1,
                    UserId="1"
                },
                new Comment() {
                    CommentId=2,
                    Text="Second Sadge",
                    Created=DateTime.Now,
                    PostId=1,
                    UserId="2"
                },
                new Comment() {
                    CommentId=3,
                    Text="First GigaChad",
                    Created=DateTime.Now,
                    PostId=2,
                    UserId="1"
                },
                new Comment() {
                    CommentId=4,
                    Text="So many comments",
                    Created=DateTime.Now,
                    PostId=1,
                    UserId="1"
                }
            );
        }

        private void SeedEvents(ModelBuilder builder) {
            builder.Entity<Event>().HasData(
                new Event() {
                    EventId=1,
                    Title="Grillfest",
                    Description="Ses på grillen, det bliver super fedt",
                    StartTime= new DateTime(2022, 7, 5, 16, 0, 0),
                    EndTime= new DateTime(2022, 7, 5, 20, 0, 0),
                    Location="Grillen",
                    UserId="1"
                },
                new Event() {
                    EventId=2,
                    Title="Brætspilshygge",
                    Description="Vi spiller brætspil",
                    StartTime= new DateTime(2022, 6, 18, 10, 0, 0),
                    EndTime= new DateTime(2022, 6, 18, 16, 0, 0),
                    Location="Brætspilscafeen",
                    UserId="2"
                },
                new Event() {
                    EventId=3,
                    Title="Studieaften",
                    Description="Lad os studere ASP.NET sammen",
                    StartTime= new DateTime(2022, 5, 30, 16, 0, 0),
                    EndTime= new DateTime(2022, 5, 30, 22, 0, 0),
                    Location="Hjemme hos mig",
                    UserId="1"
                },
                new Event() {
                    EventId=4,
                    Title="Guldbar fest",
                    Description="Der skal drikkes bajer",
                    StartTime= new DateTime(2022, 5, 27, 14, 0, 0),
                    Location="Guldbar",
                    UserId="2"
                }
            );
        }

        private void SeedParticipants(ModelBuilder builder) {
            builder.Entity<Participant>().HasData(
                new Participant() {
                    ParticipantId=1,
                    Name="Rasmus Roth",
                    EventId=1
                },
                new Participant() {
                    ParticipantId=2,
                    Name="Janus Pedersen",
                    EventId=1
                },
                new Participant() {
                    ParticipantId=3,
                    Name="Barack Obama",
                    EventId=1
                },
                new Participant() {
                    ParticipantId=4,
                    Name="Rasmus Roth",
                    EventId=2
                },
                new Participant() {
                    ParticipantId=5,
                    Name="Janus Pedersen",
                    EventId=2
                },
                new Participant() {
                    ParticipantId=6,
                    Name="Rasmus Roth",
                    EventId=3
                },
                new Participant() {
                    ParticipantId=7,
                    Name="Rasmus Roth",
                    EventId=4
                }
            );
        }
    }
}