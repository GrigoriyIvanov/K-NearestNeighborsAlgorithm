using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    protected float deltaTime = 0.0f;

    private void Awake()
    {
        Application.targetFrameRate = 1000;
    }

    protected void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    protected void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        GUIDisplay.MakeLabel(text, 0, Color.blue);
    }
}

public enum GUISide { Left, Right }
public static class GUIDisplay
{
    public struct GUIInfo
    {
        public GUIStyle guiStyle;
        public Rect rect;
    }

    public static GUIInfo GetGUIInfo(int index, Color color, GUISide anchor, int font = 2)
    {
        int w = Screen.width, h = Screen.height;

        GUIInfo info = new GUIInfo();

        info.guiStyle = new GUIStyle();
        info.guiStyle.alignment = (anchor == GUISide.Left) ? TextAnchor.UpperLeft : TextAnchor.UpperRight;
        info.guiStyle.fontSize = Screen.height * font / 100;
        info.guiStyle.normal.textColor = color;

        info.rect = new Rect(0, info.guiStyle.fontSize * index, w, h * 2 / 100);
        return info;
    }

    public static void MakeLabel(string text, int index)
    {
        GUIInfo info = GetGUIInfo(index, Color.blue, GUISide.Left);
        GUI.Label(info.rect, text, info.guiStyle);
    }

    public static void MakeLabel(string text, int index, Color color)
    {
        GUIInfo info = GetGUIInfo(index, color, GUISide.Left);
        GUI.Label(info.rect, text, info.guiStyle);
    }

    public static void MakeLabel(string text, int index, Color color, GUISide anchor)
    {
        GUIInfo info = GetGUIInfo(index, color, anchor);
        GUI.Label(info.rect, text, info.guiStyle);
    }
}