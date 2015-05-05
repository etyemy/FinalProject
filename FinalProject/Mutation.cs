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
        private string _mutId;

        private string _chrom;
        private int _position;
        private string _geneName;
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
        private string _tumourSite;

        private int _numOfShows = 1;

        public Mutation(MainBL ucscBL, string chrom, int position, string geneSym, char refNuc, char varNuc)
        {
            _mutId = generateMutId();
            _chrom = chrom;
            _chromNum = chrom.Replace("chr", "");
            _position = position;
            _geneName = geneSym;
            _ref = refNuc;
            _var = varNuc;
            extractExtraData(ucscBL);
            if(!ucscBL.mutationExist(this))
                ucscBL.addMutation(this);
        }
        public Mutation(string mutId,string chrom,int position,string geneName,char refNuc,char varNuc,char strand,string chromNum,string refCodon,string varCodon,string refAA,string varAA,string pMutationName,string cMutationName,string cosmicName,string tumourSite)
        {
            _mutId = mutId;
            _chrom = chrom;
            _position = position;
            _geneName = geneName;
            _ref = refNuc;
            _var = varNuc;
            _strand = strand;
            _chromNum = chromNum;
            _refCodon = refCodon;
            _varCodon = varCodon;
            _refAA = refAA;
            _varAA = varAA;
            _pMutationName = pMutationName;
            _cMutationName = cMutationName;
            _cosmicName = cosmicName;
            _tumourSite = tumourSite;
        }
        //Extract extra data that not supply in xls file.
        public void extractExtraData(MainBL MainBL)
        {
            try
            {
                _gene = MainBL.getGene(_geneName, _chrom);
                _strand = _gene.Strand;
                //_nucPlace = _gene.getLengthToIndex(_position);
                //if(_nucPlace!=-1)
                //{
                    _cosmicDetails = MainBL.getCosmicDetails(_chromNum, _position, _ref,_var);
                //}
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
                _cMutationName = _cosmicDetails.ElementAt(2);
                _tumourSite = _cosmicDetails.ElementAt(3);
            }
        }
        
        private void setVarRefCodons(int offset)
        {
            if (offset != -1)
            {
                _refCodon = UcscWebServices.getCodonAt(_chrom, _position, offset);

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
        public int Position
        {
            get
            {
                return _position;
            }
        }
        public string GeneName
        {
            get
            {
                return _geneName;
            }
        }
        public char Var
        {
            get
            {
                return _var;
            }
        }
        public char Ref
        {
            get
            {
                return _ref;
            }
        }
        public char Strand
        {
            get
            {
                return _strand;
            }
        }
        public string ChromNum
        {
            get
            {
                return _chromNum;
            }
        }
        public string RefCodon
        {
            get
            {
                return _refCodon;
            }
        }
        public string VarCodon
        {
            get
            {
                return _varCodon;
            }
        }
        public string VarAA
        {
            get
            {
                return _varAA;
            }
        }
        public string RefAA
        {
            get
            {
                return _refAA;
            }
        }
        public string PMutationName
        {
            get
            {
                return _pMutationName;
            }
        }
        public string CMutationName
        {
            get
            {
                return _cMutationName;
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
        public string TumourSite
        {
            get
            {
                return _tumourSite;
            }
        }
        public string MutId
        {
            get
            {
                return _mutId;
            }
        }

        public string PrintToLog()
        {
            return "" + _chrom + ", " + _position + ", " + _geneName +  ", x" + _numOfShows+", "+_tumourSite;
        }
        public string PrintXLSLine()
        {
            return _chrom + "\t" + _position + "\t" + _geneName + "\t" + _ref + "\t" + _var + "\t" + _strand + "\t" + _refCodon + "\t" + _varCodon + "\t" + _refAA + "\t" + _varAA + "\t" + _cMutationName+ "\t" + _pMutationName + "\t" + _cosmicName + "\t" + _numOfShows;
        }

        public bool Equals(Mutation that)
        {
            return (this.Chrom.Equals(that.Chrom) && this._position == that._position);
        }

        private string generateMutId()
        {
            DateTime t = DateTime.Now;
            string temp = "";
            temp += t.Year;
            temp += t.Month;
            temp += t.Day;
            temp += t.Hour;
            temp += t.Minute;
            temp += t.Second;
            temp += t.Millisecond;
            return temp;
        }
    }
}
