using System.IO;

namespace Metastasis
{
	class LameEncodingJob : EncodingJob
	{
		public override void Run()
		{
			string wavPath = Path.Combine(Release.WavPath, Track.Filename);
			string outputPath = GetOutputPath(Configuration.Mp3OutputDirectory, "mp3");

			string lamePath = Path.Combine(Configuration.LameDirectory, "lame.exe");
			string arguments = string.Format("-V 0 --ta \"{0}\" --tl \"{1}\" --ty \"{2}\" --tg \"{3}\" --tt \"{4}\" --tn \"{5}\" \"{6}\" \"{7}\"", Release.Artist, Release.Release, Release.Year, Release.Genre, Track.Name, Track.Number, wavPath, outputPath);
			StartProcess(lamePath, arguments);
		}
	}
}
