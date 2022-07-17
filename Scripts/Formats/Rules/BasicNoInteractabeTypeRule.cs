namespace UnityAutoSettings.Rule.Types.Basic
{
    public class BasicNoInteractabeTypeRule : TypeRule
    {
        public BasicNoInteractabeTypeRule() {
            type = new string[] { 
                "text",
                "header",
                "undefiend"
            };
        }

        public override bool Check(string value)
        {
            return true;
        }
    }
}
