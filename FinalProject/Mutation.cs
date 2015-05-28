﻿using System;
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
        public void extractExtraData(MainBL MainBL)
        {
            try
            {
                _gene = MainBL.getGene(_geneName, _chrom);
                _strand = _gene.Strand;
                if(_strand.Equals('+'))
                    _cosmicDetails = MainBL.getCosmicDetails(_chromNum, _position, _ref,_var);
                else if (_strand.Equals('-'))
                    _cosmicDetails = MainBL.getCosmicDetails(_chromNum, _position, OppositeNuc(_ref),OppositeNuc(_var));

                setVarRefCodons(_gene.getOffsetInCodon(_position));
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;
            }
            if (!_refCodon.Equals("No Coding"))
            {
                _varAA = AminoAcid.getAminoAcid(_varCodon);
                _refAA = AminoAcid.getAminoAcid(_refCodon);
            }
            else
            {
                _varAA = "-----";
                _refAA = "-----";
            }
            if (_cosmicDetails != null)
            {
                _cosmicName = _cosmicDetails.ElementAt(0);
                _pMutationName = _cosmicDetails.ElementAt(1);
                _cMutationName = _cosmicDetails.ElementAt(2);
                _tumourSite = _cosmicDetails.ElementAt(3);
            }
            else
            {
                _cosmicName = "-----";
                _pMutationName = "-----";
                _cMutationName = "-----";
                _tumourSite = "-----";
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
            else
            {
                _refCodon = "No Coding";
                _varCodon = "No Coding";
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
        private char OppositeNuc(char c)
        {
            switch (c)
            {
                case 'A':
                    return 'T';
                case 'T':
                    return 'A';
                case 'G':
                    return 'C';
                case 'C':
                    return 'G';
                default:
                    return ' ';
            }
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
        public List<int> getCosmicNums()
        {
            List<int> toReturn=new List<int>();
            string[] cosmicId = _cosmicName.Split(' ');
            foreach (string s in cosmicId)
                toReturn.Add(Convert.ToInt32(Regex.Match(s, @"\d+").Value));
            return toReturn;
        }
        public string PrintXLSLine()
        {
            return _chrom + "\t" + _position + "\t" + _geneName + "\t" + _ref + "\t" + _var + "\t" + _strand + "\t" + _refCodon + "\t" + _varCodon + "\t" + _refAA + "\t" + _varAA + "\t" + _cMutationName+ "\t" + _pMutationName + "\t" + _cosmicName + "\t" + _numOfShows;
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
