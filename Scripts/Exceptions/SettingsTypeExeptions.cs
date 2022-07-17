namespace UnityAutoSettings.Exception
{
    public class SettingsTypeExeption : UnityAutoSettingsException
    {
        public SettingsTypeExeption(SettingsItem item , string tryedValue) : base(item) {
            value = $"Attempt to set inappropriate data type. Tryed -> \"{tryedValue}\" current: \"{item.value}\" type : \"{item.type}\"";
        }
    }
}