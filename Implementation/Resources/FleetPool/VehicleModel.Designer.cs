﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cares.Implementation.Resources.FleetPool {
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
    public class VehicleModel {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal VehicleModel() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Cares.Implementation.Resources.FleetPool.VehicleModel", typeof(VehicleModel).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Model with same code already exists ! Try different code!.
        /// </summary>
        public static string VehicleModelCodeDuplicationError {
            get {
                return ResourceManager.GetString("VehicleModelCodeDuplicationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Model is Associated With Hire Group Detail.
        /// </summary>
        public static string VehicleModelIsAssociatedWithHireGroupDetailError {
            get {
                return ResourceManager.GetString("VehicleModelIsAssociatedWithHireGroupDetailError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Model is associated with Sessional Discount.
        /// </summary>
        public static string VehicleModelIsAssociatedWithSessionalDiscountError {
            get {
                return ResourceManager.GetString("VehicleModelIsAssociatedWithSessionalDiscountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Model is associated with Standard Discount.
        /// </summary>
        public static string VehicleModelIsAssociatedWithStandardDiscountError {
            get {
                return ResourceManager.GetString("VehicleModelIsAssociatedWithStandardDiscountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vehicle Model is associated with Vehicle.
        /// </summary>
        public static string VehicleModelIsAssociatedWithVehicleError {
            get {
                return ResourceManager.GetString("VehicleModelIsAssociatedWithVehicleError", resourceCulture);
            }
        }
    }
}
