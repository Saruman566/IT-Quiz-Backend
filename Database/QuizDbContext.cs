using Microsoft.EntityFrameworkCore;
using GetQuestions.Models;


namespace GetQuestions.Data
{
    public class QuizDbContext : DbContext
{
    public DbSet<Arbeitsrecht> Arbeitsrecht { get; set; }
    public DbSet<Cyberphysischesysteme> Cyberphysischesysteme { get; set; }
    public DbSet<Datenbanken> Datenbanken { get; set; }
    public DbSet<Firewall> Firewall { get; set; }
    public DbSet<Ipv4> Ipv4 { get; set; }
    public DbSet<Ipv6> Ipv6 { get; set; }
    public DbSet<ItSicherheit> ItSicherheit { get; set; }
    public DbSet<ItSysteme> ItSysteme { get; set; }
    public DbSet<Kalkulationen> Kalkulationen { get; set; }
    public DbSet<Linux> Linux { get; set; }
    public DbSet<Marketing> Marketing { get; set; }
    public DbSet<Organisationslehre> Organisationslehre { get; set; }
    public DbSet<Programmieren> Programmieren { get; set; }
    public DbSet<Projektmanagement> Projektmanagement { get; set; }
    public DbSet<Rechtsformen> Rechtsformen { get; set; }
    public DbSet<Routing> Routing { get; set; }
    public DbSet<Tcpip> Tcpip { get; set; }
    public DbSet<Wiso> Wiso { get; set; }

    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arbeitsrecht>().ToTable("arbeitsrecht").HasNoKey();
        modelBuilder.Entity<Cyberphysischesysteme>().ToTable("cyberphysischesysteme").HasNoKey();
        modelBuilder.Entity<Datenbanken>().ToTable("datenbanken").HasNoKey();
        modelBuilder.Entity<Firewall>().ToTable("firewall").HasNoKey();
        modelBuilder.Entity<Ipv4>().ToTable("ipv4").HasNoKey();
        modelBuilder.Entity<Ipv6>().ToTable("ipv6").HasNoKey();
        modelBuilder.Entity<ItSicherheit>().ToTable("it_sicherheit").HasNoKey();
        modelBuilder.Entity<ItSysteme>().ToTable("it_systeme").HasNoKey();
        modelBuilder.Entity<Kalkulationen>().ToTable("kalkulationen").HasNoKey();
        modelBuilder.Entity<Linux>().ToTable("linux").HasNoKey();
        modelBuilder.Entity<Marketing>().ToTable("marketing").HasNoKey();
        modelBuilder.Entity<Organisationslehre>().ToTable("organisationslehre").HasNoKey();
        modelBuilder.Entity<Programmieren>().ToTable("programmieren").HasNoKey();
        modelBuilder.Entity<Projektmanagement>().ToTable("projektmanagement").HasNoKey();
        modelBuilder.Entity<Rechtsformen>().ToTable("rechtsformen").HasNoKey();
        modelBuilder.Entity<Routing>().ToTable("routing").HasNoKey();
        modelBuilder.Entity<Tcpip>().ToTable("tcpip").HasNoKey();
        modelBuilder.Entity<Wiso>().ToTable("wiso").HasNoKey();
    }
}

}
