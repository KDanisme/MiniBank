namespace MiniBank.Models
{
    interface IDataReaderConverter
    {
        IDataReaderAccountConverter AccountConverter { get; set; }
        IDataReaderUserConverter UserConverter { get; set; }
    }
}