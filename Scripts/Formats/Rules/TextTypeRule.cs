using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAutoSettings.Rule.Types.Basic
{
    public class TextTypeRule : TypeRule
    {
        public TextTypeRule() {
            type = new string[] { 
                "text",
                "header",
                "sub-header",
                "linq"
            };
        }
    }
}
