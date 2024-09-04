using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EF_3hudebni_db
{
	/// <summary>
	/// Interaction logic for InsertAuthorWindow.xaml
	/// </summary>
	public partial class InsertAuthorWindow : Window
	{
		private AlbumContext db = new AlbumContext();
		private Manager manager;
		private bool btnAddPressed = false;

		public InsertAuthorWindow()
		{
			InitializeComponent();
			manager = new Manager();
			txtAuthorName.Focus();
		}
		/// <summary>
		/// stisk tlačítka Přidat autora
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddAuthor_Click(object sender, RoutedEventArgs e)
		{
			btnAddPressed = true;

			if (manager.IsAuthorValid(txtAuthorName, txtCountry, txtStarted))
			{
				Author aut = new Author();
				aut.AuthorName = txtAuthorName.Text.Trim();
				aut.Country = txtCountry.Text.Trim();
				aut.Started = int.Parse(txtStarted.Text);
				try
				{
					db.Authors.Add(aut);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				DialogResult = true;
			}
		}
		/// <summary>
		/// po neúspěšném stisknutí tlačítka Přidat autora potom po každé změně pole Autor
		/// kontroluje jeho vyplnění
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtAuthorName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (btnAddPressed)
			{
				manager.IsAuthorValid(txtAuthorName, txtCountry, txtStarted);
			}
		}
		/// <summary>
		/// po neúspěšném stisknutí tlačítka Přidat autora potom po každé změně pole Země
		/// kontroluje jeho vyplnění
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtCountry_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (btnAddPressed)
			{
				manager.IsAuthorValid(txtAuthorName, txtCountry, txtStarted);
			}
		}
		/// <summary>
		/// po neúspěšném stisknutí tlačítka Přidat autora potom po každé změně pole Rok začátku
		/// kontroluje jeho správné vyplnění
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtStarted_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (btnAddPressed)
			{
				manager.IsAuthorValid(txtAuthorName, txtCountry, txtStarted);
			}
		}
		/// <summary>
		/// dovolí zadat pouze číslice
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericOnly(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}
