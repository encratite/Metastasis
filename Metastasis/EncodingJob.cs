using System;
using System.Diagnostics;

namespace Metastasis
{
	abstract class EncodingJob
	{
		protected Configuration Configuration;

		protected Release Release;

		protected Track Track;

		public void Initialize(Configuration configuration, Release release, Track track)
		{
			Configuration = configuration;
			Release = release;
			Track = track;
		}

		public abstract void Run();

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
