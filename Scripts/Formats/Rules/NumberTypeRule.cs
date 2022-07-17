namespace UnityAutoSettings.Rule.Types.Basic
{
    public class NumberTypeRule : TypeRule
    {
        public NumberTypeRule() {
            type = new string[] { "float", "int" };
        }

        public override bool Check(string value)
        {
            foreach (var t in type)
            {
                switch (t)
                {
                    case "int":
                        int x;
                        return int.TryParse(value, out x);
                    case "float":
                        float i;
                        return float.TryParse(value, out i);
                    default:
                        break;
                }
            }
            return false;
        }
    }
}