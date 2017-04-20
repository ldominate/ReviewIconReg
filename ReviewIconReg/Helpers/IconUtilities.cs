using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReviewIconReg.Helpers
{
	public static class IconUtilities
	{
		public static ImageSource ToImageSource(this Icon icon)
		{
			try
			{
				if(icon == null) return new BitmapImage();

				return Imaging.CreateBitmapSourceFromHIcon(
					icon.Handle,
					new Int32Rect(0, 0, icon.Width, icon.Height),
					BitmapSizeOptions.FromEmptyOptions());
			}
			catch (Exception)
			{
				return new BitmapImage();
			}
		}
	}
}