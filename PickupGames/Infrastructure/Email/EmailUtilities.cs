using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PickupGames.Infrastructure.Email
{
    // https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx

    public static class EmailUtilities
    {
        private static bool _invalid;
        
        public static bool IsValidEmail(string strIn)
        {
            _invalid = false;

            if (string.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.

            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (_invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static string ConvertEmailToUserName(string email)
        {
            if (string.IsNullOrEmpty(email)) return email;

            var index = email.IndexOf('@');

            if (index == -1)
            {
                return email;
            }

            var userName = email.Remove(index);

            index = userName.LastIndexOf('\\');

            userName = index == -1 ? userName : userName.Remove(0, index + 1);

            return userName;
        }

        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.

            var idn = new IdnMapping();

            var domainName = match.Groups[2].Value;

            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                _invalid = true;
            }

            return match.Groups[1].Value + domainName;
        }        
    }
}


//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;

//namespace CareTeamMember.Identity.Infrastructure.SpreadSheet
//{
//    public static class SpreadSheetToObjectParser
//    {    
//        public static List<T> ConvertRosterSpreadSheetToObject<T>(string filename) where T : class, new()
//        {
//            var headers = GetColumnHeaders(filename);
//            var items = new List<T>();

//            var instance = new T();
//            var type = instance.GetType();            

//            using (var document = SpreadsheetDocument.Open(filename, false))
//            {
//                var workbookPart = document.WorkbookPart;
//                var worksheetPart = workbookPart.WorksheetParts.First();
//                var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
//                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

//                if (stringTable == null)
//                {
//                    return null;
//                }

//                var rows = sheetData.Elements<Row>().Where(x => x.RowIndex != 1);

//                foreach (var r in rows)
//                {
//                    T item = null;
//                    var cells = r.Elements<Cell>();

//                    foreach (var c in cells)
//                    {
//                        var columnName = GetColumnName(c.CellReference);

//                        if (!headers.ContainsKey(columnName) || type.GetProperty(headers[columnName]) == null)
//                        {
//                            continue;
//                        }

//                        if (c.DataType != null && c.DataType.Value == CellValues.SharedString)
//                        {
//                            var val = stringTable.SharedStringTable.ElementAt(int.Parse(c.CellValue.Text)).InnerText.Trim();
//                            if (!string.IsNullOrEmpty(val))
//                            {
//                                if (item == null)
//                                {
//                                    item = new T();
//                                }
//                                type.GetProperty(headers[columnName]).SetValue(item, val, null);
//                            }
//                        }                        
//                    }

//                    if(item != null)
//                    {
//                        items.Add(item);  
//                    }                    
//                }
//            }

//            return items;
//        }

//        private static Dictionary<string, string> GetColumnHeaders(string filename)
//        {
//            var columns = new Dictionary<string, string>();

//            using (var document = SpreadsheetDocument.Open(filename, false))
//            {
//                var workbookPart = document.WorkbookPart;
//                var worksheetPart = workbookPart.WorksheetParts.First();
//                var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
//                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

//                if (stringTable == null)
//                {
//                    return columns;
//                }

//                var row = sheetData.Elements<Row>().FirstOrDefault();

//                var cells = row.Elements<Cell>();

//                foreach (var t in cells)
//                {
//                    if (t.DataType != null && t.DataType.Value == CellValues.SharedString)
//                    {
//                        var headerLetter = GetColumnName(t.CellReference);
//                        var headerValue =
//                            stringTable.SharedStringTable.ElementAt(int.Parse(t.CellValue.Text)).InnerText.Replace(" ", "");
//                        columns[headerLetter] = headerValue;
//                    }
//                }
//            }

//            return columns;
//        }

//        private static string GetColumnName(string cellName)
//        {
//            var regex = new Regex("[A-Za-z]+");
//            var match = regex.Match(cellName);

//            return match.Value;
//        }       
//    }
//}
