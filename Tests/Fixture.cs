using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenoid.Tests
{
    class Fixture
    {
        private static string BasePath => Path.GetDirectoryName(typeof(Fixture).Assembly.Location);
        private static string FixtureBasePath => Path.Combine(BasePath, "Fixtures");

        public static string GetFullPath(string fileName)
        {
            return Path.Combine(FixtureBasePath, fileName);
        }
    }
}
