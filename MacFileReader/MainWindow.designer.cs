// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacFileReader
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSTextFieldCell ChunkSizeTextField { get; set; }

		[Outlet]
		AppKit.NSTextField PercentageLabel { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator ProgressBarOutlet { get; set; }

		[Action ("CancelButtonAction:")]
		partial void CancelButtonAction (Foundation.NSObject sender);

		[Action ("FileButtonAction:")]
		partial void FileButtonAction (Foundation.NSObject sender);

		[Action ("StartButtonAction:")]
		partial void StartButtonAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ChunkSizeTextField != null) {
				ChunkSizeTextField.Dispose ();
				ChunkSizeTextField = null;
			}

			if (PercentageLabel != null) {
				PercentageLabel.Dispose ();
				PercentageLabel = null;
			}

			if (ProgressBarOutlet != null) {
				ProgressBarOutlet.Dispose ();
				ProgressBarOutlet = null;
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
