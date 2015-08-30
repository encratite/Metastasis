using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ashod;

namespace Metastasis
{
	class Encoder
	{
		private Configuration _Configuration;

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
			throw new NotImplementedException();
		}
	}
}
