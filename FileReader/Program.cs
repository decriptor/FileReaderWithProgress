using System;
using FileReaderWithProgress;

namespace FileReader
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			Reader r = new Reader ();
			r.Filename = args [0];
			r.PercentageRead = ProgressOutput;
			r.Read ();
		}

		static void ProgressOutput (double percentage)
		{
			Console.WriteLine (percentage);
		}
	}
}
