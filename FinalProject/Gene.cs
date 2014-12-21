using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Gene
    {
        private string _name;
        private string _chrom;
        private string _startPos;
        private string _endPos;
        private string _strand;
        private string _seq;

        public Gene(string name,string chrom,string startPos,string endPos,string strand,string seq)
        {
            _name = name;
            _chrom = chrom;
            _startPos = startPos;
            _endPos = endPos;
            _strand = strand;
            _seq = seq;
        }
    }
}
