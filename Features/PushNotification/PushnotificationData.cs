using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ai_finder_be_schedulers_donetcore.Features.PushNotification
{
    public class PushnotificationData
    {
        public long? CandidateId { get; set; }
        public long? NotificationId { get; set; }
        public string SourcePageCode { get; set; }
        public string GroupCode { get; set; }
        public bool IsSound { get; set; }
    }
}