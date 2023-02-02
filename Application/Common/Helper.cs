using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Helper
    {
        public string CreateTimeStamp()
        {
            var time = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            return time;
        }
        //public string ConvertTimeStampToDateTime()
        //{
        //    var time = DateTime.Now.ToString("yyyyMMddHHmmssffff");

        //    return time;
        //}
    }
}
