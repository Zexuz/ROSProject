namespace ROS.Domain.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityDataModel : DbContext
    {
        public EntityDataModel()
            : base("name=EntityDataModel")
        {
        }

        public virtual DbSet<AddressContact> AddressContacts { get; set; }
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<ClubAdmin> ClubAdmins { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<RaceEntry> RaceEntries { get; set; }
        public virtual DbSet<RaceEvent> RaceEvents { get; set; }
        public virtual DbSet<Regatta> Regattas { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<SocialEntry> SocialEntries { get; set; }
        public virtual DbSet<SocialEvent> SocialEvents { get; set; }
        public virtual DbSet<SysAdmin> SysAdmins { get; set; }
        public virtual DbSet<TeamBoatResult> TeamBoatResults { get; set; }
        public virtual DbSet<TeamCrewRegisteredUser> TeamCrewRegisteredUsers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressContact>()
                .Property(e => e.NextOfKin)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .Property(e => e.BoxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .Property(e => e.StreetAddress)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<AddressContact>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.AddressContact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boat>()
                .Property(e => e.SailNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Boat>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Boat>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Boat>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Boat>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Boat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boat>()
                .HasMany(e => e.TeamBoatResults)
                .WithRequired(e => e.Boat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.HomePage)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubAdmins)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Memberships)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.HostingClubId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactPerson>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ContactPerson>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ContactPerson>()
                .HasMany(e => e.Clubs)
                .WithOptional(e => e.ContactPerson)
                .HasForeignKey(e => e.ContactPersonsId);

            modelBuilder.Entity<ContactPerson>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.ContactPerson)
                .HasForeignKey(e => e.ContactPersonsId);

            modelBuilder.Entity<ContactPerson>()
                .HasMany(e => e.Regattas)
                .WithOptional(e => e.ContactPerson)
                .HasForeignKey(e => e.ContactPersonsId);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.RaceEvents)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialEvents)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvent>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<RaceEvent>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<RaceEvent>()
                .HasMany(e => e.RaceEntries)
                .WithRequired(e => e.RaceEvent)
                .HasForeignKey(e => e.RaceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvent>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.RaceEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Regatta>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.SocialEntries)
                .WithRequired(e => e.RegisteredUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.TeamCrewRegisteredUsers)
                .WithRequired(e => e.RegisteredUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SocialEvent>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SocialEvent>()
                .HasMany(e => e.SocialEntries)
                .WithRequired(e => e.SocialEvent)
                .HasForeignKey(e => e.SocialEventsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeamBoatResult>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.TeamBoatResult)
                .HasForeignKey(e => e.TeamBoatResultsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.RaceEntries)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.TeamBoatResults)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.TeamCrewRegisteredUsers)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ClubAdmins)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContactPersons)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SkipperId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Memberships)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SysAdmins)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
