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
            modelBuilder.Entity<Arbeitsrecht>().ToTable("arbeitsrecht");           
            modelBuilder.Entity<Cyberphysischesysteme>().ToTable("cyberphysischesysteme");     
            modelBuilder.Entity<Datenbanken>().ToTable("datenbanken");
            modelBuilder.Entity<Firewall>().ToTable("firewall");
            modelBuilder.Entity<Ipv4>().ToTable("ipv4");
            modelBuilder.Entity<Ipv6>().ToTable("ipv6");
            modelBuilder.Entity<ItSicherheit>().ToTable("it_sicherheit");
            modelBuilder.Entity<ItSysteme>().ToTable("it_systeme");
            modelBuilder.Entity<Kalkulationen>().ToTable("kalkulationen");
            modelBuilder.Entity<Linux>().ToTable("linux");
            modelBuilder.Entity<Marketing>().ToTable("marketing");
            modelBuilder.Entity<Organisationslehre>().ToTable("organisationslehre");
            modelBuilder.Entity<Programmieren>().ToTable("programmieren");
            modelBuilder.Entity<Projektmanagement>().ToTable("projektmanagement");
            modelBuilder.Entity<Rechtsformen>().ToTable("rechtsformen");
            modelBuilder.Entity<Routing>().ToTable("routing");
            modelBuilder.Entity<Tcpip>().ToTable("tcpip");
            modelBuilder.Entity<Wiso>().ToTable("wiso");
    }
}

}
