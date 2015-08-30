using System.IO;

namespace Metastasis
{
	class LameEncodingJob : EncodingJob
	{
		public override void Run()
		{
			string wavPath = Path.Combine(Release.WavPath, Track.Filename);
			string outputFilename = string.Format("{0}. {1} - {2}.mp3", Track.Number, Release.Artist, Track.Name);
			string outputPath = Path.Combine(Release.Mp3Path, outputFilename);

			string lamePath = Path.Combine(Configuration.LamePath, "lame.exe");
			string arguments = string.Format("-V 0 --ta \"{0}\" --tl \"{1}\" --ty \"{2}\" --tg \"{3}\" --tt \"{4}\" --tn \"{5}\" \"{6}\" \"{7}\"", Release.Artist, Release.Name, Release.Year, Release.Genre, Track.Name, Track.Number, wavPath, outputPath);
			StartProcess(lamePath, arguments);
		}
	}
}
