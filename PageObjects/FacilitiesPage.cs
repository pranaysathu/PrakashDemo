using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.UITest.PageObjects
{
    public class FacilitiesPage
    {       
        public string Reload
        {
            get
            {
                return FacilitiesPageCtrls.Reload;
            }
        }

        public string SearchFacilities
        {
            get
            {
                return FacilitiesPageCtrls.SearchFacilities;
            }
        }

        public string SearchFacilitiesClass
        {
            get
            {
                return FacilitiesPageCtrls.SearchFacilitiesClass;
            }
        }

        public string SearchButton
        {
            get
            {
                return FacilitiesPageCtrls.SearchButton;
            }
        }

        public string Impersonate
        {
            get
            {
                return FacilitiesPageCtrls.Impersonation;
            }
        }
        public string ImpersonateUserID
        {
            get
            {
                return FacilitiesPageCtrls.Impersonation_UserID;
            }
        }

        public string ImpersonateOk
        {
            get
            {
                return FacilitiesPageCtrls.Impersonation_Ok;
            }
        }

        public string ImpersonateCancel
        {
            get
            {
                return FacilitiesPageCtrls.Impersonation_Cancel;
            }
        }

        public string FacilityList
        {
            get
            {
                return FacilitiesPageCtrls.FacilityList;
            }
        }

        public string LoggedINUser
        {
            get
            {
                return FacilitiesPageCtrls.LoggedInUser;
            }
        }

        public string FacilityRightArrow
        {
            get
            {
                return FacilitiesPageCtrls.FacilityRightArrow;
            }
        }

    }
}
