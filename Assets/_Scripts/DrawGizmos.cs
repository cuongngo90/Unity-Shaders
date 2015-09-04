using UnityEngine;
using System.Collections;

public class DrawGizmos : MonoBehaviour {
	public Transform textTrans;
	private GUIStyle style;

	// Use this for initialization
	void Start () {
		style = new GUIStyle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrawGizmos()
    {
    	drawString(gameObject.name.ToString(), textTrans.position);
    }

    void drawString(string text, Vector3 worldPos, Color? colour = null) {
		UnityEditor.Handles.BeginGUI();       

		if (colour.HasValue) 
            GUI.color = colour.Value;
        
        var view = UnityEditor.SceneView.currentDrawingSceneView;
		Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);
		Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));
        style.fontSize = 12;	
        GUI.Label(new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height + 4, size.x, size.y), text, style);
		UnityEditor.Handles.EndGUI();
	}
}
