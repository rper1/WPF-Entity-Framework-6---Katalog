using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace EF_3hudebni_db
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private AlbumContext _context = new AlbumContext();
		private Manager manager;
		private Author selectedAuthor;
		private Album selectedAlbum;
		private bool saveButtonPressed = false;
		private bool isAlbumOK = false;
		private int started;

		public MainWindow()
		{
			InitializeComponent();
			manager = new Manager();
			Style = (Style)FindResource(typeof(Window));
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			System.Windows.Data.CollectionViewSource authorViewSource =
				 ((System.Windows.Data.CollectionViewSource)(this.FindResource("authorViewSource")));

			_context.Authors.Load();
			authorViewSource.Source = _context.Authors.Local;

			ExistsAnyAlbum();
			ExistsAnyAuthor();
		}
		/// <summary>
		/// stisk některého ze dvou tlačítek Uložit změny
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			saveButtonPressed = true;
			isAlbumOK = false;

			if (albumsDataGrid.Items.Count < 1)
			{
				isAlbumOK = true;
				txtAlbumName.Text = "";
				txtReleased.Text = "";
			}

			if (authorDataGrid.Items.Count > 0)
			{
				selectedAuthor = ((Author)authorDataGrid.SelectedItem);

				if (albumsDataGrid.Items.Count > 0 && manager.IsAlbumValid(txtAlbumName, txtReleased, selectedAuthor.Started))
				{
					selectedAlbum = ((Album)albumsDataGrid.SelectedItem);
					selectedAlbum.AlbumName = selectedAlbum.AlbumName.Trim();
					isAlbumOK = true;
				}
				if (manager.IsAuthorValid(txtAuthName, txtCountry, txtStarted) && isAlbumOK)
				{
					foreach (var album in _context.Albums.Local.ToList())
					{
						if (album.Author == null)
						{
							_context.Albums.Remove(album);
						}
					}
					txtAuthName.Text = txtAuthName.Text.Trim();
					txtCountry.Text = txtCountry.Text.Trim();

					selectedAuthor.AuthorName = selectedAuthor.AuthorName.Trim();
					selectedAuthor.Country = selectedAuthor.Country.Trim();

					txtAlbumName.Text = txtAlbumName.Text.Trim();


					_context.SaveChanges();
					this.authorDataGrid.Items.Refresh();
					this.albumsDataGrid.Items.Refresh();
					lblSaved.Foreground = (Brush)new BrushConverter().ConvertFrom("#1CE416");
					lblSaved.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#1CE416");
					lblSaved.BorderThickness = new Thickness(1);
					lblSaved.Content = "Uloženo";
					saveButtonPressed = false;
					isAlbumOK = false;
					authorDataGrid.IsEnabled = true;
					albumsDataGrid.IsEnabled = true;
				}
				else
				{
					authorDataGrid.IsEnabled = false;
					albumsDataGrid.IsEnabled = false;
					lblSaved.Foreground = Brushes.Red;
					lblSaved.BorderBrush = Brushes.Red;
					lblSaved.BorderThickness = new Thickness(1);
					lblSaved.Content = "Neuloženo";
				}
			}
		}
		/// <summary>
		/// dovolí zapsat jen číslice
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NumericOnly(System.Object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);
			this._context.Dispose();
		}
		/// <summary>
		/// stisk tlačítka Nové album
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddAlbum_Click(object sender, RoutedEventArgs e)
		{
			if (authorDataGrid.SelectedIndex > -1)
			{
				InsertAlbumWindow winAlb = new InsertAlbumWindow(authorDataGrid.SelectedItem);
				winAlb.ShowDialog();
				_context.Albums.Load();
				this.authorDataGrid.Items.Refresh();
				this.albumsDataGrid.Items.Refresh();
				if (albumsDataGrid.Items.Count == 1)
				{
					albumsDataGrid.SelectedIndex = 0;
				}

				ExistsAnyAlbum();

			}
			else if (authorDataGrid.Items.Count == 0)
			{
				MessageBox.Show("Nejdříve vytvořte autora");
			}
			else
			{
				MessageBox.Show("Musíte nahoře vybrat autora");
			}
		}
		/// <summary>
		/// stisk tlačítka Smazat album
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelAlbum_Click(object sender, RoutedEventArgs e)
		{
			if (albumsDataGrid.Items.Count > 0)
			{
				Album selectedAlbum = albumsDataGrid.SelectedItem as Album;
				MessageBoxResult messageBoxResult = MessageBox.Show($"Opravdu chcete smazat album \"{selectedAlbum.AlbumName}\" od autora \"{selectedAlbum.AuthorName}\" ?", "Potvrzení smazání", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
				if (messageBoxResult == MessageBoxResult.OK)
				{
					_context.Albums.Remove(selectedAlbum);
					_context.SaveChanges();
					albumsDataGrid.Items.Refresh();
					authorDataGrid.IsEnabled = true;
					albumsDataGrid.IsEnabled = true;
					lblSaved.Content = "";
					lblSaved.BorderThickness = new Thickness(0);

					ExistsAnyAlbum();
				}
			}
		}
		/// <summary>
		/// stisk tlačítka Nový autor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddAuthor_Click(object sender, RoutedEventArgs e)
		{
			InsertAuthorWindow winAuth = new InsertAuthorWindow();
			winAuth.ShowDialog();
			_context.Authors.Load();
			this.authorDataGrid.Items.Refresh();
			ExistsAnyAlbum();
			if (authorDataGrid.Items.Count == 1)
			{
				authorDataGrid.SelectedIndex = 0;
			}

			ExistsAnyAuthor();
		}
		/// <summary>
		/// stisk tlačítka Smazat autora
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelAuthor_Click(object sender, RoutedEventArgs e)
		{
			if (authorDataGrid.Items.Count > 0)
			{
				Author selectedAuthor = authorDataGrid.SelectedItem as Author;
				MessageBoxResult messageBoxResult = MessageBox.Show($"Opravdu chcete smazat autora \"{selectedAuthor.AuthorName}\" a všechna jeho alba?", "Potvrzení smazání", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel);
				if (messageBoxResult == MessageBoxResult.OK)
				{
					_context.Authors.Remove(selectedAuthor);
					_context.SaveChanges();
					authorDataGrid.Items.Refresh();
					authorDataGrid.IsEnabled = true;
					albumsDataGrid.IsEnabled = true;
					lblSaved.Content = "";
					lblSaved.BorderThickness = new Thickness(0);
					ExistsAnyAlbum();

					ExistsAnyAuthor();
				}
			}
		}
		/// pokud je zobrazen zelený nápis Uloženo, tak po kliknutí na okno zmizí
		private void Window_GotFocus(object sender, RoutedEventArgs e)
		{
			if (lblSaved.Content == "Uloženo")
			{
				lblSaved.Content = "";
				lblSaved.BorderThickness = new Thickness(0);
			}
		}
		/// <summary>
		/// pokud je zobrazen zelený nápis Uloženo, tak po kliknutí na okno zmizí
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (lblSaved.Content == "Uloženo")
			{
				lblSaved.Content = "";
				lblSaved.BorderThickness = new Thickness(0);
			}
		}
		/// <summary>
		/// reaguje na změnu v poli Autor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtAuthName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (saveButtonPressed)
			{
				manager.IsAuthorValid(txtAuthName, txtCountry, txtStarted);
			}
		}
		/// <summary>
		/// reaguje na změnu v poli Země
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtCountry_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (saveButtonPressed)
			{
				manager.IsAuthorValid(txtAuthName, txtCountry, txtStarted);
			}
		}
		/// <summary>
		/// reaguje na změnu v poli Začátek
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtStarted_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (saveButtonPressed)
			{
				manager.IsAuthorValid(txtAuthName, txtCountry, txtStarted);
			}
		}
		/// <summary>
		/// reaguje na změnu v poli Album
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtAlbumName_TextChanged(object sender, TextChangedEventArgs e)
		{
			started = (selectedAuthor == null) ? 1900 : selectedAuthor.Started;
			if (saveButtonPressed && !isAlbumOK)
			{
				manager.IsAlbumValid(txtAlbumName, txtReleased, started);
			}
		}
		/// <summary>
		/// reaguje na změnu v poli Vydáno, nedovolí nižší rok alba,
		/// než je začátek autora 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtReleased_TextChanged(object sender, TextChangedEventArgs e)
		{
			started = (selectedAuthor == null) ? 1900 : selectedAuthor.Started;
			if (saveButtonPressed && !isAlbumOK)
			{
				manager.IsAlbumValid(txtAlbumName, txtReleased, started);
			}
		}
		/// <summary>
		/// reaguje na změnu vybraného autora
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void authorDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			ExistsAnyAlbum();
		}
		/// <summary>
		/// pokud neexistuje album, zakáže editaci i u názvu a roku vydání
		/// </summary>
		public void ExistsAnyAlbum()
		{
			txtAlbumName.IsReadOnly = false;
			txtReleased.IsReadOnly = false;

			if (albumsDataGrid.Items.Count == 0)
			{
				txtAlbumName.IsReadOnly = true;
				txtReleased.IsReadOnly = true;
			}
		}
		/// <summary>
		/// pokud neexistuje autor, zakáže editaci i u jména, země a začátku
		/// </summary>
		public void ExistsAnyAuthor()
		{
			txtAuthName.IsReadOnly = false;
			txtCountry.IsReadOnly = false;
			txtStarted.IsReadOnly = false;

			if (authorDataGrid.Items.Count == 0)
			{
				txtAuthName.IsReadOnly = true;
				txtCountry.IsReadOnly = true;
				txtStarted.IsReadOnly = true;
			}
		}
	}
}
