using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class SNPMutation
    {
        enum XLSCol { Chrom = 0, Position, GeneSym, TargetID, Type, Zygosity, Ref, Variant, VarFreq, PValue, Coverage, RefCov, VarCov, HotSpotID };

        private string _chrom;
        private string _position;
        private string _geneSym;
        private string _type;
        private string _ref;
        private string _variant;

        public SNPMutation(string[] xlsLineArr)
        {

            _chrom = xlsLineArr[(int)XLSCol.Chrom];
            _position = xlsLineArr[(int)XLSCol.Position];
            _geneSym = xlsLineArr[(int)XLSCol.GeneSym];
            _type = xlsLineArr[(int)XLSCol.Type];
            _ref = xlsLineArr[(int)XLSCol.Ref];
            _variant = xlsLineArr[(int)XLSCol.Variant];
        }

        public bool isSNP()
        {
            if (_type.Equals("SNP"))
                return true;
            return false;
        }

    }
}
