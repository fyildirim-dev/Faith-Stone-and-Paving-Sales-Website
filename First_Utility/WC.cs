using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace First_Utility
{
    public static class WC
    {
        public const string ImagePath = @"\images\product\";
        public const string SessionCart = "ShoppingCartSession";
        public const string SessionInquiryId = "InquirySession";
        public const string InquiryHeaderIdSession = "InquiryHeaderIdSession";
    
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";

        public const string EmailAdmin = "fyildirim459@gmail.com";
        public const string CategoryName = "Category";
        public const string ApplicationTypeName = "ApplicationType";

        public const string Success = "Success";
        public const string Error = "Error";

        public const string StatusPending = "Beklemede";
        public const string StatusApproved = "Onaylandı";
        public const string StatusInProcess = "Hazırlanıyor";
        public const string StatusShipped = "Gönderildi";
        public const string StatusCancelled = "İptal Edildi";
        public const string StatusRefunded = "İade Edildi";

        public static readonly IEnumerable<string> listStatus = new ReadOnlyCollection<string>(
            new List<string>
            {
                StatusApproved,StatusPending, StatusCancelled, StatusInProcess, StatusRefunded, StatusShipped
            });
        
    }
}
