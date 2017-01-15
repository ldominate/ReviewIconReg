using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ReviewIconReg.Helpers
{
	public static class IconUtilities
	{
//		[DllImport("gdi32.dll", SetLastError = true)]
//		private static extern bool DeleteObject(IntPtr hObject);

		public static ImageSource ToImageSource(this Icon icon)
		{
			try
			{
				if(icon == null) return new BitmapImage();

				//Bitmap bitmap = icon.ToBitmap();
//				IntPtr hBitmap = bitmap.GetHbitmap();

				return Imaging.CreateBitmapSourceFromHIcon(
					icon.Handle,
					new Int32Rect(0, 0, icon.Width, icon.Height),
					BitmapSizeOptions.FromEmptyOptions());

//				if (!DeleteObject(hBitmap))
//				{
//					throw new Win32Exception();
//				}
//				return wpfBitmap;
			}
			catch (Exception)
			{
				return new BitmapImage();
			}
		}
	}
}