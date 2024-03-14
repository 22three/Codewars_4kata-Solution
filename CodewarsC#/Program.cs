using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Codewars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            int expectedrank = -8;
            int appliedrank = -7;
            user.rank = expectedrank;
            user.progress = 0;           
            user.incProgress(appliedrank);
            Console.WriteLine($"Applied Rank: {appliedrank} \nExpected Rank: {expectedrank} \nActual: {user.rank} \nProgress: {user.progress}");
        }
    }

    public class User
    {
        public int rank;
        public int progress;
        public int[] incProgress(int actRank)
        {
            if (actRank > 8 || actRank < -8 || actRank == 0)
                throw new ArgumentException();
            int _rank = actRank - rank;   
            if (actRank >= 1)
                _rank--;
            if (_rank == 0)
                progress += 3;
            else
            progress = 10 * _rank * _rank;
            if (progress >= 100)
                rankUP();
            return [rank,progress];
        }
        public void rankUP()
        {
            if (rank<8)
            while (progress >= 100)
            {
                rank++;
                progress -= 100;
            }
        }
    }
}
