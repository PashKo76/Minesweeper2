using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Парсер
{
    internal class Parser
    {
        static public void LetsParse(string String, ref int? X, ref int? Y)
        {
            string[] words = String.Split(' ');
            int? x = null;
            int? y = null;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != " ")
                {
                    try
                    {
                        if (x == null)
                        {
                            x = int.Parse(words[i]);
                        }
                        else if (y == null)
                        {
                            y = int.Parse(words[i]);
                        }
                        else if (x != null && y != null)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            X = x;
            Y = y;
        }
    }
}
