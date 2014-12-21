using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class XLSHandler
    {
        List<SNPMutation> _mutationList;
        public XLSHandler(string xlsPath)
        {
            _mutationList = new List<SNPMutation>();
            StreamReader xlsStream = new StreamReader(xlsPath);
            while (xlsStream.Peek() >= 0)
            {
                string[] xlsLine = xlsStream.ReadLine().Split('\t');
                SNPMutation m = new SNPMutation(xlsLine);
                if (m.isSNP())
                    _mutationList.Add(m);
            }
            xlsStream.Close();
        }





    }
}
