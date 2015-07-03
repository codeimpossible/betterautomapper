using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterAutoMapper
{
    public class BAMStrictMapViolationException : ApplicationException
    {
        private readonly string _message;

        public BAMStrictMapViolationException(Type from, Type to, IEnumerable<string> keys)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("The conversion from {0} to {0} failed.", from.Name, to.Name);
            sb.AppendFormat(" {0} properties would have been lost in the conversion and the conversion was flagged as strict.", keys.Count());
            _message = sb.ToString();
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
