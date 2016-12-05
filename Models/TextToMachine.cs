using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintOn.Models
{
    public class TextToMachine
    {
        public List<string> Append(string input)
        {
            List<string> ret = new List<string>();
            try
            {
                var lines = input.Split('\n');
                foreach (var line in lines)
                {
                    if (String.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    int count = 1;
                    var index = line.Split(' ');
                    var text = index[1];
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == text[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            if (count > 1)
                            {
                                sb.Append(string.Format($"{count}{text[i]}"));
                                count = 1;
                            }
                            else
                            {
                                sb.Append(string.Format($"{text[i]}"));
                            }
                        }
                        if (i == text.Length - 2)
                        {
                            sb.Append(string.Format($"{count}{text[i]}"));
                        }
                    }
                    ret.Add(index[0] + " " + sb.ToString());
                }
            }
            catch (Exception)
            {
            }
            return ret;
        }        
    }
}
