//	Quikbar for Unity 2017
//  A simple Unity Editor usage and accessibility improvement tool.
//
//  Usage:
//  Place the folder under any Project Hierarchy sub-folder named "Editor"
//  Access with top menu entry "Window/Quikbar" or Ctrl+Shift+1 (Cmd+Shift+1 on MacOS)

using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

class Quikbar : EditorWindow
{
    public Vector2 windowSize = new Vector2(100, 550);

    [MenuItem("Window/Quikbar %#1")]
    static void Init()
    {
        var window = (Quikbar)GetWindow(typeof(Quikbar), false, "Quikbar");
        window.ShowUtility();
    }

    void OnInspectorUpdate()
    {
        Repaint();
        this.minSize = new Vector2(this.minSize.x, windowSize.y);
    }

    GUIStyle FrontEnd(string type)
    {
        var guiStyle = new GUIStyle();
        // label
        if (type.Equals("label"))
        {
            guiStyle = GUI.skin.GetStyle("label");
            guiStyle.fontSize = 9;
            guiStyle.richText = true;
            guiStyle.wordWrap = true;
        }
        // button
        if (type.Equals("button"))
        {
            guiStyle = GUI.skin.GetStyle("minibutton");
            //guiStyle.fixedWidth = 94f;
            guiStyle.fixedWidth = this.position.size.x - 6;
            guiStyle.fixedHeight = 16f;
            guiStyle.fontSize = 9;
        }
        // dropdown
        if (type.Equals("dropdown"))
        {
            guiStyle = GUI.skin.GetStyle("popup");
            guiStyle.alignment = TextAnchor.MiddleCenter;
            guiStyle.fixedHeight = 16f;
            guiStyle.fontSize = 8;
        }
        return guiStyle;
    }

    void OnGUI()
    {

        // Main GUI
        var guiBuilder = new GUIContent();

        // Layout Start
        GUILayout.BeginVertical();
        GUILayout.Space(4f);

        // Current scene name
        var sceneName = "-";
        if (!SceneManager.GetActiveScene().name.Equals(string.Empty))
            sceneName = SceneManager.GetActiveScene().name;
        GUILayout.Label("<b>Current scene:</b>\n" + sceneName, FrontEnd("label"));

        // Buttons
        GUILayout.Space(4f);

        guiBuilder.text = "Snap";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Snap Settings...");
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Input Manager";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Input");
        }

        guiBuilder.text = "Tags & Layers";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Tags and Layers");
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Player Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
        }

        guiBuilder.text = "3D Physics";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Physics");
        }

        guiBuilder.text = "2D Physics";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Physics 2D");
        }

        guiBuilder.text = "Time Manager";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Time");
        }

        guiBuilder.text = "Audio";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Audio");
        }

        guiBuilder.text = "Quality";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Quality");
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Graphics";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Graphics");
        }

        string[] graphicsEmulationsList = { "No Emulation", "Shader Model 4", "Shader Model 3", "Shader Model 2" };
        for (int i = 0; i < graphicsEmulationsList.Length; i++)
        {
            if (Menu.GetChecked("Edit/Graphics Emulation/" + graphicsEmulationsList[i]))
            {
                i = EditorGUILayout.Popup(i, graphicsEmulationsList, FrontEnd("dropdown"));
                EditorApplication.ExecuteMenuItem("Edit/Graphics Emulation/" + graphicsEmulationsList[i]);
            }
        }

        string[] shaderHardwareTiersList = { "Tier 1", "Tier 2", "Tier 3" };
        for (int i = 0; i < shaderHardwareTiersList.Length; i++)
        {
            if (Menu.GetChecked("Edit/Graphics Emulation/Shader Hardware " + shaderHardwareTiersList[i]))
            {
                i = EditorGUILayout.Popup(i, shaderHardwareTiersList, FrontEnd("dropdown"));
                EditorApplication.ExecuteMenuItem("Edit/Graphics Emulation/Shader Hardware " + shaderHardwareTiersList[i]);
            }
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Network";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Network");
        }

        string[] netEmulationsList = { "None", "Broadband", "DSL", "ISDN", "Dial-Up" };
        for (int i = 0; i < netEmulationsList.Length; i++)
        {
            if (Menu.GetChecked("Edit/Network Emulation/" + netEmulationsList[i]))
            {
                i = EditorGUILayout.Popup(i, netEmulationsList, FrontEnd("dropdown"));
                EditorApplication.ExecuteMenuItem("Edit/Network Emulation/" + netEmulationsList[i]);
            }
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Audio Mixer";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Audio Mixer");
        }

        guiBuilder.text = "Sprite Packer";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Sprite Packer");
        }

        guiBuilder.text = "Lighting Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Lighting/Settings");
        }

        guiBuilder.text = "Light Explorer";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Lighting/Light Explorer");
        }

        guiBuilder.text = "Occlusion";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Occlusion Culling");
        }

        guiBuilder.text = "Navigation";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Navigation");
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Profiler";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Profiler");
        }

        guiBuilder.text = "Frame Debug";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Frame Debugger");
        }

        guiBuilder.text = "Test Runner";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Test Runner");
        }

        guiBuilder.text = "Editor Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Editor");
        }

        guiBuilder.text = "Script Execution";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Script Execution Order");
        }

        GUILayout.Space(6f);

        guiBuilder.text = "Build Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            GetWindow(Type.GetType("UnityEditor.BuildPlayerWindow,UnityEditor"));
        }

        // Cache Cleaner
        guiBuilder.tooltip = "";
        guiBuilder.text = "";

        // Layout End
        GUILayout.EndVertical();

    }

}
