// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace RXUITest
{
	[Register ("RXUITestViewController")]
	partial class RXUITestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel TheGuid { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GenerateButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TheGuid != null) {
				TheGuid.Dispose ();
				TheGuid = null;
			}

			if (GenerateButton != null) {
				GenerateButton.Dispose ();
				GenerateButton = null;
			}
		}
	}
}
