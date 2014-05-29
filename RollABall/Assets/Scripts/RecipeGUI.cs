//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
        
public class RecipeGUI : MonoBehaviour
{
    public GUISkin customSkin;
    private Rect window;

    public bool showRecipe = true;
    void drawRecipeWindow(int windowID)
    {
        
        Rect closeButton = new Rect();

        closeButton.width = 0.075f * window.width;
        closeButton.height = closeButton.width;

        closeButton.x =  window.width -  closeButton.width;

        if (GUI.Button(closeButton, "X"))
        {
            showRecipe = false;
        }



    }

    void Update() {
        if (Input.GetKeyDown("r"))
            showRecipe = !showRecipe;
        
    }
    
    void OnGUI()
    {
        
        GUI.skin = customSkin;

        if (!showRecipe)
        {
            return;
        }
        
        
        float w = 0.3f; // proportional width (0..1)
        float h = 0.7f; // proportional height (0..1)
        Rect rect = new Rect();
        rect.x = (float)(Screen.width * (1 - w)) / 2;
        rect.y = (float)(Screen.height * (1 - h)) / 2;
        rect.width = (float)Screen.width * w;
        rect.height = (float)Screen.height * h;

        
        // Make a background box
        window = GUI.Window(1, rect, drawRecipeWindow, "Recipe");
    }
}
