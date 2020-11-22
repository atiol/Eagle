using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Eagle.Common
{
    public static class Constants
    {
        public static readonly List<CultureInfo> SupportedCultures = new List<CultureInfo>
        {
            new CultureInfo("tr"),
            new CultureInfo("en")
        };
    }
}
