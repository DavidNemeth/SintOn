using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintOn.Models
{
    public interface ITextToMachine
    {
        string Append(string input);
        string FixLength(string input);
    }
}
