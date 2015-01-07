using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    class Mutation
    {
        private UcscBL _ucscBL;
        enum XLSCol { Chrom = 0, Position, GeneSym, TargetID, Type, Zygosity, Ref, Variant, VarFreq, PValue, Coverage, RefCov, VarCov};

        private string _chrom;
        private string _chromNum;
        private int _position;
        private string _geneSym;
        private string _type;
        private char _ref;
        private char _var;
        
        private Gene _gene;
        
        private string _refCodon;
        private string _varCodon;
        private string _varAA;
        private string _refAA;
        private string _mutationName;
        private string _cosmicName;

        public Mutation(string[] xlsLineArr)
        {
            _ucscBL = new UcscBL();
            _chrom = xlsLineArr[(int)XLSCol.Chrom];
            _position = Convert.ToInt32(xlsLineArr[(int)XLSCol.Position]);
            _geneSym = xlsLineArr[(int)XLSCol.GeneSym];
            _type = xlsLineArr[(int)XLSCol.Type];
            _ref = Convert.ToChar(xlsLineArr[(int)XLSCol.Ref]);
            _var = Convert.ToChar(xlsLineArr[(int)XLSCol.Variant]);

            extractExtraData();
            
        }

        //Extract extra data that not supply in xls file.
        private void extractExtraData()
        {
            _chromNum = _chrom.Replace("chr", "");
            _gene = _ucscBL.getGene(_chrom, _geneSym);
            if (_gene != null)
            {
                setVarRefCodons(_gene.getOffsetInCodon(_position));
                if (_refCodon != null)
                {
                    _varAA = AminoAcid.getAminoAcid(_varCodon);
                    _refAA = AminoAcid.getAminoAcid(_refCodon);
                    if (_varAA.Equals(_refAA))
                        _mutationName = null;
                    else
                    {
                        _mutationName = "p." + _refAA + _gene.getExonPlace(_position) + _varAA;
                        _cosmicName = _ucscBL.getCosmicName(_chromNum, _position, _mutationName, _geneSym);
                    }
                }
            }
        }
        private void setVarRefCodons(int offset)
        {
            if (offset != -1)
            {
                _refCodon = UcscXML.getCodonAt(_chrom, _position, offset);
                
                char[] temp = _refCodon.ToCharArray();
                temp[offset] = _var;
                _varCodon = new string(temp);
                
                if (_gene.Strand.Equals('-'))
                {
                    _refCodon = reverseString(OppositeCodon(_refCodon));
                    _varCodon = reverseString(OppositeCodon(_varCodon));
                }
            }
        }

        private string reverseString(string toReverse)
        {
            char[] arr = toReverse.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private string OppositeCodon(string p)
        {
            string toReturn = "";
            foreach (char c in p)
            {
                switch (c)
                {
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
       
        internal bool isMutataion()
        {
            if (_mutationName != null)
                return true;
            return false;
        }

        internal bool hasCodon()
        {
            if (_varCodon != null)
                return true;
            return false;
        }

        internal bool hasCosmicName()
        {
            if (_cosmicName != null)
                return true;
            return false;
        }

        public bool isImportant()
        {
            if (isSNP() && isMutataion() && hasCodon() && hasCosmicName())
                return true;
            return false;
        }

        public int getCosmicNum()
        {
            return Convert.ToInt32(Regex.Match(_cosmicName, @"\d+").Value);
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
        public string CosmicName
        {
            get
            {
                return _cosmicName;
            }
        }

        override public string ToString()
        {
            return "" + _chrom + " " + _position + " " + _geneSym + " " + _ref + " " + _var + " "+ _cosmicName;
        }

    }
}
