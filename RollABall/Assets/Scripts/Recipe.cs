//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public abstract class Recipe
{

    private static  Dictionary<String, int> items;

    public static Dictionary<String, int> Items
    {
        get
        {
            return items;
        }
    }

    static Recipe()
    {

		items = new Dictionary<String, int>;
        items.Add("Annanas", 3);
        items.Add("Bananen", 15);
        items.Add("Schnittlauch", 25);
        items.Add("Salamandablut", 2);
    }

}


