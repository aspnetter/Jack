using System.ComponentModel;

namespace YocoJack
{
    public enum CardRankType
    {
        [Description("Any number")]
        Number = 1,
        [Description("Joker")]
        J = 2,
        [Description("Queen")]
        Q = 3,
        [Description("King")]
        K = 4,
        [Description("Ace")]
        A = 5
    }
}
