using UnityEditor;
using UnityEngine;

public class UGUIAnchorEditor : Editor
{
    [MenuItem("UGUI Editor/Anchors to Corners %[")]
    static void AnchorsToCorners()
    {
        foreach (Transform transform in Selection.transforms)
        {
            RectTransform t = transform as RectTransform;
            RectTransform pt = Selection.activeTransform.parent as RectTransform;

            if (t == null || pt == null) 
                return;

            Vector2 newAnchorsMin = new(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                        t.anchorMin.y + t.offsetMin.y / pt.rect.height);

            Vector2 newAnchorsMax = new(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                        t.anchorMax.y + t.offsetMax.y / pt.rect.height);

            t.anchorMin = newAnchorsMin;
            t.anchorMax = newAnchorsMax;
            t.offsetMin = t.offsetMax = new Vector2(0, 0);
        }
    }
}