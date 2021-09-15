namespace SbrfLibrary
{
	public class Result
	{
		/// <summary>
		/// Номер карты клиента
		/// </summary>
		public string ClientCard { get; set; }
		/// <summary>
		/// Состояние результата
		/// </summary>
		public bool Success { get; set; }
		/// <summary>
		/// Код ошибки
		/// </summary>
		public int ErrorCode { get; set; }
		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		public string ErrorMessage { get; set; }
		/// <summary>
		///  Чек операции в кодировке CP866;
		/// </summary>
		public string Cheque { get; set; }
		/// <summary>
		/// Номер ссылки 
		/// </summary>
		public string RRN { get; set; }
		/// <summary>
		/// Хэш–значение номера карты
		/// </summary>
		public string Hash { get; set; }
		/// <summary>
		/// Тип карты 
		/// </summary>
		public string CardType { get; set; }
		/// <summary>
		/// Номер терминала
		/// </summary>
		public string TerminalNumber { get; set; }

		public override string ToString() => string.Format("Success: {0}. Error code {1}, message: {2}. Check: {3}. RRN: {4}. Hash: {5}. Card: {6}", Success, ErrorCode, ErrorMessage ?? "", Cheque ?? "", RRN ?? "", Hash ?? "", ClientCard ?? "");
	}
}
