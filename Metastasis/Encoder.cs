using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ashod;

namespace Metastasis
{
	class Encoder
	{
		private Configuration _Configuration;

		private ConcurrentQueue<EncodingJob> _Jobs = null;

		public Encoder(Configuration configuration)
		{
			_Configuration = configuration;
		}

		public void Run(string releaseConfigurationPath)
		{
			var release = JsonFile.Read<Release>(releaseConfigurationPath);
			Run(release);
		}

		public void Run(Release release)
		{
			_Jobs = new ConcurrentQueue<EncodingJob>();
			CreateJobs<LameEncodingJob>(release);
			CreateJobs<FlacEncodingJob>(release);
			var threads = new List<Thread>();
			for (int i = 0; i < Environment.ProcessorCount; i++)
			{
				var thread = new Thread(Worker);
				thread.Start();
			}
			foreach (var thread in threads)
				thread.Join();
		}

		private void CreateJobs<JobType>(Release release)
			where JobType : EncodingJob, new()
		{
			int trackNumber = 1;
			foreach (var track in release.Tracks)
			{
				var job = new JobType();
				if (!track.Number.HasValue)
					track.Number = trackNumber;
				job.Initialize(_Configuration, release, track);
				_Jobs.Enqueue(job);
				trackNumber++;
			}
		}

		private void Worker()
		{
			while (_Jobs.Any())
			{
				EncodingJob job;
				if (!_Jobs.TryDequeue(out job))
					continue;
				job.Run();
			}
		}
	}
}
