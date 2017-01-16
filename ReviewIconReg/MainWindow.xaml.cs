using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AssociatedWinIcon;
using ReviewIconReg.Helpers;
using ReviewIconReg.ViewModel;

namespace ReviewIconReg
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IAssociatedWinIcon _associatedWinIcon;

		private IEnumerable<ListIconItem> _icons;

		public MainWindow()
		{
			InitializeComponent();

			_associatedWinIcon = new AssociatedWinIcon.AssociatedWinIcon();

			_icons = _associatedWinIcon.GetRegExtensions()
					.Select(e => new ListIconItem
						{
							ExtName = e,
							IconImage = _associatedWinIcon.GetIcon(e)
											.ToImageSource()
						});

			listBox.ItemsSource = _icons;
		}

		private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
		{
//			listBox.ItemsSource = _icons.Where(i => i.ExtName.Contains(textBox.Text));

			if (e.Key == Key.Enter)
			{
				var listBoxItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(listBox.SelectedIndex);

				listBoxItem.Focus();
				e.Handled = true;
			}
		}

	}
}
