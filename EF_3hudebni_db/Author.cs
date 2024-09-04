using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_3hudebni_db
{
	public class Author
	{
		public Author()
		{
			this.Albums = new ObservableCollection<Album>();
		}

		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string Country { get; set; }
		public int Started { get; set; }

		public virtual ObservableCollection<Album> Albums { get; private set; }
	}
}
