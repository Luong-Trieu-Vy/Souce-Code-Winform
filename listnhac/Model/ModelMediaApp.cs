using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace listnhac.Model
{
    public partial class ModelMediaApp : DbContext
    {
        public ModelMediaApp()
            : base("name=ModelMediaApp")
        {
        }

        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public virtual DbSet<PlaylistVideo> PlaylistVideos { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<UserSong> UserSongs { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.PlaylistSongs)
                .WithRequired(e => e.Playlist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.PlaylistVideos)
                .WithRequired(e => e.Playlist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Song>()
                .HasMany(e => e.PlaylistSongs)
                .WithRequired(e => e.Song)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSong>() 
                .HasKey(us => new { us.UserId, us.SongId }); 

            modelBuilder.Entity<Video>()
                .HasMany(e => e.PlaylistVideos)
                .WithRequired(e => e.Video)
                .WillCascadeOnDelete(false);
        }
    }
}
