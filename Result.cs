namespace SbrfLibrary
{
	public class Result
	{
		public string ClientCard { get; set; }

		public bool Success { get; set; }

		public int ErrorCode { get; set; }

		public string ErrorMessage { get; set; }

		public string Cheque { get; set; }

		public string RRN { get; set; }

		public string Card { get; set; }

		public string Hash { get; set; }

		public string CardType { get; set; }

		public override string ToString() => string.Format("Success: {0}. Error code {1}, message: {2}. Check: {3}. RRN: {4}. Hash: {5}. Card: {6}", Success, ErrorCode, ErrorMessage ?? "", Cheque ?? "", RRN ?? "", Hash ?? "", Card ?? "");
	}
}
