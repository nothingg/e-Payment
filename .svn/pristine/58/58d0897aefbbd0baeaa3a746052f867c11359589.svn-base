using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;

namespace AnyID.Class
{
    public class CommonHelper
    {
        public static string MD5Encode(string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }

        public static bool Isnull(object Value)
        {
            if ((Value == null))
                return true;

            if ((object.ReferenceEquals(Value, DBNull.Value)))
                return true;

            if ((Value.ToString().Trim() == ""))
                return true;

            return false;
        }
        public static bool IsNotnull(object Value)
        {
            return !Isnull(Value);
        }

        /***************************** TIME HELPER **************************/
        public static string ConvertDateENG(object date, bool isShowTime , string symbol = "-")
        {
            IFormatProvider dateFormat = new CultureInfo("en-US").DateTimeFormat;
            try
            {
                if (date == DBNull.Value && date == null)
                    return " - ";
                else
                {
                    if (isShowTime)
                        return Convert.ToDateTime(date.ToString()).ToString("dd" + symbol + "MM" + symbol + "yyyy HH:mm:ss", dateFormat);
                    else
                        return Convert.ToDateTime(date.ToString()).ToString("dd" + symbol + "MM" + symbol + "yyyy", dateFormat);
                }
            }
            catch
            {
                return null;
            }
        }

        public static string ConvertDateENGFormat(object date,  string format = "dd-MM-yyyy")
        { 
             IFormatProvider dateFormat = new CultureInfo("en-US").DateTimeFormat;
             try
             {
                 if (date == DBNull.Value && date == null)
                     return " - ";
                 else
                 {
                     return Convert.ToDateTime(date.ToString()).ToString(format, dateFormat);
                 }
             }
             catch { return null; }
        }

        public static string ConvertDateYMD(string dateEN, char SplitSym, char ExSym, string region = "TH")
        {
            try
            {
                var date = dateEN.Split(SplitSym);
                int year = (region == "TH") ? Convert.ToInt16(date[2]) + 543 : Convert.ToInt16(date[2]);
                string m = date[1];
                string d = date[0];
                string y = year.ToString();

                string dateConvert = y + ExSym + m + ExSym + d;

                return dateConvert;

            }
            catch
            {
                return "";
            }
        }

        public static string ConvertDate_DMY(string dateAll, char SplitSym, char ExSym, string region = "TH")
        {
            try
            {
                var date = dateAll.Split(SplitSym);
                int year = (region == "TH") ? Convert.ToInt16(date[2]) + 543 : Convert.ToInt16(date[2]) - 543;
                string m = date[1];
                string d = date[0];
                string y = year.ToString();

                string dateConvert = d + ExSym + m + ExSym + y;

                return dateConvert;

            }
            catch
            {
                return "";
            }
        }


        /***************************** TEXT HELPER **************************/

        public static string DisplayCurrency(object currency)
        {
            if (currency == DBNull.Value)
                return "";
            else
                return Convert.ToDouble(currency).ToString("#,##0.00");
        }

        public static String ConvertListObjectToJson(Object data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(data);
        }

        /***************************** FILE HELPER **************************/

        public static Hashtable UploadFile(HttpPostedFileBase file, string path)
        {
            /* Create Folder .. if doesn't exist */
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }


            Hashtable result = new Hashtable();
            string fName = Path.GetFileName(file.FileName); //file.FileName;
            string fPath = Path.Combine(path, fName);
            string Ext = Path.GetExtension(fName);
            string tempfileName = "";
            bool Status = false;
            try
            {
                if (System.IO.File.Exists(fPath))
                {
                    int counter = 2;
                    string[] FileNames = fName.Split('.');
                    string FileName = FileNames[0];
                    while (System.IO.File.Exists(fPath))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = FileName + "_" + counter.ToString() + Ext;
                        fName = FileName + "_" + counter.ToString() + Ext;
                        fPath = Path.Combine(path, fName);
                        counter++;
                    }
                }
                file.SaveAs(fPath);
                Status = true;
            }
            catch
            {
                throw;
            }

            result.Add("Status", Status);
            result.Add("PathImport", fPath);
            result.Add("FileName", fName);

            return result;
        }

        public static void RemoveFile(string fName)
        {
            Hashtable result = new Hashtable();
            try
            {
                FileInfo file = new FileInfo(fName);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch
            {
                throw;
            }
        }

        /****************** Error Message ********************/
        public static string ErrMsg(Exception e) 
        {
            if (e.InnerException != null)
            {
                return e.InnerException.Message;
            }
            else 
            {
                return e.Message;
            }
        }

        
    }
}