namespace TestProject1
{
    using Codewars;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        public void assertRankProgression(int rank, User user, int expRank, int expProgress)
        {
            Assert.True(user.getRank() == expRank,
              "Applied Rank: " + rank +
              "; Expected rank: " + expRank +
              "; Actual: " + user.getRank());

            Assert.True(user.getProgress() == expProgress,
              "Applied Rank; " + rank +
              "; Expected progress: " + expProgress +
              ", Actual: " + user.getProgress());
        }

        [TestCase(-7, -8, 10)]
        [TestCase(-6, -8, 40)]
        [TestCase(-5, -8, 90)]
        [TestCase(-4, -7, 60)]
        [TestCase(-8, -8, 3)]
        // Check single increments
        public void testValidSingleRankProgression(int rank, int expectedRank, int expectedProgress)
        {
            User user = new User();
            user.incProgress(rank);
            assertRankProgression(rank, user, expectedRank, expectedProgress);
        }

        [TestCase(9)]
        [TestCase(-9)]
        [TestCase(0)]
        // Check invalid rank progressions
        public void testInvalidRange(int rank)
        {
            User user = new User();
            Assert.Throws<ArgumentException>(() => user.incProgress(rank));
        }
    }
}