namespace SbrfLibrary
{
    public class InfoResult : Result
    {
        public string CardName { get; set; }

        public new string CardType { get; set; }

        public string TrxDate { get; set; }

        public string TrxTime { get; set; }

        public string TermNum { get; set; }

        public new string ClientCard { get; set; }

        public string ClientExpiryDate { get; set; }

        public new string Hash { get; set; }

        public string OwnCard { get; set; }

        public string CardData { get; set; }

        public string CardLSData { get; set; }

        public string OutText { get; set; }

        public string LoyaltyIdentifier { get; set; }
    }
}
