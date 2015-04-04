using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class TSVHandler
    {
        private List<Article> _allArticles;
        enum TSVCol { Title = 0, Author, Year, Journal, Status, CosmicID, PubmedID };
        public TSVHandler(string tsvString)
        {
            _allArticles = new List<Article>();
            string[] lines = tsvString.Split('\n');
            for(int i=1;i<lines.Length-1;i++)
            {
                string[] lineParts = lines[i].Split('\t');
                string title = lineParts[(int)TSVCol.Title];
                string author = lineParts[(int)TSVCol.Author];
                int year = Convert.ToInt32(lineParts[(int)TSVCol.Year]);
                string journal = lineParts[(int)TSVCol.Journal];
                string cosmicId = lineParts[(int)TSVCol.CosmicID];
                string pubmedId = lineParts[(int)TSVCol.PubmedID];
                Article article = new Article(title, author, year, journal, cosmicId, pubmedId);
                _allArticles.Add(article);
            }
        }
        public List<Article> AllArticles
        {
            get
            {
                return new List<Article>(_allArticles);
            }
        }
    }
}
