using System.Collections.Generic;

namespace Metastasis
{
	public class Release
	{
		public string Artist { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }
		public string Genre { get; set; }
		public List<Track> Tracks { get; set; }
		public string WavPath { get; set; }
		public string Mp3Path { get; set; }
		public string FlacPath { get; set; }
	}
}
