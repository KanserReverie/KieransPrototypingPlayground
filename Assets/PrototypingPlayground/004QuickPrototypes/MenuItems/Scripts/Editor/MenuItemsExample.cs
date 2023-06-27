using UnityEditor;
using UnityEngine;
// ReSharper disable All

namespace PrototypingPlayground._004QuickPrototypes.MenuItems.Scripts
{
    /// <summary>
    ///
    /// These are all the things you can do with menu items.
    /// 
    /// Using this tutorial! :)
    /// 
    /// https://learn.unity.com/tutorial/scripting-community-posts#
    /// 
    /// </summary>
    public class MenuItemsExample : MonoBehaviour
    {
        // Add a new menu item under an existing menu

        [MenuItem("Window/New Option")]
        private static void NewMenuOptionUnderWindowMenu()
        {
        }

        // Add a menu item with multiple levels of nesting

        [MenuItem("Tools/SubMenu/Option")]
        private static void NewNestedOptionInNewToolsMenu()
        {
        }
        
        // Hotkeys
        // To allow power users and keyboard junkies to work faster, new menu items can be assigned with hotkeys – shortcut key combinations that will automatically launch them.
        // These are the supported keys (can also be combined together):
        // % – CTRL on Windows / CMD on OSX
        // # – Shift
        // & – Alt
        // LEFT/RIGHT/UP/DOWN – Arrow keys
        // F1…F2 – F keys
        // HOME, END, PGUP, PGDN
        
        // Add a new menu item with hotkey CTRL-SHIFT-A

        [MenuItem("Tools/New Option %#a")]
        private static void NewMenuOptionWithHotkey1()
        {
        }

        // Add a new menu item with hotkey CTRL-G=
        [MenuItem("Tools/Item %g")]
        private static void NewMenuOptionWithHotkey2()
        {
        }

        // Add a new menu item with hotkey G
        [MenuItem("Tools/Item2 _g")]
        private static void NewMenuOptionWithHotkey3()
        {
        }
        
        // Special Paths
        // As seen, the path passed to the MenuItem attribute controls under which top level menu the new item will be placed.

        // Unity has a few “special” paths that act as context menus (menus that are accessible using right-click):
        
        //      Assets                  – items will be available under the “Assets” menu, as well using right-click inside the project view.
        
        //      Assets/Create           – items will be listed when clicking on the “Create” button in the project view (useful when adding new types that can be added to the project)
        
        //      CONTEXT/ComponentName   – items will be available by right-clicking inside the inspector of the given component.

        
        // Add a new menu item that is accessed by right-clicking on an asset in the project view
        [MenuItem("Assets/Load Additive Scene")]
        private static void LoadAdditiveScene()
        {
            var selected = Selection.activeObject;
#pragma warning disable 618
            EditorApplication.OpenSceneAdditive(AssetDatabase.GetAssetPath(selected));
#pragma warning restore 618
        }

        // Adding a new menu item under Assets/Create
        [MenuItem("Assets/Create/Add Configuration")]
        private static void AddConfig()
        {
            // Create and add a new ScriptableObject for storing configuration
        }
        
        // Add a new menu item that is accessed by right-clicking inside the RigidBody component
        [MenuItem("CONTEXT/Rigidbody/New Option")]
        private static void NewOpenForRigidBody()
        {
        }
        
        // Validation
        // If you want to show your menu option not all the time we can use validation.
        
        // For example, Validation methods can be used to add a right-click menu to Texture assets only under the project view:
        
        [MenuItem("Assets/ProcessTexture")]
        private static void DoSomethingWithTexture()
        {
        }
        
        // Note that we pass the same path, and also pass "true" to the second argument.
        [MenuItem("Assets/ProcessTexture", true)]
        private static bool NewMenuOptionValidation()
        {
            // This returns true when the selected object is a Texture2D (the menu item will be disabled otherwise).
            return Selection.activeObject is not null && Selection.activeObject is Texture2D;
        }
        
        // ------------ Note ------------
        // When right-clicking on anything that is not a texture in the project view,
        // the menu item option will be disabled (greyed out).
        // ------------ ---- ------------
        
        // Priority
        // Menu items can be moved in priority.
        // Every 50 (Example 0-50, 50-100 ... ) will show  their own group and be in numbered order up in.
        
        [MenuItem("NewMenu/Option1", false, 1)]
        private static void NewMenuOption()
        {
        }

        [MenuItem("NewMenu/Option2", false, 2)]
        private static void NewMenuOption2()
        {
        }

        [MenuItem("NewMenu/Option3", false, 3)]
        private static void NewMenuOption3()
        {
        }

        [MenuItem("NewMenu/Option4", false, 51)]
        private static void NewMenuOption4()
        {
        }

        [MenuItem("NewMenu/Option5", false, 52)]
        private static void NewMenuOption5()
        {
        }
        
        [MenuItem("CONTEXT/RigidBody/New Option")]
        private static void NewMenuOption(MenuCommand menuCommand)
        {
            // The RigidBody component can be extracted from the menu command using the context field.
            var rigid = menuCommand.context as Rigidbody;
        }
    }
}
