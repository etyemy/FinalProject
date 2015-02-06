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
        private UcscBL _ucscBL;

        private string _chrom;
        private int _position;
        private string _geneSym;
        private char _ref;
        private char _var;

        private Gene _gene;
        
        private string _chromNum;
        private string _refCodon;
        private string _varCodon;
        private string _varAA;
        private string _refAA;
        private string _mutationName;
        private string _cosmicName;

        public Mutation(string chrom, int position, string geneSym, char refNuc, char varNuc)
        {
            
            try
            {
                _ucscBL = new UcscBL();
                _gene = _ucscBL.getGene(chrom, geneSym);
                
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;
            }
            finally
            {
                if (_gene != null )
                {
                    _chrom = chrom;
                    _position = position;
                    _geneSym = geneSym;
                    _ref = refNuc;
                    _var = varNuc;
                    
                    extractExtraData();
                }
                Console.WriteLine("Creating Mutation " + this.PrintToLog());
            }
        }


        //Extract extra data that not supply in xls file.
        private void extractExtraData()
        {
            _chromNum = _chrom.Replace("chr", "");
            if (_gene != null)
            {
                setVarRefCodons(_gene.getOffsetInCodon(_position));
                if (_refCodon != null)
                {
                    _varAA = AminoAcid.getAminoAcid(_varCodon);
                    _refAA = AminoAcid.getAminoAcid(_refCodon);
                    
                        _mutationName = "p." + _refAA + _gene.getExonPlace(_position) + _varAA;
                        _cosmicName = _ucscBL.getCosmicName(_chromNum, _position, _mutationName, _geneSym);
                   
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
                        return null;
                }
            }
            return toReturn;
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

        public string PrintToLog()
        {
            return "" + _chrom + " " + _position + " " + _geneSym + " " + _ref + " " + _var + " " + _cosmicName;
        }
        public string PrintXLSLine()
        {
            return _chrom + "\t" + _position + "\t" + _geneSym + "\t" + _ref + "\t" + _var + "\t" + _refCodon + "\t" + _varCodon + "\t" + _refAA + "\t" + _varAA + "\t" + _mutationName + "\t" + _cosmicName;
        }

    }
}
