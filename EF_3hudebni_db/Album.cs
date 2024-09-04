using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_3hudebni_db
{
	public class Album
	{
		public int AlbumId { get; set; }
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string AlbumName { get; set; }
		public int Released { get; set; }
		public virtual Author Author { get; set; }
	}
}
