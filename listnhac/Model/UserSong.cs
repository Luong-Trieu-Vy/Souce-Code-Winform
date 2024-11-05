namespace listnhac.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSong
    {
        public int UserSongID { get; set; }

        public int? UserID { get; set; }

        public int? SongID { get; set; }

        public DateTime? DateAdded { get; set; }

        public virtual Song Song { get; set; }

        public virtual User User { get; set; }
    }
}
