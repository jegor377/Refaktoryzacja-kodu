namespace TxtToBin.Converter
{
    public class HexAndTextConverter : NumeralSystemConverter
    {
        public HexAndTextConverter()
        {
            characterCountForNumeralSystem = NumeralSystemFormat.Hexadecimal;
            numeralSystemBase = NumeralSystemBase.Hexadecimal;
        }
    }
}
