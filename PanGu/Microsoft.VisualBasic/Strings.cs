using SS.International.Chinese.Translate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.VisualBasic
{
    internal class Strings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">文本</param>
        /// <param name="Conversion">被翻译成的语言</param>
        /// <param name="LocaleID"></param>
        /// <returns></returns>
        public static string StrConv(string str, VbStrConv Conversion, int LocaleID = 0)
        {
            try
            {
                ChineseTranslateDirection chineseTranslate = (Conversion == VbStrConv.SimplifiedChinese) ?
                    ChineseTranslateDirection.TraditionalToSimplified : ChineseTranslateDirection.SimplifiedToTraditional;
                string value = ChineseTranslate.Convert(str, chineseTranslate);
                return value;
            }
            catch (Exception ex)
            {
                return str;//非Wwindows可能会报错~
            }
        }
    }
}
