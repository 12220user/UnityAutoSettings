namespace UnityAutoSettings.Exception
{
    public class UnityAutoSettingsException : System.Exception
    {
        public SettingsItem item { get; }
        public string value { get; protected set; }
        public UnityAutoSettingsException(SettingsItem item) {
            value = "Undefined UAS crash";
            this.item = item;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
