using System;
using System.IO;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    /// <summary>
    ///
    /// </summary>
    public class MenuFile
    {
        /// <summary>
        /// Gets or sets the preferences.
        /// </summary>
        /// <value>
        /// The preferences.
        /// </value>
        protected dynamic Preferences { get; set; }

        /// <summary>
        /// Gets or sets the preference file.
        /// </summary>
        /// <value>
        /// The preference file.
        /// </value>
        protected virtual dynamic PreferenceFile
        {
            get { return Preferences.Files.MenuFile; }
            set { Preferences.Files.MenuFile = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuFile"/> class.
        /// </summary>
        /// <param name="acadPreferences">The acad preferences.</param>
        public MenuFile(object acadPreferences)
        {
            Preferences = acadPreferences;
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path
        {
            get
            {
                return PreferenceFile;
            }
            set
            {
                if (File.Exists(value) && System.IO.Path.GetExtension(value).Equals(".cuix", StringComparison.OrdinalIgnoreCase))
                {
                    PreferenceFile = value;
                }
                else
                {
                    PreferenceFile = Environment.ExpandEnvironmentVariables(@"%appdata%\Autodesk\AutoCAD 2016\R20.1\enu\support\acad");
                }
            }
        }
    }
}