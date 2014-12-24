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
        private int[] _exonStarts;
        private int[] _exonEnds;

        public Gene(string name1, string name2, string chrom, char strand, int startPos, int endPos, int exonCount, int[] exonStarts, int[] exonEnds)
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

        public int ExonCount
        {
            get
            {
                return _exonCount;
            }
        }
        public string Crhom
        {
            get
            {
                return _chrom;
            }
        }
        public string Name2
        {
            get
            {
                return _name2;
            }
        }

        
    }
}
