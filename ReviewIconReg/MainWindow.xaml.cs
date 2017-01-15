using System.Collections.Generic;
using System.Linq;
using System.Windows;
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

//			foreach (var item in _icons)
//			{
//				var icon = _associatedWinIcon.GetIcon(item.ExtName);
//
//				if (icon != null) item.IconImage = icon.ToImageSource();
//			}

			listBox.ItemsSource = _icons;

//			foreach (var item in _icons)
//			{
//				listBox.Items.Add(item);
//			}
		}

	}
}
