using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterAutoMapper.Tests
{
    public class John
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Jared
    {
        public string FirstName { get; set; }
    }

    public class SimplePerson
    {
        public string FullName { get; set; }
    }

    public class People
    {
        public Jared Jared { get; set; }
        public John John { get; set; }

        public SimplePerson Simple { get; set; }
    }

    public class CamelCaseProperties
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
