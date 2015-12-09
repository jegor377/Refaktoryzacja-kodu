namespace TxtToBin.Converter
{
    public class BinAndTextConverter : NumeralSystemConverter
    {
        public BinAndTextConverter()
        {
            characterCountForNumeralSystem = NumeralSystemFormat.Binary;
            numeralSystemBase = NumeralSystemBase.Binary;
        }
    }
}
