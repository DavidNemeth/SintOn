using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SintOn.Models
{
    public class TextToMachine : ITextToMachine
    {
        public string Append(string input)
        {
            StringBuilder ret = new StringBuilder();

            var lines = input.Split('\n');
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }
                int count = 1;
                var index = line.Split(' ');
                if (index.Length != 2)
                {
                    continue;
                }
                var text = index[1];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < text.Length - 1; i++)
                {

                    if (String.IsNullOrEmpty(text))
                    {
                        continue;
                    }
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
                ret.AppendLine(index[0] + " " + sb.ToString());
            }
            return ret.ToString();
        }
        public string FixLength(string input)
        {
            StringBuilder ret = new StringBuilder();            
            var lines = input.Split('\n');
            int count = 0;
            foreach (var line in lines)
            {                
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }                
                var index = line.Split(' ');
                if (index.Length != 2)
                {
                    continue;
                }
                int nline = Convert.ToInt32(index[0]);

                string part = index[1];
                int n = part.Length;
                int temp = part.Length;
                if (n < 100)
                {
                    ret.Append((nline + count).ToString() + " " + part);
                    continue;
                }
                while (n != 0)
                {
                    ret.Append((nline + count).ToString());                    
                    if (n > 100)
                    {
                        ret.AppendLine(" " + part.Substring(temp - n, 100) + "$");
                        n -= 100;
                        count++;
                    }
                    else
                    {
                        ret.Append(" $" + part.Substring(temp - n , n));
                        n = 0;
                    }
                }

                //foreach (var ch in line)
                //{
                //    count++;
                //    if (count % 100 == 0)
                //    {
                //        ret.AppendLine("$");
                //        ret.Append("$");
                //    }
                //    ret.Append(ch);
                //}
                
            }
            return ret.ToString();
        }
    }
}
