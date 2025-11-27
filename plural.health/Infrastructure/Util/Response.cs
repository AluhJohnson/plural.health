namespace plural.health.Infractures.Util
{
    public class Response<T>
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public T? Data { get; set; }
    }

    public class ResponseStatusCode
    {
        public string SUCCESS { get; set; } = "200";
        public string PENDING { get; set; } = "02";
        public string FAILED { get; set; } = "401";
        public string NOBVNLINKED { get; set; } = "03";
        public string INACTIVE { get; set; } = "04";
        public string INSUFFICIENTFUND { get; set; } = "05";
        public string NORECORDFOUND { get; set; } = "601";
        public string INCOMPLETEPROCESS { get; set; } = "07";
        public string USERROLEFAILED{ get; set; } = "08";
        public string INVALIDACCOUNTNUMBER { get; set; } = "09";
        public string BADREQUEST { get; set; } = "001";
        public string EXCEPTIONOCCOURED { get; set; } = "002";
        public string NOTQULIFIED { get; set; } = "003";
        public string RECORDEXIST { get; set; } = "004";
        public string ACCESSDENIED { get; set; } = "005";
        public string NULLDATAPOINT { get; set; } = "006";
        public string INVALIDLOANTYPE { get; set; } = "007";
        //public string INACTIVE { get; set; } = "006";

    }
}
