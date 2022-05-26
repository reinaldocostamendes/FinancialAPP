using System;

namespace CashBook_API_Client.Options
{
    public class CashBookOptions
    {
        private string _baseAddress;

        public string BaseAddress
        {
            get
            {
                return _baseAddress ?? throw new InvalidOperationException("Base Address API Financeiro must be setted.");
            }
            set { _baseAddress = value; }
        }

        private string _cashBookPostEndPoint;

        public string CashBookPostEndPoint
        {
            get
            {
                return _cashBookPostEndPoint ?? throw new InvalidOperationException("Cash Bank EndPoint must be setted.");
            }
            set { _cashBookPostEndPoint = value; }
        }

        public string GetCashBookEndPoint() => $"{BaseAddress}/{CashBookPostEndPoint}";
    }
}