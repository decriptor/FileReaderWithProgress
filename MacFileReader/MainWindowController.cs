
using System;

using AppKit;
using Foundation;

using FileReaderWithProgress;

namespace MacFileReader
{
	public partial class MainWindowController : NSWindowController
	{
		Reader reader;
		string _fileName;

		public string Filename {
			get {
				return _fileName;
			} 
			set {
				_fileName = value;
				Window.Title = _fileName;
			}
		}


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
			reader.Reset ();

			int bufferSize;
			if (int.TryParse (ChunkSizeTextField.StringValue, out bufferSize))
				reader.BufferSize = bufferSize;

			reader.Filename = Filename;
		}

		partial void FileButtonAction (NSObject sender)
		{
			var openPanel = new NSOpenPanel ();

			openPanel.FloatingPanel = true;
			openPanel.CanChooseFiles = true;
			openPanel.CanChooseDirectories = false;

			if (openPanel.RunModal () == 1) {
				Filename = openPanel.Url.Path;
			}
		}

		partial void StartButtonAction (NSObject sender)
		{
			Reset ();
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

