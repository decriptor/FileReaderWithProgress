using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileReaderWithProgress
{
	public class Reader
	{
		public string Filename { get; set; }
		public Action<double> PercentageRead;
		CancellationTokenSource cancellationTokenSource;

		public Reader ()
		{
			Reset ();
		}

		public void Reset ()
		{
			cancellationTokenSource = new CancellationTokenSource();
		}

		public async Task Read ()
		{
			// NOTE, You can play with the buffer size to change how fast the reader reads
			var buffer = new byte[1024 * 1024]; // 1MB buffer

			using (var fs = new FileStream (Filename, FileMode.Open))
			{
				var length = fs.Length;
				Console.WriteLine (length);
				long totalBytes = 0;
				int currentBlockSize = 0;

				while ((currentBlockSize = await fs.ReadAsync (buffer, 0, buffer.Length, cancellationTokenSource.Token)) > 0)
				{
					totalBytes += currentBlockSize;
					double percentage = (double)totalBytes * 100.0 / length;

					OnProgressChanged (percentage);
				}
			}
		}

		public void Cancel ()
		{
			cancellationTokenSource.Cancel ();
		}

		void OnProgressChanged (double percentage)
		{
			var handler = PercentageRead;
			if (handler != null)
				handler (percentage);
		}
	}
}
