using System;
using System.Diagnostics;

namespace SbrfLibrary
{
    public static class Sbrf
    {
        /// <summary>
        /// Проведение сверки итогов
        /// </summary>
        /// <returns>Результат операции</returns>
        public static InfoResult Check()
        {
            return GetMajorVersionSbrfDll() >= 32 ? Sbrf32.Check() : Sbrf31.Check();
        }
        /// <summary>
        /// Получение кратного отчета
        /// </summary>
        /// <returns>Результат</returns>
        public static InfoResult ShortReport()
        {
            return GetMajorVersionSbrfDll() >= 32 ? Sbrf32.ShortReport() : Sbrf31.ShortReport();
        }
        /// <summary>
        /// Получене полного отчета
        /// </summary>
        /// <returns>Результат операции</returns>
        public static InfoResult Report()
        {
            return GetMajorVersionSbrfDll() >= 32 ? Sbrf32.Report() : Sbrf31.Report();
        }
        /// <summary>
        /// Возврат чека
        /// </summary>
        /// <param name="sum">Сумма чека</param>
        /// <returns>Результат операции</returns>
        public static InfoResult ReturnPayment(decimal sum)
        {
            return GetMajorVersionSbrfDll() >= 32 ? Sbrf32.ReturnPayment(sum) : Sbrf31.ReturnPayment(sum);
        }
        /// <summary>
        /// Отмена чека в текущей смене
        /// </summary>
        /// <param name="RRN">Номер ссылки</param>
        /// <returns>Результат операции</returns>
        public static InfoResult Void(string RRN)
        {
            return GetMajorVersionSbrfDll() >= 32 ? Sbrf32.Void(RRN) : Sbrf31.Void(RRN);
        }
        /// <summary>
        /// Оплата чека
        /// </summary>
        /// <param name="amount">Сумма к оплате</param>
        /// <returns>Результат операции</returns>
        public static InfoResult Pay(decimal amount)
        {
            return GetMajorVersionSbrfDll() >= 32 ? Sbrf32.Pay(amount) : Sbrf31.Pay(amount);
        }

        private static int GetMajorVersionSbrfDll()
        {
            try
            {
                using (Microsoft.Win32.RegistryKey classesRootKey = Microsoft.Win32.RegistryKey.OpenBaseKey(
                     Microsoft.Win32.RegistryHive.ClassesRoot, Microsoft.Win32.RegistryView.Default))
                {
                    const string clsid = "{2DB7F353-0A33-4263-AACE-1CEA09D8C0EF}";

                    Microsoft.Win32.RegistryKey clsIdKey = classesRootKey.OpenSubKey(@"Wow6432Node\CLSID\" + clsid + "\\InprocServer32") ??
                                    classesRootKey.OpenSubKey(@"CLSID\" + clsid + "\\InprocServer32");

                    if (clsIdKey != null)
                    {
                        object path = clsIdKey.GetValue("");
                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(path.ToString());
                        int majorVersion = myFileVersionInfo.FileMajorPart;
                        clsIdKey.Dispose();
                        return majorVersion;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }
    }
}
