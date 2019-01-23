using System;

namespace LibraryData
{
    public interface IFeeService
    {
        TimeSpan DaysLoaned(int id);
    }
}
