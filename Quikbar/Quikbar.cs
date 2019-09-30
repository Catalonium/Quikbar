//  Quikbar for Unity 2018
//  A simple Unity Editor usage and accessibility improvement tool.
//
//  Usage:
//  Place the folder under any Project Hierarchy sub-folder named "Editor"
//  Access with top menu entry "Window/Quikbar" or Ctrl+Shift+1 (Cmd+Shift+1 on MacOS)

using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

class Quikbar : EditorWindow
{
    bool isStartup = true;

    float windowScrollHeight = 800;
    Vector2 minWindowSize = new Vector2(120, 120);
    Vector2 scrollPos;

    [MenuItem("Window/Quikbar %#1")]
    static void Init()
    {
        var window = (Quikbar)GetWindow(typeof(Quikbar), false, "Quikbar");
        window.ShowUtility();
    }

    void OnInspectorUpdate()
    {
        Repaint();
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
            guiStyle.padding.top = 2;
            guiStyle.padding.bottom = -2;
            guiStyle.padding.left = 5;
            guiStyle.padding.right = 5;
        }
        // sublabel
        if (type.Equals("sublabel"))
        {
            guiStyle = GUI.skin.GetStyle("label");
            guiStyle.fontSize = 7;
            guiStyle.richText = true;
            guiStyle.wordWrap = true;
            guiStyle.padding.top = 2;
            guiStyle.padding.bottom = -2;
            guiStyle.padding.left = 5;
            guiStyle.padding.right = 5;
        }
        // button
        if (type.Equals("button"))
        {
            guiStyle = GUI.skin.GetStyle("minibutton");
            //guiStyle.fixedWidth = 94f;
            guiStyle.fontSize = 9;
            guiStyle.fixedHeight = 16f;
            if (this.position.height < windowScrollHeight)
                guiStyle.fixedWidth = this.position.size.x - 22;
            else guiStyle.fixedWidth = this.position.size.x - 6;
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

        if (this.position.height < windowScrollHeight)
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
        }

        // Buttons
        GUILayout.Space(4f);

        guiBuilder.text = "Snap";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Edit/Snap Settings...");
        }

        GUILayout.Space(4f);

        // Project Settings
        GUILayout.Label("Project Settings", FrontEnd("label"));

        GUILayout.Space(2f);

        guiBuilder.text = "Audio";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Audio");
        }

        guiBuilder.text = "Editor";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Editor");
        }

        guiBuilder.text = "Graphics";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Graphics");
        }

        guiBuilder.text = "Input";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Input");
        }

        guiBuilder.text = "Physics 3D";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Physics");
        }

        guiBuilder.text = "Physics 2D";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Physics 2D");
        }

        guiBuilder.text = "Player";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Player");
        }

        guiBuilder.text = "Preset Manager";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Preset Manager");
        }

        guiBuilder.text = "Quality";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Quality");
        }

        guiBuilder.text = "Script Execution";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Script Execution Order");
        }

        guiBuilder.text = "Tags and Layers";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Tags and Layers");
        }

        guiBuilder.text = "TextMesh Pro";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/TextMesh Pro");
        }

        guiBuilder.text = "Time";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/Time");
        }

        guiBuilder.text = "VFX";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            SettingsService.OpenProjectSettings("Project/VFX");
        }

        GUILayout.Space(4f);

        // Windows
        GUILayout.Label("Windows", FrontEnd("label"));
        // General
        GUILayout.Label("General", FrontEnd("sublabel"));

        guiBuilder.text = "Test Runner";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/General/Test Runner");
        }

        // Rendering
        GUILayout.Label("Rendering", FrontEnd("sublabel"));

        guiBuilder.text = "Lighting Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Rendering/Lighting Settings");
        }

        guiBuilder.text = "Light Explorer";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Rendering/Light Explorer");
        }

        guiBuilder.text = "Occlusion Culling";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Rendering/Occlusion Culling");
        }

        // Animation
        GUILayout.Label("Animation", FrontEnd("sublabel"));

        guiBuilder.text = "Animation";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Animation/Animation");
        }

        guiBuilder.text = "Animator";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Animation/Animator");
        }

        guiBuilder.text = "Animator Params";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Animation/Animator Parameter");
        }

        // Audio
        GUILayout.Label("Audio", FrontEnd("sublabel"));

        guiBuilder.text = "Audio Mixer";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Audio/Audio Mixer");
        }

        // Sequencing
        GUILayout.Label("Sequencing", FrontEnd("sublabel"));

        guiBuilder.text = "Timeline";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Sequencing/Timeline");
        }

        // Analysis
        GUILayout.Label("Analysis", FrontEnd("sublabel"));

        guiBuilder.text = "Profiler";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Analysis/Profiler");
        }

        guiBuilder.text = "Frame Debug";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Analysis/Frame Debugger");
        }

        guiBuilder.text = "Physics Debug";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Analysis/Physics Debugger");
        }

        guiBuilder.text = "UIElements Debug";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/Analysis/UIElements Debugger");
        }

        // 2D
        GUILayout.Label("2D", FrontEnd("sublabel"));

        guiBuilder.text = "Sprite Editor";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/2D/Sprite Editor");
        }

        guiBuilder.text = "Sprite Packer";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/2D/Sprite Packer");
        }

        guiBuilder.text = "Tile Palette";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/2D/Tile Palette");
        }

        // AI
        GUILayout.Label("AI", FrontEnd("sublabel"));

        guiBuilder.text = "Navigation";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("Window/AI/Navigation");
        }

        GUILayout.Space(4f);

        // Build
        GUILayout.Label("Build", FrontEnd("label"));

        guiBuilder.text = "Build Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            EditorApplication.ExecuteMenuItem("File/Build Settings...");
        }

        guiBuilder.text = "Player Settings";
        if (GUILayout.Button(guiBuilder, FrontEnd("button")))
        {
            Selection.activeObject = Unsupported.GetSerializedAssetInterfaceSingleton("PlayerSettings");
        }

        GUILayout.Space(4f);

        // Window sizing process at startup
        if (isStartup)
        {
            // Main window sizing
            this.minSize = minWindowSize;
            //windowScrollHeight = this.position.height;
            isStartup = false;
        }

        // Cache Cleaner
        guiBuilder.tooltip = "";
        guiBuilder.text = "";

        if (this.position.height < windowScrollHeight)
        {
            GUILayout.EndScrollView();
        }

        // Layout End
        GUILayout.EndVertical();

    }

}
