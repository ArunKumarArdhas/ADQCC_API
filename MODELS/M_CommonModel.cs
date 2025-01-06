using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class RETURN_MESSAGE
    {
        public string? STATUS_CODE { get; set; }
        public bool? STATUS { get; set; }
        public string? MESSAGE { get; set; }
        public string? RETURN_1 { get; set; }
        public string? RETURN_2 { get; set; }
        public string? RETURN_3 { get; set; }
        public string? RETURN_STATUS { get; set; }
        public string? RECORDS_TOTAL { get; set; }
        public string? RECORDS_FILTERED { get; set; }
    }
    public class M_COMMON_FIELDS
    {
        public string? LANG_ID { get; set; }
        public string? ACTION { get; set; }
        public string? UNIQUE_ID { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? STATUS { get; set; }
        public string? IS_ACTIVE { get; set; }
        public string? CREATEDDATE { get; set; }
        public string? UPDATEDDATE { get; set; }
        public string? CREATEDBY { get; set; }
        public string? UPDATEDBY { get; set; }
        public string? REMARKS { get; set; }
    }
    public class M_COMMON_DROPDOWN_FIELDS
    {
        public string? VALUE { get; set; }
        public string? TEXT { get; set; }
    }
    public static class M_RETURN_STATUS_TEXT
    {
        public static string DELETED = "Deleted Successfully";
        public static string UPDATED = "Updated Successfully";
        public static string NODATA = "No records found";
        public static string ERROR = "Error during fetching records";
        public static string ALREADYEXIST = "Record Already Exist";
        public static string LISTSUCCESS = "List of data";
        public static string INVALIDTRANSID = "Invalid TransID";
        public static string INVALIDCREDENTIAL = "Invalid UserName or Password";
        public static string LOGINSUCCESS = "Login Successfully";
        public static string ADDED_SUCCESS = "Added Successfully";
        public static string PASSWORDFORGOT = "New Password Created Successfully! Please Check Your Email / SMS!";
        public static string PASSWORDCHANGE = "Password Changed Successfully!";
        public static string PASSWORDRESET = "Password Reseted Successfully for ";
        public static string CHILDDATA = "This data Currently using another Screen So you don't have Permission to delete This data";
        public static string REDEEMCODE = "Your RedeemCode Created Successfully! Please Check Your SMS!";
        public static string UpdateFaild = "Updated Failed!";
        public static string FILEEXIST = "File Already Exist!";
        public static string NODATAORERROR = "No data or Error during fetching record";
        public static string OTPPASSWORD = "OTP Created Successfully! Please Check Your Email / SMS!";
        public static string NOTREGISITERNO = "Your Number is not Registered in Portal";
        public static string NOTOTP = "Mobile Number or OTP not Match";
        public static string INVALID_JSON = "Invalid JSON";
        public static string SUCCESS = "Added Successfully";
        public static string FAILED = "Failed";
        public static string APPROVED = "Approved Successfully";
        public static string REJECTED = "Rejected Successfully";
        public static string EMAILEXIST = "Email Already Exist!";
        public static string ALLEXIST = "Already Exist!";
    }
    public static class M_RETURN_STATUS_CODE
    {
        public static string OK = "200";
        public static string INVALID_JSON = "400";
        public static string FAILED = "500";
        public static string NODATA = "404";
        public static string ISDATA = "100";
        public static bool TRUE = true;
        public static bool FALSE = false;
    }
}
