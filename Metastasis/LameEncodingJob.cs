using System;
using System.Diagnostics;
using System.IO;

namespace Metastasis
{
	class LameEncodingJob : EncodingJob
	{
		public override void Run(int trackNumber)
		{
			if (Track.Number.HasValue)
				trackNumber = Track.Number.Value;
			string exePath = Path.Combine(Configuration.LamePath, "lame.exe");
			string wavPath = Path.Combine(Release.WavPath, Track.Filename);
			string mp3Filename = string.Format("{0}. {1} - {2}.mp3", trackNumber, Release.Artist, Track.Name);
			string mp3Path = Path.Combine(Release.Mp3Path, mp3Filename);
			string arguments = string.Format("-V 0 --ta \"{0}\" --tl \"{1}\" --ty \"{2}\" --tg \"{3}\" --tt \"{4}\" --tn \"{5}\" \"{6}\" \"{7}\"", Release.Artist, Release.Name, Release.Year, Release.Genre, Track.Name, trackNumber, wavPath, mp3Path);
			using (var process = Process.Start(exePath, arguments))
			{
				process.WaitForExit();
				if (process.ExitCode != 0)
				{
					string message = string.Format("lame.exe exited with code {0}", process.ExitCode);
					throw new ApplicationException(message);
				}
			}
		}
	}
}
