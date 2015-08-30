using System;
using System.Diagnostics;
using System.IO;

namespace Metastasis
{
	abstract class EncodingJob
	{
		protected GeneralConfiguration Configuration;

		protected ReleaseConfiguration Release;

		protected TrackConfiguration Track;

		public void Initialize(GeneralConfiguration configuration, ReleaseConfiguration release, TrackConfiguration track)
		{
			Configuration = configuration;
			Release = release;
			Track = track;
		}

		public abstract void Run();

		protected string GetOutputPath(string encoderOutputDirectory, string fileExtension)
		{
			string releaseDirectory = string.Format("{0} - {1} ({2})", Release.Artist, Release.Release, Release.Year);
			string outputDirectory = Path.Combine(encoderOutputDirectory, releaseDirectory);
			if (!Directory.Exists(outputDirectory))
				Directory.CreateDirectory(outputDirectory);
			string outputFilename = string.Format("{0}. {1} - {2}.{3}", Track.Number, Release.Artist, Track.Name, fileExtension);
			string outputPath = Path.Combine(outputDirectory, outputFilename);
			return outputPath;
		}

		protected void StartProcess(string path, string arguments)
		{
			var processStartInfo = new ProcessStartInfo
			{
				FileName = path,
				Arguments = arguments,
				CreateNoWindow = true,
			};
			using (var process = Process.Start(processStartInfo))
			{
				process.WaitForExit();
				if (process.ExitCode != 0)
				{
					string message = string.Format("{0} exited with code {1}", path, process.ExitCode);
					throw new ApplicationException(message);
				}
			}
		}
	}
}
