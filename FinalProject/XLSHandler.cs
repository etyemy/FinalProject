﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class XLSHandler
    {
        enum XLSCol { Chrom = 0, Position, GeneSym, TargetID, Type, Zygosity, Ref, Variant, VarFreq, PValue, Coverage, RefCov, VarCov };

        private List<Mutation> _nonCosmicMutation;
        private List<Mutation> _cosmicMutation;
        string _xlsPath;
        public XLSHandler(string xlsPath)
        {
            _nonCosmicMutation = new List<Mutation>();
            _cosmicMutation = new List<Mutation>();
            _xlsPath = xlsPath;
        }

        public void handle()
        {
            StreamReader xlsStream = new StreamReader(_xlsPath);
            xlsStream.ReadLine();
            while (xlsStream.Peek() >= 0)
            {
                string[] lineParts = xlsStream.ReadLine().Split('\t');
                string chrom = lineParts[(int)XLSCol.Chrom];
                int position = Convert.ToInt32(lineParts[(int)XLSCol.Position]);
                string geneSym = lineParts[(int)XLSCol.GeneSym];
                string mutType = lineParts[(int)XLSCol.Type];
                char refNuc = Convert.ToChar(lineParts[(int)XLSCol.Ref]);
                char varNuc = Convert.ToChar(lineParts[(int)XLSCol.Variant]);

                Mutation m = new Mutation(chrom,position,geneSym,mutType,refNuc,varNuc);
                if (m.isImportant())
                    _cosmicMutation.Add(m);
                else
                    _nonCosmicMutation.Add(m);
            }

            xlsStream.Close();
        }
        public override string ToString()
        {
            string toReturn = "";
            foreach (Mutation m in _nonCosmicMutation)
                toReturn += m.ToString() + "\n";
            return toReturn;

        }
        public List<Mutation> NonCosmicMutation
        {
            get
            {
                return _nonCosmicMutation;
            }
        }
        public List<Mutation> CosmicMutation
        {
            get
            {
                return _cosmicMutation;
            }
        }

    }
}
