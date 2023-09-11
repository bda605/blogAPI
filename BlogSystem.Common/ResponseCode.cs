using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Common
{
    public enum ResponseCode
    {
        [Description("成功")]
        Success = 200,
        [Description("查無此資料")]
        NotFound = 404,
        [Description("資料異動異常")] 
        WriteError = 403,
    }
}
