﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mud.Domain {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StaticMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StaticMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Mud.Domain.StaticMessages", typeof(StaticMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Podaj nazwe postaci, lub wpisz &apos;nowy&apos;:.
        /// </summary>
        internal static string choosePlayerPrompt {
            get {
                return ResourceManager.GetString("choosePlayerPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to =================================
        ///=====Tworzenie nowej postaci=====
        ///=================================.
        /// </summary>
        internal static string newPlayerStart {
            get {
                return ResourceManager.GetString("newPlayerStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Serwer został wyłączony. Połączenie przerwane....
        /// </summary>
        internal static string serverShutDown {
            get {
                return ResourceManager.GetString("serverShutDown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  &amp;r           _ ._  _ , _ ._
        /// &amp;Y         (_ &apos; ( `  )_  .__)
        /// &amp;Y       ( (  (    )   `)  ) _)
        /// &amp;R      (__ (_   (_ . _) _) ,__)
        /// &amp;R          `~~`\ &apos; . /`~~`
        /// &amp;W          ,::: ;   ; :::,
        /// &amp;w         &apos;:::::::::::::::&apos;
        /// &amp;Y _____________/_ __ \____________
        /// &amp;W  Welcome to Fallout MUD by Jahol
        ///.
        /// </summary>
        internal static string splashScreen {
            get {
                return ResourceManager.GetString("splashScreen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Postac o podanej nazwie nie istnieje. Rozlaczam....
        /// </summary>
        internal static string wrongPlayerName {
            get {
                return ResourceManager.GetString("wrongPlayerName", resourceCulture);
            }
        }
    }
}
