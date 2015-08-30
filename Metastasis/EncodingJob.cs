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

		public abstract void Run(int trackNumber);
	}
}
