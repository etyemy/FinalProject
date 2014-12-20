using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class FastaHandler
    {

        private LinkedList<Gene> _geneList;
        public FastaHandler(string fastaPath)
        {
            _geneList = new LinkedList<Gene>();
            StreamReader fastaStream = new StreamReader(fastaPath);
            while (fastaStream.Peek() >= 0)
            {
                string fastaLine = fastaStream.ReadLine();
                if (fastaLine.Length > 0)
                    if (fastaLine[0].Equals('>'))
                    {
                        string[] parts = fastaLine.Split(' ');
                        string geneSeq = "";
                        fastaLine = fastaStream.ReadLine();
                        while(fastaLine.Length!=0)
                        {
                            geneSeq += fastaLine;
                            fastaLine = fastaStream.ReadLine();
                        }
                        string geneName = parts[0].Split('>')[1];
                        string geneInfo = parts[1];
                        string geneChrom="";
                        string geneStartPos="";
                        string geneEndtPos = "";
                        string geneDirection = "";
                        if(parts.Length!=2)
                        {
                            string[] details = parts[2].Split(':', '(', ')');
                            geneChrom = details[0];
                            string[] startEnd = details[1].Split('-');
                            geneStartPos = startEnd[0];
                            geneEndtPos = startEnd[1];
                            geneDirection = details[2];
                        }
                        
                        Gene g = new Gene(geneName,geneInfo,geneChrom,geneStartPos,geneEndtPos,geneDirection,geneSeq);
                        _geneList.AddLast(g);
                        
                    }
            }
            fastaStream.Close();

        }



    }
}
