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
        string _xlsPath;
        public XLSHandler(string xlsPath)
        {
            Console.WriteLine("Start!!!!!!!");
            _mutationList = new List<SNPMutation>();
            _xlsPath = xlsPath;
        }

        public void handle()
        {
            StreamReader xlsStream = new StreamReader(_xlsPath);
            xlsStream.ReadLine();
            while (xlsStream.Peek() >= 0)
            {
                SNPMutation m = new SNPMutation(xlsStream.ReadLine().Split('\t'));
                if (m.isSNP() && m.isMutataion() && m.hasCodon())
                {
                    _mutationList.Add(m);
                }
            }
            xlsStream.Close();
        }
        public override string ToString()
        {
            string toReturn = "";
            foreach (SNPMutation m in _mutationList)
                toReturn += m.ToString() + "\n";
            return toReturn;

        }
    }
}
