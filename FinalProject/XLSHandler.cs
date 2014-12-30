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
        List<Mutation> _mutationList;
        string _xlsPath;
        public XLSHandler(string xlsPath)
        {
            _mutationList = new List<Mutation>();
            _xlsPath = xlsPath;
        }

        public void handle()
        {
            StreamReader xlsStream = new StreamReader(_xlsPath);
            xlsStream.ReadLine();
            while (xlsStream.Peek() >= 0)
            {
                Mutation m = new Mutation(xlsStream.ReadLine().Split('\t'));
                if (m.isSNP() && m.isMutataion() && m.hasCodon() && m.hasCosmicName())
                {
                    _mutationList.Add(m);
                }
            }
            xlsStream.Close();
        }
        public override string ToString()
        {
            string toReturn = "";
            foreach (Mutation m in _mutationList)
                toReturn += m.ToString() + "\n";
            return toReturn;

        }
    }
}
