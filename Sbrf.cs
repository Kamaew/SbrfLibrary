using SbrfLibrary.SBRFSRV;
using System;
using System.Runtime.InteropServices;

namespace SbrfLibrary
{
    public static class Sbrf
    {
        private static readonly Server server = (Server)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("2DB7F353-0A33-4263-AACE-1CEA09D8C0EF")));
        public static Result Check()
        {
            int result = server.NFun((int)SberbankOperations.Verification);
            return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при сверке");
        }
        public static Result ShortReport()
        {
            int result = server.NFun((int)SberbankOperations.ShortReport);
            return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при кратком отчете");
        }
        public static Result Report()
        {
            int result = server.NFun((int)SberbankOperations.Report);
            return result.Equals(SberbankReturnCodes.OK) ? ReturnOK() : ReturnError(result, "Ошибка при отчете");
        }
        public static Result ReturnPayment(decimal sum)
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
        public static Result Void(string RRN)
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

        public static Result Pay(decimal amount)
        {
            Result res = new Result();
            try
            {
                server.SParam(SberbankParameters.Amount, (int)(amount * 100m));

                int result = server.NFun((int)SberbankOperations.Pay);

                if (result == SberbankReturnCodes.Break)
                {
                    res.RRN = server.GParamString(SberbankParameters.RRN);
                    InfoResult infoResult = new InfoResult
                    {
                        CardName = server.GParamString(SberbankParameters.CardName),
                        CardType = server.GParamString(SberbankParameters.CardType),
                        TrxDate = server.GParamString(SberbankParameters.TransactionDate),
                        TrxTime = server.GParamString(SberbankParameters.TransactionTime),
                        TermNum = server.GParamString(SberbankParameters.TerminalNumber),
                        ClientCard = server.GParamString(SberbankParameters.ClientCard),
                        ClientExpiryDate = server.GParamString(SberbankParameters.ClientExpiryDate),
                        Hash = server.GParamString(SberbankParameters.Hash),
                        OwnCard = server.GParamString(SberbankParameters.OwnCard),
                        CardData = server.GParamString(SberbankParameters.CardData),
                        CardLSData = server.GParamString(SberbankParameters.CardLSData),
                        OutText = server.GParamString(SberbankParameters.OutText),
                        LoyaltyIdentifier = server.GParamString(SberbankParameters.LoyaltyIdentifier)
                    };
                    res.ClientCard = infoResult.ClientCard;
                    res.TerminalNumber = infoResult.TermNum;
                    res.CardType = infoResult.CardType;
                    res.Hash = infoResult.Hash;
                    res.Card = infoResult.Card;
                    res.Success = true;
                    res.ErrorCode = result;
                    return res;
                }

                if (result != SberbankReturnCodes.OK)
                {
                    return ReturnError(result, "Ошибка при оплате");
                }
                

                res.Success = true;
                res.Hash = server.GParamString(SberbankParameters.Hash);
                res.Card = server.GParamString(SberbankParameters.ClientCard);
                res.ErrorCode = SberbankReturnCodes.OK;
                res.Cheque = server.GParamString(SberbankParameters.Cheque);
                res.TerminalNumber = server.GParamString(SberbankParameters.TerminalNumber);
                res.RRN = server.GParamString(SberbankParameters.RRN);
                return res;
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        private static Result ReturnException(Exception ex)
        {
            Result res = new Result
            {
                Success = false,
                ErrorMessage = ex.ToString(),
                ErrorCode = -1
            };
            return res;
        }
        private static Result ReturnError(int result, string message)
        {
            Result res = new Result
            {
                Success = false,
                ErrorCode = result,
                ErrorMessage = message
            };
            return res;
        }
        private static Result ReturnOK()
        {
            Result res = new Result
            {
                Success = true,
                Cheque = server.GParamString(SberbankParameters.Cheque),
                Card = server.GParamString(SberbankParameters.ClientCard),
                RRN = server.GParamString(SberbankParameters.RRN)
            };

            return res;
        }
    }
}
