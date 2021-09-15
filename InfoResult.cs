namespace SbrfLibrary
{
    public class InfoResult : Result
    {
        /// <summary>
        /// Название карты (Visa, Maestro и т.д.)
        /// </summary>
        public string CardName { get; set; }
        /// <summary>
        /// Дата операции  (ДД.ММ.ГГГГ)
        /// </summary>
        public string TrxDate { get; set; }
        /// <summary>
        /// Время операции (ЧЧ:ММ:СС)
        /// </summary>
        public string TrxTime { get; set; }
        /// <summary>
        /// Срок действия карты клиента 
        /// </summary>
        public string ClientExpiryDate { get; set; }
        /// <summary>
        /// Признак карты Сбербанка (0 - карты других банков, 128 - карты Сбербанка, 64 – карты дочерних банков) 
        /// </summary>
        public string OwnCard { get; set; }
        /// <summary>
        /// Образ экранной подписи для функции 5005.
        /// </summary>
        public string CardLSData { get; set; }
        /// <summary>
        /// Строка, введенная клиентом для функции 5007
        /// </summary>
        public string OutText { get; set; }
        /// <summary>
        /// Признак принадлежности карты настроенным в конфигурационном файле программа лояльности
        /// </summary>
        public string LoyaltyIdentifier { get; set; }
        /// <summary>
        /// Код авторизации
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// Номер транзакции в пакете терминала
        /// </summary>
        public string MerchantTSN { get; internal set; }
        /// <summary>
        /// Номер пакета терминала по магн.картам
        /// </summary>
        public string MerchantBatchNum { get; internal set; }
        /// <summary>
        /// Сумма операции с учетом комиссии / скидки
        /// </summary>
        public string Amount { get; internal set; }
        /// <summary>
        /// сумма операции без учета комиссии / скидки
        /// </summary>
        public string AmountClear { get; internal set; }
        /// <summary>
        /// Номер мерчанта
        /// </summary>
        public string MerchNum { get; internal set; }
        /// <summary>
        /// Идентификатор приложения COMPLETE APPLICATION IDENTIFIERS (AID)
        /// https://www.eftlab.com/knowledge-base/211-emv-aid-rid-pix/
        /// </summary>
        public string AID { get; internal set; }

    }
}
