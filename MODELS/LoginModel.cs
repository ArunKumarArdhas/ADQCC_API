using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class LoginModel
    {
        public long EMP_ID { get; set; }
        public string? EMP_FIRSTNAME { get; set; }
        public string? EMP_LASTNAME { get; set; }
        public string? EMP_GENDER { get; set; }
        public int EMP_NATIONALITY_ID { get; set; }
        public int EMP_DESIGNATION_ID { get; set; }
        public int EMP_LOCATION_ID { get; set; }
        public int EMP_BUILDING_ID { get; set; }
        public int EMP_SECTOR_ID { get; set; }
        public int EMP_DEPARTMENT_ID { get; set; }
        public int EMP_SECTION_ID { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EMP_PHONE_NO { get; set; }
        public string? EMP_TEL_NO { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public bool EMP_STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public long CREATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public long UPDATED_BY { get; set; }
        public string? EMP_USERNAME { get; set; }
        public int EMP_LANGUAGE { get; set; }
    }

    public class GET_USER_DETAILS
    {
        public string? EMP_ID { get; set; }
        public string? MESSAGE { get; set; }
        public string? LANG_ID { get; set; }
        public string? DISPLAY_NAME { get; set; }
        public string? DESI_NAME { get; set; }
        public string? EMP_USERNAME { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public string? EMP_STATUS { get; set; }
        public string? STATUS { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? DISPLAY_NAME_AR { get; set; }
        public string? DESI_NAME_AR { get; set; }
        public string? GENDER { get; set; }
        public string? EXPIRED_DATE { get; set; }
        public string? EMP_ENCRYPT_ID { get; set; }
        public string? JWT_Token { get; set; }

    }
    public class LOGIN
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Desi_Id { get; set; }
        public string? OTP { get; set; }
    }
    public class USER_LOGIN
    {
        public string? USERNAME { get; set; }
        public string? PASSWORD { get; set; }
        public string? DESI_ID { get; set; }
        public string? FIREBASE_ID { get; set; }
        public string? ROLE { get; set; }
        public string? EXPIRED_DATE { get; set; }

    }


    public class GET_NOTIFICATION_COUNT
    {
        public string? ROLE { get; set; }
        public string? USER_ID { get; set; }
    }

    public class GET_NOTIFICATION_COUNT_LIST
    {
        public string? NOTIFICATION_COUNT { get; set; }
    }

    public class UPDATE_READ_NOTIFICATION
    {
        public string? NOTIFICATION_ID { get; set; }
    }

    class returnErrormessage
    {
        public string? Message { get; set; }
    }

    public class GET_NOTIFICATION_DETAILS
    {
        public string? USM_USERNAME { get; set; }
        public string? USM_PASSWORD { get; set; }
        public string? ULS_FIREBASEID { get; set; }
        public string? NUD_APPLICATIONID { get; set; }
        public string? USM_APP_API_KEY { get; set; }
        public string? NUD_SENDERID { get; set; }
        public string? MSG_MESSAGE { get; set; }
        public string? Type { get; set; }
        public string? MSG_DEFAULT_TITLE { get; set; }
        public string? NOTIFICATION_COUNT { get; set; }
        public string? NOTIFICATION_ID { get; set; }
        public string? VISIT_TYPE { get; set; }
        public string? NAME_DISCRIPTION { get; set; }
    }


    public class GET_NOTIFICATION_COUNT_DETAILS
    {
        public string? NOTIFICATION_ID { get; set; }
        public string? LOGIN_USER_ID { get; set; }
        public string? NOTIFICATION_CONTENT { get; set; }
        public string? NOTIFICATION_TITLE { get; set; }
        public string? READ_STATUS { get; set; }
    }

    public class GET_TOKEN
    {
        public string? ACCESS_TOKEN { get; set; }

    }
}
