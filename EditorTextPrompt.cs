using UnityEngine;
using UnityEditor;

public class EditorTextPrompt : EditorWindow
{
    public delegate void OnEnter(string input);
    public delegate void OnCancel();

    protected OnEnter _enterCB;
    protected OnCancel _cancelCB;
    
    protected string _windowPrompt;
    protected string _displayedInput;

    public static void Show(string prompt, string defaultInput, OnEnter successCallback, OnCancel failCallback)
    {
        EditorTextPrompt window = GetWindow<EditorTextPrompt>();
        window._displayedInput = defaultInput;
        window._windowPrompt = prompt;
        window._enterCB = successCallback;
        window._cancelCB = failCallback;
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();

        GUILayout.Label(_windowPrompt);
        _displayedInput = GUILayout.TextField(_displayedInput);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("OK"))
        {
            Close();
            _enterCB(_displayedInput);
            return;
        }
        else if (GUILayout.Button("Cancel"))
        {
            Close();
            _cancelCB();
            return;
        }
        
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}