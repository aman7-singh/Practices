using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<comicbook> comics = new List<comicbook>
            {
                new comicbook{Name="shaktiman", IssueBy="kilvish", price=10 },
                new comicbook{Name="nagraj", IssueBy="evil", price=11 },
                new comicbook{Name="HeMan", IssueBy="skeleton", price=10 },
                new comicbook{Name="juniorJi", IssueBy="evil", price=10 }
            };
            List<PurchageBook> purchages = new List<PurchageBook>
            {
                new PurchageBook{Name="shaktiman", IssueBy="kilvish", price=110 },
                new PurchageBook{Name="nagraj", IssueBy="evil", price=11 },
                new PurchageBook{Name="juniorJi", IssueBy="evil", price=12 }
            };
            var res = from comic in comics
                      join purchage in purchages
                      on comic.Name equals purchage.Name
                      //group comic by comic.price
                      //into newcomic
                      //orderby newcomic.Key ascending
                      //select newcomic;
                      select new { comic.Name, purchage.price };
            var obj = res.ToList();
        }
    }
    public class comicbook
    {
        public string Name { get; set; }
        public string IssueBy { get; set; }
        public int price { get; set; }
    }
    public class PurchageBook
    {
        public string Name { get; set; }
        public string IssueBy { get; set; }
        public int price { get; set; }
    }
}
