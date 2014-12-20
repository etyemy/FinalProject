using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class FAHandler
    {
        List<string> lineList;
        public FAHandler(string faPath)
        {
            lineList = new List<string>();
            StreamReader faStream = new StreamReader(faPath);
            faStream.ReadLine();
            while (faStream.Peek() >= 0)
            {
                lineList.Add(faStream.ReadLine());
            }
        }
        public char getNukAt(int index)
        {
            int lineNum = index / 50;
            int offset = index - (lineNum * 50);
            return lineList[lineNum ][offset - 1];
        }
        public int getOffsetInCodon(int index)
        {
            return (index - 1) % 3;
        }
        public string getCodonAt(int index)
        {
            int offset = getOffsetInCodon(index) ;
            string codon = "";
            switch (offset)
            {
                case 0:
                    codon += getNukAt(index);
                    codon += getNukAt(index+1);
                    codon += getNukAt(index+2);
                    break;
                case 1:
                    codon += getNukAt(index-1);
                    codon += getNukAt(index);
                    codon += getNukAt(index+1);
                    break;
                case 2:
                    codon += getNukAt(index-2);
                    codon += getNukAt(index-1);
                    codon += getNukAt(index);
                    break;
                default:
                    break;
            }
            return codon;
        }
    }
}
