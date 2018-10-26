namespace ExcelReaderModels.Enums
{
    public enum PrintingOptions
    {
        [EnumDescription("t")]
        ToTxt = 1,
        [EnumDescription("j")]
        ToJson = 2,
        [EnumDescription("c")]
        ToConsole = 3,
    }
}
