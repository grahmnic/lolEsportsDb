using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LolEsports.Models
{
    public partial class LoLEsportsDbContext : DbContext
    {
        public LoLEsportsDbContext()
        {
        }

        public LoLEsportsDbContext(DbContextOptions<LoLEsportsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Champion> Champion { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<CompetitorTeamRef> CompetitorTeamRef { get; set; }
        public virtual DbSet<FavoriteChampionRef> FavoriteChampionRef { get; set; }
        public virtual DbSet<FavoritePlayerRef> FavoritePlayerRef { get; set; }
        public virtual DbSet<FavoriteRegionRef> FavoriteRegionRef { get; set; }
        public virtual DbSet<FavoriteTeamRef> FavoriteTeamRef { get; set; }
        public virtual DbSet<FavoriteTournamentRef> FavoriteTournamentRef { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerMatchRef> PlayerMatchRef { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentRegionRef> TournamentRegionRef { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=lolesports.cwkpfiwou75m.us-east-2.rds.amazonaws.com; Database=LoLEsportsDb; User Id=admin; Password=cse305sucks;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ChampionId).HasColumnName("ChampionID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Champion)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.ChampionId)
                    .HasConstraintName("FK_Account_Champion");
            });

            modelBuilder.Entity<Champion>(entity =>
            {
                entity.Property(e => e.ChampionId).HasColumnName("ChampionID");

                entity.Property(e => e.ChampionImage).IsUnicode(false);

                entity.Property(e => e.ChampionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.CoachIgn)
                    .IsRequired()
                    .HasColumnName("CoachIGN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Coach__PersonID__5070F446");
            });

            modelBuilder.Entity<CompetitorTeamRef>(entity =>
            {
                entity.Property(e => e.CompetitorTeamRefId).HasColumnName("CompetitorTeamRefID");

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.CompetitorTeamRef)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competito__Coach__68487DD7");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.CompetitorTeamRef)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competito__Playe__6754599E");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CompetitorTeamRef)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competito__TeamI__693CA210");
            });

            modelBuilder.Entity<FavoriteChampionRef>(entity =>
            {
                entity.Property(e => e.FavoriteChampionRefId).HasColumnName("FavoriteChampionRefID");

                entity.Property(e => e.ChampionId).HasColumnName("ChampionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Champion)
                    .WithMany(p => p.FavoriteChampionRef)
                    .HasForeignKey(d => d.ChampionId)
                    .HasConstraintName("FK__FavoriteC__Champ__74AE54BC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteChampionRef)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FavoriteC__UserI__73BA3083");
            });

            modelBuilder.Entity<FavoritePlayerRef>(entity =>
            {
                entity.Property(e => e.FavoritePlayerRefId).HasColumnName("FavoritePlayerRefID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.FavoritePlayerRef)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__FavoriteP__Playe__787EE5A0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoritePlayerRef)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FavoriteP__UserI__778AC167");
            });

            modelBuilder.Entity<FavoriteRegionRef>(entity =>
            {
                entity.Property(e => e.FavoriteRegionRefId).HasColumnName("FavoriteRegionRefID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.FavoriteRegionRef)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__FavoriteR__Regio__03F0984C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteRegionRef)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FavoriteR__UserI__02FC7413");
            });

            modelBuilder.Entity<FavoriteTeamRef>(entity =>
            {
                entity.Property(e => e.FavoriteTeamRefId).HasColumnName("FavoriteTeamRefID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FavoriteTeamRef)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FavoriteT__TeamI__7C4F7684");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteTeamRef)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FavoriteT__UserI__7B5B524B");
            });

            modelBuilder.Entity<FavoriteTournamentRef>(entity =>
            {
                entity.Property(e => e.FavoriteTournamentRefId).HasColumnName("FavoriteTournamentRefID");

                entity.Property(e => e.ChampionId).HasColumnName("ChampionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Champion)
                    .WithMany(p => p.FavoriteTournamentRef)
                    .HasForeignKey(d => d.ChampionId)
                    .HasConstraintName("FK__FavoriteT__Champ__00200768");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteTournamentRef)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FavoriteT__UserI__7F2BE32F");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.DatePlayed).HasColumnType("date");

                entity.Property(e => e.IsFinals).HasColumnName("isFinals");

                entity.Property(e => e.IsQuarters).HasColumnName("isQuarters");

                entity.Property(e => e.IsSemis).HasColumnName("isSemis");

                entity.Property(e => e.LosingTeamId).HasColumnName("LosingTeamID");

                entity.Property(e => e.MatchLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerOfTheGameId).HasColumnName("PlayerOfTheGameID");

                entity.Property(e => e.TournamentId).HasColumnName("TournamentID");

                entity.Property(e => e.WinningTeamId).HasColumnName("WinningTeamID");

                entity.HasOne(d => d.LosingTeam)
                    .WithMany(p => p.MatchLosingTeam)
                    .HasForeignKey(d => d.LosingTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__LosingTea__619B8048");

                entity.HasOne(d => d.PlayerOfTheGame)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.PlayerOfTheGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__PlayerOfT__628FA481");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__Tournamen__5FB337D6");

                entity.HasOne(d => d.WinningTeam)
                    .WithMany(p => p.MatchWinningTeam)
                    .HasForeignKey(d => d.WinningTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__WinningTe__60A75C0F");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.FirstTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.SecondTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Thumbnail).IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Biography).IsUnicode(false);

                entity.Property(e => e.Hometown)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PlayerIgn)
                    .IsRequired()
                    .HasColumnName("PlayerIGN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerImage).IsUnicode(false);

                entity.Property(e => e.PlayerRole)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Quote)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Player__PersonID__4D94879B");
            });

            modelBuilder.Entity<PlayerMatchRef>(entity =>
            {
                entity.Property(e => e.PlayerMatchRefId).HasColumnName("PlayerMatchRefID");

                entity.Property(e => e.ChampionBannedId).HasColumnName("ChampionBannedID");

                entity.Property(e => e.ChampionPlayedId).HasColumnName("ChampionPlayedID");

                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.HasOne(d => d.ChampionBanned)
                    .WithMany(p => p.PlayerMatchRefChampionBanned)
                    .HasForeignKey(d => d.ChampionBannedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__Champ__6EF57B66");

                entity.HasOne(d => d.ChampionPlayed)
                    .WithMany(p => p.PlayerMatchRefChampionPlayed)
                    .HasForeignKey(d => d.ChampionPlayedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__Champ__6E01572D");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerMatchRef)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__Match__6D0D32F4");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerMatchRef)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__Playe__6C190EBB");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TeamLogo).IsUnicode(false);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeamPicture).IsUnicode(false);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Team__RegionID__59063A47");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.TournamentId).HasColumnName("TournamentID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Mvcid).HasColumnName("MVCID");

                entity.Property(e => e.Mvpid).HasColumnName("MVPID");

                entity.Property(e => e.PrizePool).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TournamentBanner).IsUnicode(false);

                entity.Property(e => e.TournamentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mvc)
                    .WithMany(p => p.Tournament)
                    .HasForeignKey(d => d.Mvcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tournamen__MVCID__5629CD9C");

                entity.HasOne(d => d.Mvp)
                    .WithMany(p => p.Tournament)
                    .HasForeignKey(d => d.Mvpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tournamen__MVPID__5535A963");
            });

            modelBuilder.Entity<TournamentRegionRef>(entity =>
            {
                entity.Property(e => e.TournamentRegionRefId).HasColumnName("TournamentRegionRefID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TournamentId).HasColumnName("TournamentID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.TournamentRegionRef)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tournamen__Regio__5CD6CB2B");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentRegionRef)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tournamen__Tourn__5BE2A6F2");
            });
        }
    }
}
