
using System;

using MonoMac.AppKit;
using MonoMac.Foundation;

using FileReaderWithProgress;

namespace MacFileReader
{
	public partial class MainWindowController : NSWindowController
	{
		Reader reader;
		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			reader = new Reader ();
			// NOTE, file is hardcoded. You'll have to change it here.
			reader.Filename = "/Users/sshaw/tmp/output.mlpd";
			reader.PercentageRead = UpdateProgress;
		}

		public override void AwakeFromNib ()
		{
			Reset ();
		}
		#endregion

		void Reset ()
		{
			ProgressBarOutlet.MinValue = 0.0;
			ProgressBarOutlet.MaxValue = 100.0;
			ProgressBarOutlet.DoubleValue = 0.0;
			ProgressBarOutlet.Indeterminate = false;
		}

		partial void StartButtonAction (NSObject sender)
		{
			Reset ();
			reader.Reset ();
			reader.Read ();
		}

		partial void CancelButtonAction (NSObject sender)
		{
			reader.Cancel ();
		}

		void UpdateProgress (double percentage)
		{
			InvokeOnMainThread (() => {
				ProgressBarOutlet.DoubleValue = percentage;
				PercentageLabel.StringValue = percentage.ToString ();
				ProgressBarOutlet.NeedsDisplay = true;
			});
		}

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
	}
}

