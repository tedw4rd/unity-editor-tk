using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class AnimationGenerationUtil
{
    public static AnimationCurve[] RotationAnimationCurves(Dictionary<float, Quaternion> keys)
    {
        AnimationCurve[] output = new AnimationCurve[4];
        List<Keyframe>[] keyframes = new List<Keyframe>[4];
        for (int i = 0; i < keyframes.Length; i++)
        {
            keyframes[i] = new List<Keyframe>();
        }

        foreach (KeyValuePair<float, Quaternion> keyValuePair in keys)
        {
            float time = keyValuePair.Key;
            Quaternion rotation = keyValuePair.Value;
            for (int i = 0; i < keyframes.Length; i++)
            {
                keyframes[i].Add(new Keyframe(time, rotation[i]));
            }
        }

        for (int i = 0; i < keyframes.Length; i++)
        {
            output[i] = new AnimationCurve(keyframes[i].ToArray());
        }

        return output;
    }
}