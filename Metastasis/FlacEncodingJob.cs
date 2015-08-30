using System.IO;

namespace Metastasis
{
	class FlacEncodingJob : EncodingJob
	{
		public override void Run()
		{
			string wavPath = Path.Combine(Configuration.WavDirectory, Track.Filename);
			string outputPath = GetOutputPath(Configuration.FlacOutputDirectory, "flac");

			string flacPath = Path.Combine(Configuration.FlacDirectory, "flac.exe");
			string flacArguments = string.Format("-7 -f \"{0}\" -o \"{1}\"", wavPath, outputPath);
			StartProcess(flacPath, flacArguments);

			string metaflacPath = Path.Combine(Configuration.FlacDirectory, "metaflac.exe");
			string metaflacArguments = string.Format("--set-tag=\"artist={0}\" --set-tag=\"album={1}\" --set-tag=\"date={2}\" --set-tag=\"genre={3}\" --set-tag=\"title={4}\" --set-tag=\"tracknumber={5}\" \"{6}\"", Release.Artist, Release.Release, Release.Year, Release.Genre, Track.Name, Track.Number, outputPath);
			StartProcess(metaflacPath, metaflacArguments);
		}
	}
}
