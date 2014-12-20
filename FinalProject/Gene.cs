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
        private string _info;
        private string _chrom;
        private string _startPos;
        private string _endPos;
        private string _direction;
        private string _seq;

        public Gene(string name,string info,string chrom,string startPos,string endPos,string direction,string seq)
        {
            _name = name;
            _info = info;
            _chrom = chrom;
            _startPos = startPos;
            _endPos = endPos;
            _direction = direction;
            _seq = seq;
        }
    }
}
