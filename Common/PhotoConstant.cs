namespace ai_finder_be_schedulers_donetcore.Common
{
    public class PhotoConstant
    {
        public const string ProfilePhotoCode = "PFL";
        public const string ProfilePhotoName = "Profile photo";
        public const string AlbumPhotoCode = "ALB";
        public const string AlbumPhotoName = "Album photo";
        public const string FamilyPhotoCode = "FAM";
        public const string SuccessStoryPhotoCode = "SSP";
        public const string FamilyPhotoName = "Family photo";
        public const string AllPhotos = "All Photos";
        public const string FamilyOrGroupPhoto = "Family/Group Photos";

        public const string SourceFileInRequest = "sourcefile";
        public const string DisplayPhotoInRequest = "displayPhoto";
        public const string FileInRequest = "file";
        public const string OrderInRequest = "order";
        public const string CandidatePhotoSupportedFormats = "image/png,image/jpeg,image/gif,image/jpg";
        public const string JpgImageType = ".jpg";
        public const string JpegImageType = ".jpeg";
        public const string PngImageType = ".png";
        public const string GifImageType = ".gif";
        public const string PdfImageType = ".pdf";
        public static readonly string[] CandidatePhotoSupportedFormatList = { JpgImageType, JpegImageType, PngImageType, GifImageType };
        public const string CandidateIdProofSupportedFormats = "image/png,image/jpeg,image/gif,application/pdf";
        public static readonly string[] CandidateIdProofSupportedFormatList = { JpgImageType, JpegImageType, PngImageType, GifImageType, PdfImageType };
        public const string PhotoActivityPhotoAdded = "ADDED";
        public const string PhotoActivityPhotoAccepted = "ACCEPT";
        public const string PhotoActivityPhotoRejected = "REJECT";
        public const string PhotoActivityPhotoDeleted = "DELETE";
        public const string PhotoActivityPhotoEdited = "EDITED";
        public const string PhotoActivitySwapped = "SWAP";
        public const string PhotoActivityArchived = "ARCHIVED";
        public const string PhotoActivityRestored = "RESTORED";
        public const string IdProofActivityUpdatedTypeAndNumber = "UPDATED TYPE & NUMBER";
        public const string IdProofInLegacyRequest = "IdProof";
        public const byte MaxIdProofDocuments = 2;
        public const string IdProofFileOneInRequest = "document1";
        public const string IdProofFileTwoInRequest = "document2";
        public const string IdProofDocumentNumberInRequest = "documentNumber";
        public const string IdProofDocumentTypeIdInRequest = "documentTypeId";
        public const string SuccessStoryCoverImageRequest = "SuccessStoryMainImage";
        public const string SuccessStorySubImageOneRequest = "SuccessStorySubImageOne";
        public const string SuccessStorySubImageTwoRequest = "SuccessStorySubImageTwo";
        public const string SuccessStorySubImageThreeRequest = "SuccessStorySubImageThree";
        public const string SuccessStorySubImageFourRequest = "SuccessStorySubImageFour";

        public const string PhotoPrivacyTypeCodeVisibleToAll = "ALL";
        public const string PhotoPrivacyTypeCodeVisibleOnlyAfterAcceptance = "MSG";
        public const string PhotoPrivacyTypeCodeProtectedByPassword = "PWD";
        public const string PhotoPrivacyTypeCodeHidePhoto = "HID";
        public const string NoImageMale = "https://photos.chavaramatrimony.com/finder/webApp/assets/img/maleNoImage.png";
        public const string NoImageFemale = "https://photos.chavaramatrimony.com/finder/webApp/assets/img/femaleNoImage.png";
        public const int FamilyPhotoMinimumHeight = 400;
        public const sbyte NoOfArchivedFamilyPhotos = 3;
        public const sbyte NoOfArchivedAlbumAndProfilePhotos = 9;
        public const string NoImageFemaleURL = "femaleNoImage.png";
        public const string NoImageMaleURL = "maleNoImage.png";
        public const string SuccessStoryOriginalImage = "SuccessStoryOriginalImage";
        public const string SuccessStoryCroppedImage = "SuccessStoryCroppedImage";
        public const string WaterMarkMarkAdded = "WaterMark Added SuccessFully";
        public const string NoPhotos = "Please add photos";
    }
}