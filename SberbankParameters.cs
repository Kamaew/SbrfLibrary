namespace SbrfLibrary
{
    public static class SberbankParameters
    {
        /// <summary>
		/// Тип карты 
		/// </summary>
        public const string CardType = "CardType";
        /// <summary>
        /// Название карты (Visa, Maestro и т.д.)
        /// </summary>
        public const string CardName = "CardName";
        /// <summary>
        /// Дата операции  (ДД.ММ.ГГГГ)
        /// </summary>
        public const string TransactionDate = "TrxDate";
        /// <summary>
        /// Время операции (ЧЧ:ММ:СС)
        /// </summary>
        public const string TransactionTime = "TrxTime";
        /// <summary>
		/// Номер терминала
		/// </summary>
        public const string TerminalNumber = "TermNum";
        /// <summary>
		/// Номер карты клиента
		/// </summary>
        public const string ClientCard = "ClientCard";
        /// <summary>
        /// Срок действия карты клиента 
        /// </summary>
        public const string ClientExpiryDate = "ClientExpiryDate";

        public const string Hash = "Hash";
        /// <summary>
        /// Признак карты Сбербанка (0 - карты других банков, 128 - карты Сбербанка, 64 – карты дочерних банков) 
        /// </summary>
        public const string OwnCard = "OwnCard";
        /// <summary>
        /// Образ экранной подписи для функции 5005.
        /// </summary>
        public const string CardLSData = "CardLSData";
        /// <summary>
        /// Строка, введенная клиентом для функции 5007
        /// </summary>
        public const string OutText = "OutText";
        /// <summary>
        /// Признак принадлежности карты настроенным в конфигурационном файле программа лояльности
        /// </summary>
        public const string LoyaltyIdentifier = "LoyaltyIdentifier";
        /// <summary>
        /// Сумма операции с учетом комиссии / скидки
        /// </summary>
        public const string Amount = "Amount";
        /// <summary>
		/// Номер ссылки 
		/// </summary>
        public const string RRN = "RRN";
        /// <summary>
        /// 2-я дорожка карты, если пустая - считывается библиотекой
        /// </summary>
        public const string Track2 = "Track2";
        /// <summary>
        ///  Чек операции в кодировке CP866;
        /// </summary>
        public const string Cheque = "Cheque";
        /// <summary>
        ///  Чек операции в кодировке CP1251
        /// </summary>
        public const string Cheque1251 = "Cheque1251";
        /// <summary>
        /// Порядковый номер отдела (от 0 до 14 или 255).
        /// Если задан номер отдела 255, то после прокатки  карты в интерфейсе терминала будет выведен диалог для выбора отдела из списка загруженных.
        /// Если номер отдела превышает количество настроенных отделов, то терминал вернет ошибку 4191.
        /// </summary>
        public const string Department = "Department";
        /// <summary>
        /// Код авторизации
        /// </summary>
        public const string AuthCode = "AuthCode";
        /// <summary>
        /// Номер транзакции в пакете терминала
        /// </summary>
        public const string MerchantTSN = "MerchantTSN";
        /// <summary>
        /// Номер пакета терминала по магн.картам
        /// </summary>
        public const string MerchantBatchNum = "MerchantBatchNum";
        /// <summary>
        /// сумма операции без учета комиссии / скидки
        /// </summary>
        public const string AmountClear = "AmountClear";
        /// <summary>
        /// Номер мерчанта
        /// </summary>
        public const string MerchNum = "MerchNum";
    }
}
