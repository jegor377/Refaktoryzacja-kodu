namespace TxtToBin.Converter
{
    public class DecAndTextConverter : NumeralSystemConverter
    {
        public DecAndTextConverter()
        {
            characterCountForNumeralSystem = NumeralSystemFormat.Decimal;
            numeralSystemBase = NumeralSystemBase.Decimal;
        }
    }
}
