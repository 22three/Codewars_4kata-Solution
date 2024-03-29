﻿using System.ComponentModel.DataAnnotations;
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
            int expectedrank = user.getRank();
            int appliedrank = -8;
            user.progress = 0;           
            user.incProgress(appliedrank);
            Console.WriteLine($"Applied Rank: {appliedrank} \nExpected Rank: {expectedrank} \nActual: {user.getRank()} \nProgress: {user.getProgress()}");
        }
    }

    public class User
    {
        public int rank;
        public int progress;
        public User()
        {
            this.rank = -8;
            this.progress = 0;
        }
        public int getRank() {
            return rank;
        }
        public int getProgress()
        {
            return progress;
        }
        public void incProgress(int actRank)
        {
            if (rank == 8)
                return;

            if (actRank > 8 || actRank < -8 || actRank == 0)
                throw new ArgumentException("Invalid activity rank");

            int diff = -1;

            if (rank < 0 && actRank < 0 || rank > 0 && actRank > 0)
                diff = actRank - rank;
            else if (rank < 0 && actRank > 0)
                diff = (actRank - rank) - 1;

            if (diff == 0)
                progress += 3;
            else if (diff < 0)
                progress += 1;
            else
                progress += 10 * diff * diff;

            if (progress >= 100 && rank < 8)
                rankUP();
        }
        public void rankUP()
        {
            while (progress >= 100)
            {
                progress -= 100;
                rank++;
                if (rank == 0)
                    rank++;
                
            }

            if (rank == 8)
                progress = 0;
        }
    }
}
