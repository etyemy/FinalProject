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
        List<Mutation> _mutationList;
        public XLSHandler(string xlsPath)
        {
            _mutationList = new List<Mutation>();
            StreamReader xlsStream = new StreamReader(xlsPath);
            while (xlsStream.Peek() >= 0)
            {
                string[] xlsLine = xlsStream.ReadLine().Split('\t');
                Mutation m = new Mutation(xlsLine);
                if (m.Type.Equals("SNP"))
                    _mutationList.Add(m);
            }
            xlsStream.Close();
        }





    }
}
