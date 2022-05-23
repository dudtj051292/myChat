using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myChat
{
    public class Utils
    {
        public static string getObjectToString(object o)
        {
            if (o == null || o.ToString().Trim() == "")
                return "";

            return o.ToString();
        }
        public static decimal getObjectToDecimal(Object o)
        {
            if (o == null) { return 0; }

            decimal result = 0;

            try
            {
                result = Convert.ToDecimal(o, null);
            }
            catch (FormatException formatEx)
            {
                return 0;
            }
            catch (InvalidCastException invaildEx)
            {
                return 0;
            }
            catch (OverflowException overEx)
            {
                return 0;
            }
            return result;
        }
        public static string getDataTableToJSON(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        public static DataTable getJSONtoDataTable(string JSON)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(JSON);
            return dt;
        }

        public static Dictionary<string, string> getJSONtoDictonary(string json)
        {
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return dic;
        }
    }


}
