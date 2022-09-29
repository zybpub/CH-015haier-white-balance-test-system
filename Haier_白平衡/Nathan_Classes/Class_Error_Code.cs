using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation.Nathan_Classes
{
    class Class_Error_Code
    {
        enum Error_Code {
            BPHTS_001,//  与TV通讯失败
            BPHTS_002,//  调试超时
            BPHTS_003,//  Normal 调试失败
            BPHTS_004,//  Warm 调试失败
            BPHTS_005,//  Cool 调试失败
        }
    }
}
