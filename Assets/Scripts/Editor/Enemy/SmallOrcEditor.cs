using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SmallOrc))]
public class SmallOrcEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SmallOrc smallOrc = (SmallOrc)target;
        if (GUILayout.Button("Set Target"))
        {
            if (smallOrc._target != null)
            {
                smallOrc.Move();
            }
        }
    }
}
