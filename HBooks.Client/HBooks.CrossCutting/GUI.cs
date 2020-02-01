using System;
using System.Numerics;

namespace HBooks.CrossCutting
{
    public class GUI
    {
        public decimal GuiToDecimal(Guid obj)
        {
            string GuidToInteger = (new BigInteger(Guid.NewGuid().ToByteArray())).ToString("N0");

            var rt = Convert.ToDecimal(GuidToInteger);

            return rt;
        }
    }
}
