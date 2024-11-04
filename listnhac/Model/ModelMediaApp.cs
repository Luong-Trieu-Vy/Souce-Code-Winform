using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace listnhac.Model
{
    public partial class ModelMediaApp : DbContext
    {
        public ModelMediaApp()
            : base("name=ModelMediaApp1")
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.PlaylistSongs)
                .WithRequired(e => e.Playlist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Song>()
                .HasMany(e => e.PlaylistSongs)
                .WithRequired(e => e.Song)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Song>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Songs)
                .Map(m => m.ToTable("UserFavorites").MapLeftKey("SongID").MapRightKey("UserID"));
        }
    }
}
