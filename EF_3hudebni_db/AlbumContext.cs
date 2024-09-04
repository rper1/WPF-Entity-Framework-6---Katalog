using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_3hudebni_db
{
	internal class AlbumContext : DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Album> Albums { get; set; }
	}
}
