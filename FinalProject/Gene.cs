using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Gene
    {
        private string _name1;
        private string _name2;
        private string _chrom;
        private char _strand;
        private int _startPos;
        private int _endPos;
        private int _exonCount;
        private List<int> _exonStarts;
        private List<int> _exonEnds;

        public Gene(string name1, string name2, string chrom, char strand, int startPos, int endPos, int exonCount, List<int> exonStarts, List<int> exonEnds)
        {
            _name1 = name1;
            _name2 = name2;
            _chrom = chrom;
            _strand = strand;
            _startPos = startPos;
            _endPos = endPos;
            _exonCount = exonCount;
            _exonStarts = exonStarts;
            _exonEnds = exonEnds;

        }
    }
}
