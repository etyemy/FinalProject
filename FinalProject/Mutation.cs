using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Mutation
    {
        private string _chrom;
        private int _position;
        private string _geneSym;
        private char _ref;
        private char _var;

        private List<String> _cosmicDetails;
        private Gene _gene;
        private char _strand;
        private string _chromNum;
        private string _refCodon;
        private string _varCodon;
        private string _varAA;
        private string _refAA;
        private int _nucPlace;
        private string _pMutationName;
        private string _cMutationName;
        private string _cosmicName;

        private int _numOfShows = 1;

        public Mutation(string chrom, int position, string geneSym, char refNuc, char varNuc)
        {
            _chrom = chrom;
            _chromNum = chrom.Replace("chr", "");
            _position = position;
            _geneSym = geneSym;
            _ref = refNuc;
            _var = varNuc;
        }


        //Extract extra data that not supply in xls file.
        public void extractExtraData(UcscBL ucscBL)
        {
            try
            {
                _gene = ucscBL.getGene(_geneSym, _chrom);
                _strand = _gene.Strand;
                _nucPlace = _gene.getLengthToIndex(_position);
                if(_nucPlace!=-1)
                {
                    _cMutationName = "c." + _nucPlace + _ref + ">" + _var;
                    _cosmicDetails = ucscBL.getCosmicDetails(_chromNum, _position, _cMutationName);
                }
                setVarRefCodons(_gene.getOffsetInCodon(_position));
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;
            }
            if (_refCodon != null)
            {
                _varAA = AminoAcid.getAminoAcid(_varCodon);
                _refAA = AminoAcid.getAminoAcid(_refCodon);
            }
            if (_cosmicDetails != null)
            {
                _cosmicName = _cosmicDetails.ElementAt(0);
                _pMutationName = _cosmicDetails.ElementAt(1);
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
                        return null;
                }
            }
            return toReturn;
        }
        internal bool isMutataion()
        {
            if (_pMutationName != null)
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
            if (isMutataion() && hasCodon() && hasCosmicName())
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
        public int NumOfShows
        {
            get
            {
                return _numOfShows;
            }
            set
            {
                _numOfShows = value;
            }
        }

        public string PrintToLog()
        {
            return "" + _chrom + " " + _position + " " + _geneSym + " " + _ref + " " + _var + " " + _cosmicName + " " + _numOfShows;
        }
        public string PrintXLSLine()
        {
            return _chrom + "\t" + _position + "\t" + _geneSym + "\t" + _ref + "\t" + _var + "\t" + _strand + "\t" + _refCodon + "\t" + _varCodon + "\t" + _refAA + "\t" + _varAA + "\t" + _cMutationName+ "\t" + _pMutationName + "\t" + _cosmicName + "\t" + _numOfShows;
        }

        public bool Equals(Mutation that)
        {
            return (this.Chrom.Equals(that.Chrom) && this._position == that._position);
        }

    }
}
