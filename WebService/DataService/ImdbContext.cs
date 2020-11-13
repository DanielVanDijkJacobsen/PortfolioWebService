using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebService.DataService.CustomTypes;
using WebService.DataService.DTO;

namespace WebService.DataService
{
    public class ImdbContext : DbContext
    {
        public DbSet<Titles> Titles { get; set; }
        public DbSet<TitleInfo> TitleInfo { get; set; }
        public DbSet<TitleAlias> TitleAlias { get; set; }
        public DbSet<Formats> Formats { get; set; }
        public DbSet<TitleFormats> TitleFormats { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<TitleGenres> TitleGenres { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<CastInfo> CastInfo { get; set; }
        public DbSet<Casts> Casts { get; set; }
        public DbSet<CastProfession> CastProfession { get; set; }
        public DbSet<CastKnownFor> CastKnownFor { get; set; }
        public DbSet<SpecialRoles> SpecialRoles { get; set; }
        public DbSet<Bookmarks> Bookmarks { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<FlaggedComment> FlaggedComments { get; set; }
        public DbSet<NameRating> NameRatings { get; set; }

        //Don't change this
        public string connectionString = "host=imdb-do-user-673066-0.b.db.ondigitalocean.com;port = 25060;database = defaultdb;username = doadmin;password = jvciw0phpg56ch5q;sslmode = Prefer;Trust Server Certificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BookmarkType>("bookmark_enum");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Titles
            modelBuilder.Entity<Titles>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titles");

                //Sets Primary Key
                entity.HasKey(x => x.TitleId).HasName("title_id");

                //Sets properties
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.PrimaryTitle).HasColumnName("primary_title");
                entity.Property(x => x.IsAdult).HasColumnName("is_adult");
                entity.Property(x => x.OriginalTitle).HasColumnName("original_title");
                entity.Property(x => x.Poster).HasColumnName("poster");
                entity.Property(x => x.StartYear).HasColumnName("start_year").ToString();
                entity.Property(x => x.EndYear).HasColumnName("end_year").ToString();
                entity.Property(x => x.RunetimeMins).HasColumnName("runtime_mins");
                entity.Property(x => x.TitleType).HasColumnName("title_type");
            });

            //TitleInfo
            modelBuilder.Entity<TitleInfo>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titleinfo");

                //Sets Primary Key
                entity.HasKey(x => x.TitleId).HasName("title_id");

                //Sets properties
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.Awards).HasColumnName("awards");
                entity.Property(x => x.Plot).HasColumnName("plot");

                //Sets Foreign Keys
                entity.HasOne(x => x.Titles).WithOne(d => d.TitleInfo)
                    .HasForeignKey<TitleInfo>(x => x.TitleId);
            });


            //TitleAlias
            modelBuilder.Entity<TitleAlias>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titlealias");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { title_id = x.TitleId, ordering = x.Ordering });

                //Sets properties
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.Title).HasColumnName("title");
                entity.Property(x => x.Region).HasColumnName("region");
                entity.Property(x => x.Language).HasColumnName("language");
                entity.Property(x => x.Attributes).HasColumnName("attributes");
                entity.Property(x => x.IsOriginalTitle).HasColumnName("is_original_title");

                //Sets Foreign Keys
                entity.HasOne(x => x.Titles).WithMany(d => d.TitleAlias)
                    .HasForeignKey(x => x.TitleId);
            });

            //Genres
            modelBuilder.Entity<Genres>(entity =>
            {
                //Points To Database Table
                entity.ToTable("genres");

                //Sets Primary Key
                entity.HasKey(x => x.GenreId).HasName("pk_genres");

                //Sets properties
                entity.Property(x => x.GenreId).HasColumnName("genre_id");
                entity.Property(x => x.Genre).HasColumnName("genre");
            });

            //TitleGenres
            modelBuilder.Entity<TitleGenres>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titlegenres");

                //Sets Primary Key
                entity.HasKey(x => x.TitleId).HasName("title_id");

                //Sets properties
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.GenreId).HasColumnName("genre_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.Title).WithMany(d => d.TitleGenre)
                    .HasForeignKey(x => x.TitleId);
                entity.HasOne(x => x.Genre).WithMany(d => d.TitleGenres)
                    .HasForeignKey(x => x.GenreId);
            });

            //Formats
            modelBuilder.Entity<Formats>(entity =>
            {
                //Points To Database Table
                entity.ToTable("formats");

                //Sets Primary Key
                entity.HasKey(x => x.FormatId).HasName("pk_formats");

                //Sets properties
                entity.Property(x => x.FormatId).HasColumnName("format_id");
                entity.Property(x => x.Format).HasColumnName("format");
            });

            //TitleFormats
            modelBuilder.Entity<TitleFormats>(entity =>
            {
                //Points To Database Table
                entity.ToTable("titleformats");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { title_id = x.TitleId, ordering = x.Ordering });

                //Sets properties
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.FormatId).HasColumnName("format_id");

                //Sets Foreign Keys
                //entity.HasOne(x => x.TitleAlias).WithMany(d => d.TitleFormat)
                //    .HasForeignKey(x => new { title_id = x.TitleId, ordering = x.Ordering });
                entity.HasOne(x => x.Format).WithMany(d => d.TitleFormats)
                    .HasForeignKey(x => x.FormatId);
            });

            //CastInfo
            modelBuilder.Entity<CastInfo>(entity =>
            {
                //Points To Database Table
                entity.ToTable("castinfo");

                //Sets Primary Key
                entity.HasKey(x => x.CastId).HasName("cast_id");

                //Sets properties
                entity.Property(x => x.CastId).HasColumnName("cast_id");
                entity.Property(x => x.Name).HasColumnName("name");
                entity.Property(x => x.BirthYear).HasColumnName("birth_year");
                entity.Property(x => x.DeathYear).HasColumnName("death_year");
            });

            //CastProfession
            modelBuilder.Entity<CastProfession>(entity =>
            {
                //Points To Database Table
                entity.ToTable("castprofession");

                //Sets Primary Key
                entity.HasKey(x => x.CastId).HasName("cast_id");

                //Sets properties
                entity.Property(x => x.CastId).HasColumnName("cast_id");
                entity.Property(x => x.Profession).HasColumnName("profession");

                //Sets Foreign Keys
                entity.HasOne(x => x.CastInfo).WithMany(d => d.CastProfession).HasForeignKey(x => x.CastId);
            });

            //CastKnownFor
            modelBuilder.Entity<CastKnownFor>(entity =>
            {
                //Points To Database Table
                entity.ToTable("castknownfor");

                //Sets Primary Key
                entity.HasKey(x => new {title_id = x.CastId, ordering = x.KnownFor});

                //Sets properties
                entity.Property(x => x.CastId).HasColumnName("cast_id");
                entity.Property(x => x.KnownFor).HasColumnName("known_for_title_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.CastInfo).WithMany(d => d.CastKnownFor).HasForeignKey(x => x.CastId);
            });

            //Casts
            modelBuilder.Entity<Casts>(entity =>
            {
                //Points To Database Table
                entity.ToTable("casts");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { title_id = x.TitleId, ordering = x.Ordering });

                //Sets properties
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.CastId).HasColumnName("cast_id");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.Category).HasColumnName("category");
                entity.Property(x => x.Job).HasColumnName("job");
                entity.Property(x => x.CharName).HasColumnName("char_name");

                //Sets Foreign Keys
                entity.HasOne(x => x.Title).WithMany(d => d.Casts).HasForeignKey(x => x.TitleId);
                entity.HasOne(x => x.CastInfo).WithMany(d => d.Casts).HasForeignKey(x => x.CastId);
            });

            //Episodes
            modelBuilder.Entity<Episodes>(entity =>
            {
                //Points To Database Table
                entity.ToTable("episodes");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { episode_id = x.EpisodeId, series_id = x.SeriesId });

                //Sets properties
                entity.Property(x => x.EpisodeId).HasColumnName("episode_id");
                entity.Property(x => x.SeriesId).HasColumnName("series_id");
                entity.Property(x => x.SeasonNum).HasColumnName("season_num");
                entity.Property(x => x.EpisodeNum).HasColumnName("episode_num");

                //Sets Foreign Keys
                entity.HasOne(x => x.Episode).WithMany(d => d.Episodes).HasForeignKey(x => x.EpisodeId);
                entity.HasOne(x => x.Series).WithMany(d => d.Seasons).HasForeignKey(x => x.SeriesId);
            });

            //Users
            modelBuilder.Entity<Users>(entity =>
            {
                //Points To Database Table
                entity.ToTable("users");

                //Sets Primary Key
                entity.HasKey(x => x.UserId).HasName("user_id");

                //Sets properties
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.Name).HasColumnName("user_name");
                entity.Property(x => x.DateOfBirth).HasColumnName("date_of_birth").HasColumnType("date");
                entity.Property(x => x.Age).HasColumnName("derived_age");
                entity.Property(x => x.Nickname).HasColumnName("nickname");
                entity.Property(x => x.AccountCreation).HasColumnName("account_creation");
                entity.Property(x => x.LastAccess).HasColumnName("last_access");
                entity.Property(x => x.Email).HasColumnName("email");
                entity.Property(x => x.Password).HasColumnName("user_password");
                entity.Property(x => x.Salt).HasColumnName("salt");
            });

            //Bookmarks
            modelBuilder.Entity<Bookmarks>(entity =>
            {
                //Points To Database Table
                entity.ToTable("bookmarks");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { user_id = x.UserId, type_id = x.TypeId });

                //Sets properties
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.BookmarkType).HasColumnName("bookmark_type");
                entity.Property(x => x.TypeId).HasColumnName("type_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.Bookmarks).HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Title).WithMany(d => d.Bookmarks).HasForeignKey(x => x.TypeId);
            });

            //SpecialRoles
            modelBuilder.Entity<SpecialRoles>(entity =>
            {
                //Points To Database Table
                entity.ToTable("specialroles");

                //Sets Primary Key
                entity.HasKey(x => x.UserId).HasName("user_id");

                //Sets properties
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.RoleType).HasColumnName("role_type");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.SpecialRoles).HasForeignKey(x => x.UserId);
            });

            //UserRating
            modelBuilder.Entity<UserRating>(entity =>
            {
                //Points To Database Table
                entity.ToTable("userrating");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { user_id = x.UserId, title_id = x.TitleId });

                //Sets properties
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.Score).HasColumnName("score");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.UserRating).HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Title).WithMany(d => d.UserRating).HasForeignKey(x => x.TitleId);
            });

            //SearchHistory
            modelBuilder.Entity<SearchHistory>(entity =>
            {
                //Points To Database Table
                entity.ToTable("searchhistory");

                //Sets Primary Key -> Composite
                entity.HasKey(x => new { x.UserId, x.Ordering });

                //Sets properties
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.Ordering).HasColumnName("ordering");
                entity.Property(x => x.SearchString).HasColumnName("query_string");
                entity.Property(x => x.SearchTime).HasColumnName("search_time");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.SearchHistories).HasForeignKey(x => x.UserId);
            });

            //Comments
            modelBuilder.Entity<Comments>(entity =>
            {
                //Points To Database Table
                entity.ToTable("comments");

                //Sets Primary Key
                entity.HasKey(x => x.CommentId).HasName("comment_id");

                //Sets properties
                entity.Property(x => x.CommentId).HasColumnName("comment_id");
                entity.Property(x => x.CommentTime).HasColumnName("comment_time").HasColumnType("date");
                entity.Property(x => x.UserId).HasColumnName("user_id");
                entity.Property(x => x.TitleId).HasColumnName("title_id");
                entity.Property(x => x.Comment).HasColumnName("comment_string");
                entity.Property(x => x.IsEdited).HasColumnName("edited");
                entity.Property(x => x.ParentCommentId).HasColumnName("parent_comment_id");

                //Sets Foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.Comments).HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Title).WithMany(d => d.Comments).HasForeignKey(x => x.TitleId);
                entity.HasOne(x => x.ParentComment).WithMany(d => d.ChildComments)
                    .HasForeignKey(x => x.ParentCommentId);
            });

            //FlaggedComments
            modelBuilder.Entity<FlaggedComment>(entity =>
            {

                //Points to Database Table
                entity.ToTable("flaggedcomments");

                //Sets Primary Key
                entity.HasKey(x => new { x.CommentId, UserId = x.FlaggingUser });

                //Sets properties
                entity.Property(x => x.CommentId).HasColumnName("comment_id");
                entity.Property(x => x.FlaggingUser).HasColumnName("flagging_user");

                //Sets foreign Keys
                entity.HasOne(x => x.User).WithMany(d => d.FlaggedComments).HasForeignKey(x => x.FlaggingUser);
                entity.HasOne(x => x.Comment).WithMany(d => d.FlaggedComments).HasForeignKey(x => x.CommentId);
            });

            //NameRatings
            modelBuilder.Entity<NameRating>(entity =>
            {
                //Points to Database Table
                entity.ToTable("nameratings");

                //Sets Primary key
                entity.HasKey(x => x.CastId).HasName("cast_id");

                //Sets Properties
                entity.Property(x => x.CastId).HasColumnName("cast_id");
                entity.Property(x => x.Score).HasColumnName("score");

                //Sets Foreign Keys
                entity.HasOne(x => x.CastInfo).WithMany(d => d.NameRating).HasForeignKey(x => x.CastId);

            });
        }
    }
}
