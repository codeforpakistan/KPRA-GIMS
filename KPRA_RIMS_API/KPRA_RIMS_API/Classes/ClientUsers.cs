namespace KPRA_RIMS_API.Classes
{
    using System;
    using System.Runtime.CompilerServices;

    public class ClientUsers
    {
        public string ConnectionStatus { get; set; }

        public string UserName { get; set; }

        public string Notification { get; set; }

        public string StatusImage { get; set; }

        public DateTime? NowTime { get; set; }

        public int UserID { get; set; }

        public string BusinessName { get; set; }

        public string Address { get; set; }

        public int ConnectedSince { get; set; }
    }
}

