using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.Services
{
    public class ServiceResponseMessage
    {
        //Generic
        public static readonly string Generic_Get_Success = "{0}_GET{0}S_SUCCESS";
        public static readonly string Generic_GetById_Success = "{0}_GET{0}BYID_SUCCESS";
        public static readonly string Generic_Add_Success = "{0}_ADD{0}_SUCCESS";
        public static readonly string Generic_AddRange_Success = "{0}_ADDRANGE{0}_SUCCESS";
        public static readonly string Generic_Add_Error_Null = "{0}_ADD{0}_ERROR_{0}_IS_NULL";
        public static readonly string Generic_Add_Error_Duplicate = "{0}_ADD{0}_ERROR_DUPLICATE";
        public static readonly string Generic_Update_Success = "{0}_UPDATE{0}_SUCCESS";
        public static readonly string Generic_UpdateRange_Success = "{0}_UPDATERANGE{0}_SUCCESS";
        public static readonly string Generic_Update_Error_Null = "{0}_UPDATE{0}_ERROR_{0}_IS_NULL";
        public static readonly string Generic_Update_Error_NonExistent = "{0}_UPDATE{0}_ERROR_NON_EXISTENT";
        public static readonly string Generic_Update_Error_Duplicate = "{0}_UPDATE{0}_ERROR_DUPLICATE";
        public static readonly string Generic_Delete_Error = "{0}_DELETE{0}_ERROR_{0}";
        public static readonly string Generic_Delete_Success = "{0}_DELETE{0}_SUCCESS";
        public static readonly string Generic_DeleteRange_Success = "{0}_DELETERANGE{0}_SUCCESS";
        public static readonly string Generic_Reversal_Success = "{0}_REVERSAL{0}_SUCCESS";
        public static readonly string Generic_No_Records_Found = "NO_RECORDS_FOUND";
        public static readonly string Generic_Not_Valid_Value = "UNKNOWN_IS_NOT_A_VALID_VALUE";
        public static readonly string Dto_Is_Null_Error = "DTO_IS_NULL_ERROR";
        public static readonly string Invalid_Operation = "";

        public static string Get_Success<T>()
        {
            return String.Format(Generic_Get_Success, typeof(T).Name.ToUpper());
        }

        public static string GetById_Success<T>()
        {
            return String.Format(Generic_GetById_Success, typeof(T).Name.ToUpper());
        }

        public static string Add_Success<T>()
        {
            return String.Format(Generic_Add_Success, typeof(T).Name.ToUpper());
        }

        public static string AddRange_Success<T>()
        {
            return String.Format(Generic_AddRange_Success, typeof(T).Name.ToUpper());
        }

        public static string Add_Null_Error<T>()
        {
            return String.Format(Generic_Add_Error_Null, typeof(T).Name.ToUpper());
        }

        public static string Add_Duplicate_Error<T>()
        {
            return String.Format(Generic_Add_Error_Duplicate, typeof(T).Name.ToUpper());
        }

        public static string Update_Success<T>()
        {
            return String.Format(Generic_Update_Success, typeof(T).Name.ToUpper());
        }

        public static string UpdateRange_Success<T>()
        {
            return String.Format(Generic_UpdateRange_Success, typeof(T).Name.ToUpper());
        }

        public static string Update_Null_Error<T>()
        {
            return String.Format(Generic_Update_Error_Null, typeof(T).Name.ToUpper());
        }

        public static string Update_Nonexistent_Error<T>()
        {
            return String.Format(Generic_Update_Error_NonExistent, typeof(T).Name.ToUpper());
        }

        public static string Update_Duplicate_Error<T>()
        {
            return String.Format(Generic_Update_Error_Duplicate, typeof(T).Name.ToUpper());
        }

        public static string Delete_Error<T>()
        {
            return String.Format(Generic_Delete_Error, typeof(T).Name.ToUpper());
        }

        public static string Delete_Success<T>()
        {
            return String.Format(Generic_Delete_Success, typeof(T).Name.ToUpper());
        }

        public static string DeleteRange_Success<T>()
        {
            return String.Format(Generic_DeleteRange_Success, typeof(T).Name.ToUpper());
        }

    }

}
