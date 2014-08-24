using System.Linq;
using UnityEngine;

public class SwitchHelper
{
	public static void Switch(Animator anim, string endsWith)
	{
		var oc = new AnimatorOverrideController { runtimeAnimatorController = anim.runtimeAnimatorController };
		int clips = oc.clips.Length / 2;
		for (int i = 0; i < clips; i++)
		{
			string clipName = oc.clips[i].originalClip.name;
			if (!clipName.EndsWith(endsWith))
			{
				string newName = clipName.Substring(0, clipName.Length - endsWith.Length + 1) + endsWith;
				AnimationClipPair newClip = oc.clips.Last(cl => cl.originalClip.name == newName);
				oc[clipName] = newClip.originalClip;
			}
		}
		anim.runtimeAnimatorController = oc;
	}
}
