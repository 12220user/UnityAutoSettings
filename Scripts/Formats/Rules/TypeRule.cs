namespace UnityAutoSettings.Rule.Types
{
    public class TypeRule
    {
        public string[] type { get; protected set; }

        public virtual bool Check(string value) {
            return true;
        }
    }
}
