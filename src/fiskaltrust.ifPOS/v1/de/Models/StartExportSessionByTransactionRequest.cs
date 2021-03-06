﻿using System.Runtime.Serialization;

namespace fiskaltrust.ifPOS.v1.de
{
    [DataContract]
    public class StartExportSessionByTransactionRequest
    {
        [DataMember(Order = 10)]
        public ulong From { get; set; }

        [DataMember(Order = 20)]
        public ulong To { get; set; }
    }
}
