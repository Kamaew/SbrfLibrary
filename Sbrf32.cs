using SbrfLibrary.SBRFSRV;
using System;
using System.Runtime.InteropServices;

namespace SbrfLibrary
{
    internal static class Sbrf32
    {
        private static readonly Server32 server = (Server32)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("2DB7F353-0A33-4263-AACE-1CEA09D8C0EF")));
        /// <summary>
        /// Проведение сверки итогов
        /// </summary>
        /// <returns>Результат операции</returns>
        public static InfoResult Check()
        {
            int result = server.NFun((int)SberbankOperations.Verification);
            return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при сверке");
        }
        /// <summary>
        /// Получение кратного отчета
        /// </summary>
        /// <returns>Результат</returns>
        public static InfoResult ShortReport()
        {
            int result = server.NFun((int)SberbankOperations.ShortReport);
            return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при кратком отчете");
        }
        /// <summary>
        /// Получене полного отчета
        /// </summary>
        /// <returns>Результат операции</returns>
        public static InfoResult Report()
        {
            int result = server.NFun((int)SberbankOperations.Report);
            return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при отчете");
        }
        /// <summary>
        /// Возврат чека
        /// </summary>
        /// <param name="sum">Сумма чека</param>
        /// <returns>Результат операции</returns>
        public static InfoResult ReturnPayment(decimal sum)
        {
            try
            {
                server.SParam(SberbankParameters.Amount, (int)(sum * 100m));
                int result = server.NFun((int)SberbankOperations.ReturnPayment);
                return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при возврате");
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        /// <summary>
        /// Отмена чека в текущей смене
        /// </summary>
        /// <param name="RRN">Номер ссылки</param>
        /// <returns>Результат операции</returns>
        public static InfoResult Void(string RRN)
        {
            try
            {
                server.SParam(SberbankParameters.Amount, 0);
                server.SParam(SberbankParameters.RRN, RRN);
                server.SParam(SberbankParameters.Track2, "QSELECT");
                int result = server.NFun((int)SberbankOperations.Void);
                return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при отмене операции");
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        /// <summary>
        /// Оплата чека
        /// </summary>
        /// <param name="amount">Сумма к оплате</param>
        /// <returns>Результат операции</returns>
        public static InfoResult Pay(decimal amount)
        {
            try
            {
                server.SParam(SberbankParameters.Amount, (int)(amount * 100m));
                int result = server.NFun((int)SberbankOperations.Pay);

                if (result != SberbankReturnCodes.OK)
                {
                    return ReturnError(result, "Ошибка при оплате");
                }

                InfoResult infoResult = new InfoResult
                {
                    CardName = server.GParamString(SberbankParameters.CardName),
                    CardType = server.GParamString(SberbankParameters.CardType),
                    TrxDate = server.GParamString(SberbankParameters.TransactionDate),
                    TrxTime = server.GParamString(SberbankParameters.TransactionTime),
                    TerminalNumber = server.GParamString(SberbankParameters.TerminalNumber),
                    ClientCard = server.GParamString(SberbankParameters.ClientCard),
                    ClientExpiryDate = server.GParamString(SberbankParameters.ClientExpiryDate),
                    Hash = server.GParamString(SberbankParameters.Hash),
                    OwnCard = server.GParamString(SberbankParameters.OwnCard),
                    CardLSData = server.GParamString(SberbankParameters.CardLSData),
                    OutText = server.GParamString(SberbankParameters.OutText),
                    LoyaltyIdentifier = server.GParamString(SberbankParameters.LoyaltyIdentifier),
                    AuthCode = server.GParamString(SberbankParameters.AuthCode),
                    MerchantTSN = server.GParamString(SberbankParameters.MerchantTSN),
                    MerchantBatchNum = server.GParamString(SberbankParameters.MerchantBatchNum),
                    Amount = server.GParamString(SberbankParameters.Amount),
                    AmountClear = server.GParamString(SberbankParameters.AmountClear),
                    MerchNum = server.GParamString(SberbankParameters.MerchNum),

                    Success = true,
                    ErrorCode = SberbankReturnCodes.OK,
                    Cheque = server.GParamString(SberbankParameters.Cheque),
                    RRN = server.GParamString(SberbankParameters.RRN),
                    AID = server.GParamString(SberbankParameters.AID)
                };
                infoResult.ParseAID = GetAIDByCheque(infoResult.Cheque);
                return infoResult;
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        private static InfoResult ReturnException(Exception ex)
        {
            InfoResult res = new InfoResult
            {
                Success = false,
                ErrorMessage = ex.ToString(),
                ErrorCode = -1
            };
            return res;
        }
        private static InfoResult ReturnError(int result, string message)
        {
            InfoResult res = new InfoResult
            {
                Success = false,
                ErrorCode = result,
                ErrorMessage = message
            };
            return res;
        }
        private static InfoResult ReturnOK()
        {
            InfoResult res = new InfoResult
            {
                Success = true,
                Cheque = server.GParamString(SberbankParameters.Cheque),
                ClientCard = server.GParamString(SberbankParameters.ClientCard),
                RRN = server.GParamString(SberbankParameters.RRN)
            };

            return res;
        }
        private static string GetAIDByCheque(string sbrfCheque)
        {
            string[] list = sbrfCheque.Replace("\r\n", " ").Split(' ');
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].StartsWith("Карта"))
                {
                    return list[i - 1];
                }
            }
            return "";
        }
    }
}
