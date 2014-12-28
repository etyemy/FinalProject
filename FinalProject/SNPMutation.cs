using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class SNPMutation
    {
        private RefGeneBL _refGeneBL;
        enum XLSCol { Chrom = 0, Position, GeneSym, TargetID, Type, Zygosity, Ref, Variant, VarFreq, PValue, Coverage, RefCov, VarCov, HotSpotID };

        private string _chrom;
        private int _position;
        private string _geneSym;
        private string _type;
        private char _ref;
        private char _var;
        private Gene _gene;
        private int _offset;
        private string _refCodon;
        private string _varCodon;
        private int _exonPlaceInSeq;
        private string _varAA;
        private string _refAA;
        public SNPMutation(string[] xlsLineArr)
        {
            _refGeneBL = new RefGeneBL();
            _chrom = xlsLineArr[(int)XLSCol.Chrom];
            _position = Convert.ToInt32(xlsLineArr[(int)XLSCol.Position]);
            _geneSym = xlsLineArr[(int)XLSCol.GeneSym];
            _type = xlsLineArr[(int)XLSCol.Type];
            _ref = Convert.ToChar(xlsLineArr[(int)XLSCol.Ref]);
            _var = Convert.ToChar(xlsLineArr[(int)XLSCol.Variant]);
            _gene = _refGeneBL.getGene(_chrom, _geneSym);
            _offset = _gene.CodonOffsetInGene(_position);
            setVarRefCodons();
            _exonPlaceInSeq = _gene.getExonPlace(_position);
            _varAA = AminoAcid.getAminoAcid(_varCodon);
            _refAA = AminoAcid.getAminoAcid(_refCodon);
          
            
        }

        

        private void setVarRefCodons()
        {
            if (_offset != -1)
            {
                _refCodon = UcscXML.getCodonAt(_chrom, _position, _offset);
                char[] temp = _refCodon.ToCharArray();
                temp[_offset] = _var;
                _varCodon = new string(temp);
                if (_gene.Strand.Equals('-'))
                {
                    _refCodon = reverseString(OppositeCodon(_refCodon));
                    _varCodon = reverseString(OppositeCodon(_varCodon));
                }
            }
            else
                _refCodon = _varCodon = "NoCoding";
        }

        private string OppositeCodon(string p)
        {
            string toReturn = "";
            foreach(char c in p)
            {
                switch(c){
                    case 'A':
                        toReturn += "T";
                        break;
                    case 'T':
                        toReturn += "A";
                        break;
                    case 'G':
                        toReturn += "C";
                        break;
                    case 'C':
                        toReturn += "G";
                        break;
                    default:
                        break;
                }
            }
            return toReturn;
        }

        public bool isSNP()
        {
            if (_type.Equals("SNP"))
                return true;
            return false;
        }
        public string Chrom
        {
            get
            {
                return _chrom;
            }
        }
        public string GeneSym
        {
            get
            {
                return _geneSym;
            }
        }

        override public string ToString()
        {
            return "" + _chrom + " " + _position + " " + " " + _gene.ExonCount + " " + _geneSym + " " + _ref + " " + _var + " " + _gene.Strand + " " + _offset + " " + _refCodon + " " + _varCodon + " " + _exonPlaceInSeq + " " + _refAA + " " + _varAA;
        }

        private string reverseString(string toReverse)
        {
            char[] arr = toReverse.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
