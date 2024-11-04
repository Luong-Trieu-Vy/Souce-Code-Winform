namespace listnhac.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Song()
        {
            PlaylistSongs = new HashSet<PlaylistSong>();
        }

        public int SongID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int? Duration { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        public DateTime? UploadDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
