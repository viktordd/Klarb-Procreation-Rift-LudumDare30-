using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchHelper
{
    public static void Switch(Animator anim, string endsWith)
    {
        var oc = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = oc;

        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>(oc.overridesCount);
        oc.GetOverrides(overrides);

        int clips = oc.overridesCount;
        for (int i = 0; i < clips; i++)
        {
            string clipName = overrides[i].Key.name;
            if (!clipName.EndsWith(endsWith))
            {
                string newName = clipName.Substring(0, clipName.Length - endsWith.Length + 1) + endsWith;
                var newClip = overrides.FindIndex(p => p.Key.name == newName);
                if (newClip == -1)
                    continue;
                overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, overrides[newClip].Key);
            }
        }
        oc.ApplyOverrides(overrides);

    }

}
