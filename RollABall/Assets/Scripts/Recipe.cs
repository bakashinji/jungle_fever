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
namespace AssemblyCSharp
{
    public abstract class Recipe
    {
        public Recipe()
        {
        }

       

        private static Dictionary<Collectible, int> content;

        public static void  foundCollectible(Collectible c)
        {
            if (content.ContainsKey(c))
            {
                if(content[c] > 1)
                {
                    content[c]--;
                }
                else
                {
                    content.Remove(c);
                }
            }

            if (content.Count == 0)
            {
                this.onFinishedRecipe();
            }

        }

        private void onFinishedRecipe()
        {
        }


    }
