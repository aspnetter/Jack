using System.ComponentModel;

namespace YocoJack
{
    //S > H > C > D
    public enum CardSuite
    {
        [Description("Diamonds")]
        D = 1,
        [Description("Clubs")]
        C = 2,
        [Description("Hearts")]
        H = 3,
        [Description("Spades")]
        S = 4
    }
}
