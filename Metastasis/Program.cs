using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ashod;

namespace Metastasis
{
	class Program
	{
		static void Main(string[] arguments)
		{
			if (arguments.Length != 1)
			{
				Console.WriteLine("Usage:");
				Console.WriteLine("<path to release configuration file>");
			}
			var configuration = JsonFile.Read<GeneralConfiguration>();
			var encoder = new Encoder(configuration);
			string releaseConfigurationPath = arguments[0];
			encoder.Run(releaseConfigurationPath);
		}
	}
}
