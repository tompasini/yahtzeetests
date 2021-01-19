using Xunit;
using YahtzeeScorer;

namespace YahtzeeTests
{
    public class Tests
    {

        //Score by number tests
        [Fact]
        public void Score_By_Number_Returns_30_Given_Five_Sixes()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 6, 6, 6, 6, 6 };
            int expectedScore = 30;
            int actualScore = scorer.ScoreByNumber(dice, 6);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 3, 4 }, 1, 3)]
        [InlineData(new int[] { 2, 2, 2, }, 2, 0)]
        [InlineData(new int[] { 3, 3, 1, 6, 3 }, 3, 9)]
        public void Score_By_Number(int[] dice, int chosenNum, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreByNumber(dice, chosenNum);
            Assert.Equal(expectedScore, actualScore);
        }

        //Three of a Kind tests

        [Fact]
        public void Three_Of_A_Kind_Returns_12_Given_Three_Fours()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 1, 2, 4, 4, 4 };
            int expectedScore = 12;
            int actualScore = scorer.ThreeOfAKind(dice, 4);
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Three_Of_A_Kind_Returns_0_Given_Two_Fours()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 1, 2, 3, 4, 4 };
            int expectedScore = 0;
            int actualScore = scorer.ThreeOfAKind(dice, 4);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 3, 4 }, 1, 3)]
        [InlineData(new int[] { 2, 2, 2, }, 2, 0)]
        [InlineData(new int[] { 2, 2, 3, 5, 6 }, 2, 0)]
        [InlineData(new int[] { 3, 3, 3, 3, 3 }, 3, 9)]
        public void Three_Of_A_Kind(int[] dice, int chosenNum, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ThreeOfAKind(dice, chosenNum);
            Assert.Equal(expectedScore, actualScore);
        }

        //Four of a kind tests.

        [Fact]
        public void Four_Of_A_Kind_Returns_16_Given_Four_Fours()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 1, 4, 4, 4, 4 };
            int expectedScore = 16;
            int actualScore = scorer.FourOfAKind(dice, 4);
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Four_Of_A_Kind_Returns_0_Given_Two_Fours()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 1, 2, 3, 4, 4 };
            int expectedScore = 0;
            int actualScore = scorer.ThreeOfAKind(dice, 4);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 1, 4 }, 1, 4)]
        [InlineData(new int[] { 2, 2, 2, }, 2, 0)]
        [InlineData(new int[] { 2, 2, 2, 5, 6 }, 2, 0)]
        [InlineData(new int[] { 3, 3, 3, 3, 3 }, 3, 12)]
        public void Four_Of_A_Kind(int[] dice, int chosenNum, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.FourOfAKind(dice, chosenNum);
            Assert.Equal(expectedScore, actualScore);
        }

        //Full House tests

        [Fact]
        public void Full_House_25_Given_Three_Threes_And_Two_Fours()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 3, 3, 3, 4, 4 };
            int expectedScore = 25;
            int actualScore = scorer.FullHouse(dice, 3, 4);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 4, 4 }, 1, 4, 25)]
        [InlineData(new int[] { 2, 2, 2, }, 2, 3, 0)]
        [InlineData(new int[] { 2, 2, 2, 5, 6 }, 2, 5, 0)]
        [InlineData(new int[] { 5, 5, 6, 6, 6 }, 5, 6, 25)]
        public void Full_House(int[] dice, int chosenNum1, int choseNum2, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.FullHouse(dice, chosenNum1, choseNum2);
            Assert.Equal(expectedScore, actualScore);
        }

        //Small Straight tests

        [Fact]
        public void Small_Straight_Given_One_Through_Four()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 1, 2, 3, 4, 1 };
            int expectedSctore = 30;
            int actualScore = scorer.SmallStraight(dice);
            Assert.Equal(expectedSctore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 30)]
        [InlineData(new int[] { 2, 2, 2, }, 0)]
        [InlineData(new int[] { 1, 2, 3, 4, 1 }, 30)]
        [InlineData(new int[] { 2, 3, 4, 5, 5 }, 30)]
        [InlineData(new int[] { 3, 4, 6, 5, 6 }, 30)]
        [InlineData(new int[] { 1, 2, 3, 5, 5 }, 0)]
        public void Small_Straight(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.SmallStraight(dice);
            Assert.Equal(expectedScore, actualScore);
        }
    }
}
