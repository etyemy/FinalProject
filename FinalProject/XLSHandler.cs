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
        List<Gene> _geneList;
        public XLSHandler(string xlsPath)
        {
            Console.WriteLine("Start!!!!!!!");
            RefGeneDAL rgd=new RefGeneDAL();
            _mutationList = new List<SNPMutation>();
            _geneList = new List<Gene>();
            StreamReader xlsStream = new StreamReader(xlsPath);
            while (xlsStream.Peek() >= 0)
            {
                string[] xlsLine = xlsStream.ReadLine().Split('\t');
                SNPMutation m = new SNPMutation(xlsLine);
                if (m.isSNP())
                { 
                    _mutationList.Add(m);
                    if(!geneInList(m.Chrom, m.GeneSym))
                    {
                        Gene g = rgd.getGene(m.Chrom, m.GeneSym);
                        _geneList.Add(g);
                        Console.WriteLine("Gene Added to List "+m.Chrom+" !!!!!!!");
                    }
                    
                }
            }
            Console.WriteLine("End!!!!!!!");
            /////////////



            ////////////
            xlsStream.Close();
        }

        private bool geneInList(string chrom, string geneSym)
        {
            foreach(Gene g in _geneList)
            {
                if (g.Crhom.Equals(chrom) && g.Name2.Equals(geneSym))
                    return true;
            }
            return false;
        }





    }
}
