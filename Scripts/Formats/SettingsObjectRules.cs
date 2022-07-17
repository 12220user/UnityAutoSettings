using UnityAutoSettings.Rule.Types;
using UnityAutoSettings.Rule.Types.Basic;

namespace UnityAutoSettings
{
    public partial class SettingsObject
    {
        private void AddSettingsItemTypeBasic() {
            AddSettingsItemType(new NumberTypeRule());
            AddSettingsItemType(new BasicNoInteractabeTypeRule());
        }

        public void AddSettingsItemType(TypeRule rule) {
            if (typeRules != null) {
                typeRules.Add(rule);
            }
        }
    }
}
