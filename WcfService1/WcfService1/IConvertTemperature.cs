using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    public class IConvertTemperature
    {
        string result = "";

        public string CtoF(decimal celcius)
        {
            return result = Convert.ToString(1.8M * celcius + 32);
        }
        public string FtoC(decimal fahrenheit)
        {
            return result = Convert.ToString((fahrenheit-32)/1.8M);
        }
    }
}
