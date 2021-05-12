using System;
using System.Collections.Generic;
using System.Text;

namespace PolyStore.Helpers
{
    public class CurrentDateTime : ICurrentDateTime
    {
        DateTime ICurrentDateTime.CurrentDateTime => DateTime.Now;
    }
}
