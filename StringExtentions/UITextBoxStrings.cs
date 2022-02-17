namespace Rapport.AuxiliaryTools.StringExtentions
{
    using System;
    using System.Text.RegularExpressions;

    public static class UITextBoxStrings
    {
        public static String RemoveDangerousSymbols(this String source)
        {
            var regex = new Regex( @"[\`|\~|\!|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\>|\?|\/|\;|\:|\s|\""]" );
            String result = regex.Replace(source,"");
            return result;
        }
    }
}
