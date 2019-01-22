using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IFeeService
    {
        TimeSpan DaysLoaned(int id);
    }
}
