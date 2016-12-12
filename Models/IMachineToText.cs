using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintOn.Models
{
    public interface IMachineToText
    {
        string ReverseFromCount(string input);
        string ReverseFromLong(string input);
    }
}
