﻿using System;
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
                    if (index.Length < 2)
                    {
                        continue;
                    }
                    var text = index[1];
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < text.Length-1; i++)
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
    }
}
