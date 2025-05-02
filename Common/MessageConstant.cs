namespace ai_finder_be_schedulers_donetcore.Common
{
    public class MessageConstant
    {
        public const string Sent = "23c3cfe0-8903-11ee-9491-5ec7c1134ee0";
        public const string InterestSent = "dd5fcb0a-8900-11ee-9485-5ec7c1134ee0";
        public const string ShorListedCode = "dd5fcb0a-8900-11ee-9485-5ec7c1134ee0";
        public const string InterestMessage = "3720573a-890c-11ee-9b6c-5ec7c1134ee0";
        public const string Chat = "f0ab8255-68f6-44a1-acc5-81fc6b5e2e80";
        public const string Received = "1c841ee2-8903-11ee-9490-5ec7c1134ee0";
        public const string InterestReceived = "c79f7932-8900-11ee-9484-5ec7c1134ee0";
        public const string Responded = "f0ceb70c-89da-11ee-be02-5ec7c1134ee0";
        public const string ResponseReceived = "21cf8d98-8901-11ee-948e-5ec7c1134ee0";
        public const string ResponseSent = "0d02b4ee-8901-11ee-948b-5ec7c1134ee0";
        public const string Accepted = "cf76888c-89da-11ee-be01-5ec7c1134ee0";
        public const string IAccepted = "e5898fe6-8900-11ee-9486-5ec7c1134ee0";
        public const string AcceptedMe = "ec5514bc-8900-11ee-9487-5ec7c1134ee0";
        public const string Declined = "5b00ee6c-8aab-11ee-91b7-5ec7c1134ee0";
        public const string IDeclined = "f567179e-8900-11ee-9488-5ec7c1134ee0";
        public const string DeclinedMe = "fcbb52da-8900-11ee-9489-5ec7c1134ee0";
        public static readonly string[] PrimaryUserAcions = { Sent, Accepted, Declined };
        public const string All = "14ad8f14-8903-11ee-948f-5ec7c1134ee0";
        public const string Starred = "2bc2f086-8903-11ee-9492-5ec7c1134ee0";
        public const string Trash = "384d47ca-8903-11ee-9493-5ec7c1134ee0";
        public const string ExpiredInterests = "041a7a4c-8901-11ee-948a-5ec7c1134ee0";
        public const string ProfileDeleted = "Profile Deleted/Unavailable";
        public const string ProfileDeletedColour = "#FE8081";
        public const string ProfileDeletedCode = "efd79024-17cb-4889-9b81-7c1bb39f0d2b";
        public const string ProfiledeletedDescription = "This profile has been deleted or currently unavailable.";
        public const string InterestMessageExpirySoon = "Message Expiring Soon";
        public const string InterestMessageExpirySoonColour = "#5B8DF0";
        public const string InterestMessageExpirySoonCode = "2e6cbcf2-3bc2-4f7d-a6b4-8aa3aaff8378";
        public const string InterestMessageExpirySoonDescription = "The message will expire in {0} days, so please respond now.";
        public const string InterestMessageExpiryTodayDescription = "The message will expire today, so please respond now.";
        public const string InterestMessageExpired = "Interest Message Expired";
        public const string InterestMessageExpiredColour = "#FE8081";
        public const string InterestMessageExpiredCode = "cfc42428-3297-4d6f-91f7-3c97102f0ef8";
        public const string InterestMessageExpiredDescription = "This interest message has expired. so you can't respond it.";
        public const string MessageSent = "Sent";
        public const string MessageReceived = "Received";
        public const string MessageRespond = "Responded";
        public const string MessageAccepted = "Accepted";
        public const string MessageDeclined = "Declined";
        public const string MessageDeleted = "Deleted";
        public const string MessageRestored = "Restored";
        public const string MessagePermanentlyDeleted = "Permanently Deleted";
        public const string MessageInterestSent = "Interest Sent";
        public const string MessageInterestReceived = "Interest Received";
        public const string MessageResponseSent = "Response Sent";
        public const string MessageInterestIDeclined = "Interest I Declined";
        public const string MessageResponseReceived = "Response Received";
        public const string MessageInterestAccepted = "Interest Accepted";
        public const string MessageInterestCancelled = "Interest Cancelled";
        public const string MessageExpired = "Expired";
        public static string[] AllMessageCatogoriesCodes = { All, Received, Sent, Starred, Trash };
        public const string RespondLaterName = "Respond Later";
        public const string ActivityMessageSent = "SENT";
        public const string ActivityMessageRespond = "RESPONDED";
        public const string ActivityMessageAccept = "ACCEPTED";
        public const string ActivityMessageDeclined = "DECLINED";
        public const string ActivityMessageAdminCleared = "ADMIN CLEARED";
        public const string ActivityMessageReaded = "READED";
        public const int InterestMessageExpiryDaysLimit = 31;
        public const int InterestMessageExpiryDaysLowerLimit = 20;
        public static string[] FilteredByFiltersAll = { InterestReceived, InterestSent, IAccepted, AcceptedMe, IDeclined, DeclinedMe, ExpiredInterests };
        public static string[] FilteredByFiltersRecieved = { InterestReceived, IAccepted, IDeclined, ExpiredInterests };
        public static string[] FilteredByFiltersSent = { InterestSent, AcceptedMe, DeclinedMe, ExpiredInterests };
        public const string SentCustomMessage = "Express interest by writing personal message.";
        public const string AcceptCustomMessage = "Accept by writing a customized message.";

        #region Message titles
        public const string InterestMessageSentTitle = "Interest message sent";
        public const string PhotoUploadRequestSentTitle = "Photo upload request sent";
        public const string PhotoViewRequestSentTitle = "Photo view request sent";
        public const string AlbumPhotoViewRequestSentTitle = "Album photo view request sent";
        public const string FamilyPhotoViewRequestSentTitle = "Family photo view request sent";
        public const string InterestMessageRecievedTitle = "Interest message received";
        public const string PhotoUploadRequestRecievedTitle = "Photo upload request received";
        public const string PhotoViewRequestRecievedTitle = "Photo view request received";
        public const string AlbumPhotoViewRequestRecievedTitle = "Album photo view request received";
        public const string FamilyPhotoViewRequestRecievedTitle = "Family photo view request received";
        public const string InterestMessageResponseSentTitle = "Response sent";
        public const string InterestMessageResponseRecievedTitle = "Response recieved";
        public const string InterestMessageAcceptedBySelfTitle = "You have accepted the interest";
        public const string PhotoViewRequestAcceptBySelfTitle = "You have approved Photo view request.";
        public const string AlbumPhotoViewRequestAcceptBySelfTitle = "You have approved Album photo view request.";
        public const string FamilyPhotoViewRequestAcceptBySelfTitle = "You have approved Family photo view request.";
        public const string InterestMessageAcceptedTitle = "Accepted Me";
        public const string PhotoViewRequestAcceptTitle = "Photo view request approved.";
        public const string AlbumPhotoViewRequestAcceptTitle = "Album photo view request approved.";
        public const string FamilyPhotoViewRequestAcceptTitle = "Family photo view request approved.";
        public const string InterestMessageDeclinedBySelfTitle = "You have declined the interest";
        public const string PhotoViewRequestDeclinedBySelfTitle = "You have declined Photo view request.";
        public const string AlbumPhotoViewRequestDeclinedBySelfTitle = "You have declined Album photo view request.";
        public const string FamilyPhotoViewRequestDeclinedBySelfTitle = "You have declined Family photo view request.";
        public const string InterestMessageDeclinedTitle = "Interest Declined";
        public const string InterestMessageDeclinedMessage = "Interest Message Declined";
        public const string InterestMessageAcceptedMessage = "Interest Accepted";
        public const string PhotoViewRequestDeclinedTitle = "Photo view request declined.";
        public const string AlbumPhotoViewRequestDeclinedTitle = "Album photo view request declined.";
        public const string FamilyPhotoViewRequestDeclinedTitle = "Family photo view request declined.";
        public const string InterestMessageAcceptedCancelledBySelfTitle = "You have cancelled the interest message that was accepted";
        public const string PhotoViewRequestSentCancelledBySelfTitle = "You have cancelled the photo view request.";
        public const string PhotoViewRequestAcceptedCancelledBySelfTitle = "You have reverted the photo view request approval";
        public const string AlbumPhotoViewRequestSentCancelledBySelfTitle = "You have cancelled the album photo view request.";
        public const string AlbumPhotoViewRequestAcceptedCancelledBySelfTitle = "You have reverted the album photo view request approval";
        public const string FamilyPhotoViewRequestSentCancelledBySelfTitle = "You have cancelled the family photo view request.";
        public const string FamilyPhotoViewRequestAcceptedCancelledBySelfTitle = "You have reverted the family photo view request approval";
        public const string InterestMessageAcceptedCancelledTitle = $"{CommonConstant.NameRepresentation} has cancelled the acceptance.";
        public const string PhotoViewRequestAcceptedCancelledTitle = "This candidate has reverted the photo view request approval";
        public const string AlbumPhotoViewRequestAcceptedCancelledTitle = "This candidate has reverted the album photo view request approval";
        public const string FamilyPhotoViewRequestAcceptedCancelledTitle = "This candidate has reverted the family photo view request approval";
        public const string InterestMessageSentCancelledBySelfTitle = "You have cancelled the interest message that was sent";
        public const string PhotoUploadSentCancelledBySelfTitle = "You have cancelled the photo upload request.";
        public const string InterestMessageSentCancelledTitle = "This interest message is cancelled.";
        public const string PhotoUploadSentCancelledTitle = "This candidate has cancelled the photo upload request.";
        public const string PhotoViewRequestSentCancelledTitle = "This candidate has cancelled the photo view request.";
        public const string AlbumPhotoViewRequestSentCancelledTitle = "This candidate has cancelled the album photo view request.";
        public const string FamilyPhotoViewRequestSentCancelledTitle = "This candidate has cancelled the family photo view request.";
        public const string InterestMessageDeclinedCancelledBySelfTitle = "You have cancelled the interest message that was declined";
        public const string PhotoViewRequestDeclinedCancelledBySelfTitle = "You have reverted the photo view request refusal";
        public const string AlbumPhotoViewRequestDeclinedCancelledBySelfTitle = "You have reverted the album photo view request refusal";
        public const string FamilyPhotoViewRequestDeclinedCancelledBySelfTitle = "You have reverted the family photo view request refusal";
        public const string InterestMessageDeclinedCancelledTitle = $"{CommonConstant.NameRepresentation} have cancelled the decline message.";
        public const string PhotoViewRequestDeclinedCancelledTitle = "This candidate has reverted the photo view request refusal";
        public const string AlbumPhotoViewRequestDeclinedCancelledTitle = "This candidate has reverted the album photo view request refusal";
        public const string FamilyPhotoViewRequestDeclinedCancelledTitle = "This candidate has reverted the family photo view request refusal";
        public const string RespondLaterMessageRecieverSide = "You need more time to respond to this member, so this message will be remain in your 'Interest Received' section.";
        public const string RespondLaterMessageSenderSide = "This candidate need more time to respond to you, so this message will be remain in your 'Interest Sent' section.";
        public const string PhotoUploadedMessageTitleSelf = "Your profile photo has been uploaded.";
        public const string PhotoUploadedMessageTitle = "This candidate has accepted the request and uploaded the photo.";
        #endregion

        #region Message delete activities

        public static string[] MessageTrashTypes = { ActivityTypeConstants.MessageSenderTrash, ActivityTypeConstants.MessageRecieverTrash };
        public static string[] MessagePermanentlyDeleteTypes = { ActivityTypeConstants.MessageSenderDelete, ActivityTypeConstants.MessageReceiverDelete, ActivityTypeConstants.AdminSenderDelete, ActivityTypeConstants.AdminRecieverDelete };
        public static string[] MessageRestoredTypes = { ActivityTypeConstants.MessageRecieverRestored, ActivityTypeConstants.MessageSenderRestored };
        public static string[] MessageTrashHistoryAllTypes = { ActivityTypeConstants.MessageSenderTrash, ActivityTypeConstants.MessageRecieverTrash, ActivityTypeConstants.MessageSenderDelete, ActivityTypeConstants.MessageReceiverDelete, ActivityTypeConstants.AdminSenderDelete, ActivityTypeConstants.AdminRecieverDelete, ActivityTypeConstants.MessageRecieverRestored, ActivityTypeConstants.MessageSenderRestored };
        public static string[] MessageSenderActivityTypes = { ActivityTypeConstants.MessageSenderTrash, ActivityTypeConstants.MessageSenderDelete, ActivityTypeConstants.AdminSenderDelete, ActivityTypeConstants.MessageSenderRestored };
        public static string[] MessageReceiverActivityTypes = { ActivityTypeConstants.MessageRecieverTrash, ActivityTypeConstants.MessageReceiverDelete, ActivityTypeConstants.AdminRecieverDelete, ActivityTypeConstants.MessageRecieverRestored };
        #endregion

        #region  Message type filters
        public const string FiltersFilePath = @"Features/Message/message-filter-lookup-data.json";
        public const string MessageTypeFilterAllCode = "14ad8f14-8903-11ee-948f-5ec7c1134ee0";
        public const string MessageTypeFilterReadCode = "caba0328-4183-4df6-b691-4b7eb70e15fe";
        public const string MessageTypeFilterUnreadCode = "b2aca994-a959-4faf-96b9-173e630df62e";
        public const string MessageTypeFilterRespondLaterCode = "117e21c6-0f53-4f32-80e8-cf70a8c48a46";
        public const string MessageTypeFilterPremiumMemberCode = "9da9ce6c-0315-4eff-b475-bc020532878f";
        public const string MessageTypeFilterDateRangeCode = "1359a435-3a9f-4e50-b92c-ba50be9bde73";
        public static string[] StarredFilters = { MessageTypeFilterAllCode, MessageTypeFilterPremiumMemberCode, MessageTypeFilterDateRangeCode };
        public static string[] TrashFilters = { MessageTypeFilterAllCode, MessageTypeFilterDateRangeCode };
        public static string[] AllMessageTypeFiltes = { MessageTypeFilterAllCode, MessageTypeFilterReadCode, MessageTypeFilterUnreadCode, MessageTypeFilterRespondLaterCode, MessageTypeFilterPremiumMemberCode, MessageTypeFilterDateRangeCode };
        public static string[] PhotoRequestTypeFiltes = { MessageTypeFilterAllCode, MessageTypeFilterReadCode, MessageTypeFilterUnreadCode, MessageTypeFilterPremiumMemberCode, MessageTypeFilterDateRangeCode };
        public static string[] ChatRequestTypeFiltes = { MessageTypeFilterAllCode, MessageTypeFilterReadCode, MessageTypeFilterUnreadCode, MessageTypeFilterDateRangeCode };
        #endregion
        public static string[] HistoryActivities = { MessageConstant.MessageInterestSent, MessageConstant.MessageResponseSent, MessageConstant.MessageInterestAccepted, MessageConstant.InterestMessageDeclinedTitle, MessageConstant.MessageDeleted, MessageConstant.MessageRestored, MessageConstant.MessagePermanentlyDeleted, MessageInterestCancelled };
        public static string[] StarredActivities = { ActivityTypeConstants.MessageStarred, ActivityTypeConstants.MessageUnstarred, ActivityTypeConstants.MessageSenderStarred, ActivityTypeConstants.MessageSenderUnstarred, ActivityTypeConstants.MessageRecieverStarred, ActivityTypeConstants.MessageRecieverUnstarred };

        #region  Photo Request Constants
        public const string AllRequest = "d14263e6-dd57-4730-8390-b7e60df5734d";
        public const string RequestRecieved = "e7ae4881-f6e8-4b98-b961-862e54ca5a80";
        public const string RequestSent = "dafd6718-3bd5-4f08-8930-c7f0e9f28ac5";
        public readonly static string[] PhotoRequestCategories = { All, Received, Sent, Trash };
        public const string UploadRequestReceived = "1a9158fa-0c44-44f6-86e7-74a120906ae8";
        public const string ViewRequestReceived = "ad3150ab-e855-4de1-88d6-1249b911afd4";
        public const string UploadRequestSent = "9d00ff37-4808-4148-a0fa-ad3c7bf63fc7";
        public const string ViewRequestSent = "d8d1c2f7-b46a-4dc2-ac2d-b7ae530443eb";
        public const string ApprovedRequests = "84d23beb-089c-4760-a34d-e9494f770f77";
        public const string PhotoUploadRequestCode = "1b426d5b-a284-4576-850a-1959c4667b39";
        public const string PhotoViewRequestCode = "4632a0ce-370d-45d2-ae09-389492a6a29b";
        public const string AlbumPhotoViewRequestCode = "8375885e-71d2-4c90-9033-1fdde85c60c5";
        public const string FamilyPhotoViewRequestCode = "40893c85-8bcf-4c94-aeb0-b6bd67f4d915";
        public const string MessageCancelled = "Cancelled";
        public const string MessageReverted = "Reverted";
        public const string MessageApproved = "Approved";
        public const string MessageRequests = "Requests";
        public const string WithdrawActivityMessage = "Withdraw";

        public const string PhotoViewRequest = "Photo View Request";
        public const string PhotoUploadRequest = "Photo Upload Request";
        public const string AlbumPhotoViewRequest = "Album Photo View Request";
        public const string FamilyPhotoViewRequest = "Family Photo View Request";

        public readonly static string[] PhotoRequestFilteredByAll = { UploadRequestReceived, ViewRequestReceived, UploadRequestSent, ViewRequestSent, ApprovedRequests, ExpiredInterests };
        public readonly static string[] PhotoRequestFilteredByReceived = { UploadRequestReceived, ViewRequestReceived, ApprovedRequests, ExpiredInterests };
        public readonly static string[] PhotoRequestFilteredBySent = { UploadRequestSent, ViewRequestSent, ApprovedRequests, ExpiredInterests };
        public readonly static string[] PhotoRequestMessageTypeCodes = { PhotoUploadRequestCode, PhotoViewRequestCode, AlbumPhotoViewRequestCode, FamilyPhotoViewRequestCode, PhotoRequestMessageTypeCode };
        public readonly static string[] PhotoViewRequestCodes = { PhotoViewRequestCode, AlbumPhotoViewRequestCode, FamilyPhotoViewRequestCode };
        public readonly static string[] PhotoRequestHistoryActivities = { MessageSent, MessageApproved, MessageCancelled, MessageReverted };
        public const string RequestStatus = "Request";
        public const string PhotoRequestExpirySoon = "Request Expiring Soon";
        public const string PhotoRequestExpirySoonDescription = "The photo request will expire in {0} days, so please respond now.";
        public const string PhotoRequestExpiryTodayDescription = "The photo request will expire today, so please respond now.";
        public const string PhotoRequestExpired = "Photo Request Expired";
        public const string PhotoRequestExpiredDescription = "The photo request has expired,so you can't respond to it.";
        #endregion

        public readonly static string[] AllMessageAuditActivities = { ActivityTypeConstants.MessageSended, ActivityTypeConstants.MessageAccepted, ActivityTypeConstants.MessageDeclined, ActivityTypeConstants.MessageResponded, ActivityTypeConstants.MessageWithdraw };

        #region Message Type Codes
        public const string InterestMessageTypeCode = "3720573a-890c-11ee-9b6c-5ec7c1134ee0";
        public const string PhotoRequestMessageTypeCode = "b1c8858b-1650-49dc-a02d-b813e2e616d6";
        public const string PhotoUploadRequestTypeCode = "1b426d5b-a284-4576-850a-1959c4667b39";
        public const string PhotoViewRequestTypeCode = "4632a0ce-370d-45d2-ae09-389492a6a29b";
        public const string AlbumPhotoViewRequestTypeCode = "8375885e-71d2-4c90-9033-1fdde85c60c5";
        public const string FamilyPhotoViewRequestTypeCode = "40893c85-8bcf-4c94-aeb0-b6bd67f4d915";
        public const string ChatRequestMessageTypeCode = "f0ab8255-68f6-44a1-acc5-81fc6b5e2e80";

        #endregion

        #region message status color code
        public const string SentColorCode = "#851F83";
        public const string ReceiveColorCode = "#00B6BE";
        public const string AcceptedColorCode = "#93CC94";
        public const string DeclinedColorCode = "#FF6363";

        #endregion

        #region Short Listed Constants
        public const string IsShortListedColorCode = "#851F83";
        public const string IsShortListed = "Shortlisted";
        #endregion

        #region Chat Request
        public const string ChatRequestStatus = "Chat";
        public const string ChatRequestSentMessage = "Chat Request Sent";
        public const string ChatRequestRecievedMessage = "Chat Request Recieved";
        public const string ChatRequestDeclinedMessage = "Chat Request Declined";
        public const string ChatRequestAcceptedMessage = "Chat Request Accepted";

        public const string ChatRequestAcceptedBySelf = "You have accepted the chat request.";
        public const string ChatRequestAcceptedByCandidate = "This candidate has accepted the chat request.";
        public const string ChatRequestDeclinedBySelf = "You have declined the chat request.";
        public const string ChatRequestDeclinedByCandidate = "This candidate has declined the chat request.";
        public const string ChatRequestSentCancelledByCandidate = "This candidate has cancelled their chat request.";
        public const string ChatRequestSentCancelledBySelf = "You have cancelled the chat request.";
        public const string ChatRequestAcceptCancelledBySelf = "You have reverted the chat request approval";
        public const string ChatRequestDeclineCancelledBySelf = "You have reverted the chat request refusal";
        public const string NotResponded = "aad0660d-d54c-4e37-9354-c91e136f8a74";
        public readonly static string[] ChatRequestFilteredByAll = { NotResponded, IAccepted, AcceptedMe, IDeclined, DeclinedMe, ExpiredInterests };
        public readonly static string[] ChatRequestMessageCategories = { All, Received, Sent, Trash };
        public readonly static string[] ChatRequestFilteredByReceived = { NotResponded, IAccepted, IDeclined, ExpiredInterests };
        public readonly static string[] ChatRequestFilteredBySent = { NotResponded, AcceptedMe, DeclinedMe, ExpiredInterests };
        public const string ChatRequestExpired = "Request Expired";
        public const string ChatRequestExpiredDescription = "The chat request has expired,so you can't respond to it.";
        public const string ChatRequestExpirySoon = "Request Expiring Soon";
        public const string ChatRequestExpirySoonDescription = "The chat request will expire in {0} days, so please respond now.";
        public const string ChatRequestExpiryTodayDescription = "The chat request will expire today, so please respond now.";
        public readonly static string[] ChatRequestHistoryActivities = { ChatRequestSentMessage, MessageApproved, MessageCancelled, MessageAccepted, MessageDeclined };
        #endregion

        #region Actions
        public const int PaidMemberSendLimit = 50;
        public const int FreeMemberSendLimit = 5;
        public const int TotalNumberOfResponseSent = 2;
        public const int TimeToCancelAnActionInHours = 24;
        public const int NumberOfCancelsCanDoInLimitedTime = 1;
        public static readonly string[] ActionsHaveCancellation = new string[] { Sent, Accepted, Declined };
        #endregion

        #region warnings
        public const string CancelMessegeSendWarning = "You can cancel the message within 24 hours";
        public const string CancelAcceptWarning = "You can cancel the acceptance within 24 hours";
        public const string CancelDeclineWarning = "You can cancel this wrongly declined message";
        #endregion

        #region Tooltip
        public const string InterestMessageSentTooltip = "Interest Message Sent";
        public const string InterestMessageReceivedTooltip = "Interest Message Received";
        public const string InterestMessageAcceptedTooltip = "Interest Accepted";
        public const string InterestMessageDeclinedTooltip = "Interest Declined";
        public const string ChatRequestSentToolTip = "Chat Request Sent";
        public const string ChatRequestReceivedToolTip = "Chat Request Received";
        public const string ChatRequestDeclinedToolTip = "Chat Request Declined";
        public const string ChatRequestAcceptedToolTip = "Chat Request Accepted";

        #endregion
        #region Archived
        public const string Archived = "Archived";
        public const string Rejected = "Rejected";
        public const string NotVerified = "Not Verified";
        #endregion



        public const string MailSuccess = "Mail send successfully";

    }
}