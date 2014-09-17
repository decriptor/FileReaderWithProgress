// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace MacFileReader
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField PercentageLabel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSProgressIndicator ProgressBarOutlet { get; set; }

		[Action ("CancelButtonAction:")]
		partial void CancelButtonAction (MonoMac.Foundation.NSObject sender);

		[Action ("FileButtonAction:")]
		partial void FileButtonAction (MonoMac.Foundation.NSObject sender);

		[Action ("StartButtonAction:")]
		partial void StartButtonAction (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ProgressBarOutlet != null) {
				ProgressBarOutlet.Dispose ();
				ProgressBarOutlet = null;
			}

			if (PercentageLabel != null) {
				PercentageLabel.Dispose ();
				PercentageLabel = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
