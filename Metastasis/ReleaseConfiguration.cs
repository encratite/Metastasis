using System.Collections.Generic;

namespace Metastasis
{
	public class ReleaseConfiguration
	{
		public string Artist { get; set; }
		public string Release { get; set; }
		public int Year { get; set; }
		public string Genre { get; set; }
		public List<TrackConfiguration> Tracks { get; set; }
	}
}
