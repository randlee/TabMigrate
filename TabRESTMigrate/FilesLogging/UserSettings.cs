using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace TabRESTMigrate.FilesLogging
{
    [Serializable]

    public class UserSettings
    {
        public static readonly string DefaultFilename = Path.Combine(PathHelper.UserAppDataDirectory(),
            "UserSettings.xml");

        [Obsolete("delegated to children", true)]
        public bool SavePassword { get; set; }

        public UploadUserSettings ImportTo { get; set; } = new UploadUserSettings();
        public InventoryUserSettings InventoryFrom { get; set; } = new InventoryUserSettings();
        public ExportUserSettings ExportFrom { get; set; } = new ExportUserSettings();
        /// <summary>
        /// Gets or sets the local path.
        /// </summary>
        /// <value>The local path.</value>
        public string LocalPath { get; set; }
    }

    [Serializable]
    public class UserCredentials
    {
        private readonly SimpleStringEncryption _crypt = new SimpleStringEncryption(WindowsIdentity.GetCurrent().Name);
        public string UserId { get; set; }
        public string UserPassword { get; set; } = Guid.NewGuid().ToString();
        public string ServerUrl { get; set; }
        public bool SavePassword { get; set; }
        public bool UserIsAdmin { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [generate tableau workbook].
        /// </summary>
        /// <value><c>true</c> if [generate tableau workbook]; otherwise, <c>false</c>.</value>
        public bool GenerateTableauWorkbook { get; set; }

        /// <summary>
        /// Encrypt strings before the serialization.
        /// </summary>
        /// <param name="context">The streaming context.</param>
        [OnSerializing]
        public void BeforeSerialization(StreamingContext context)
        {
            UserId = _crypt.Encrypt(UserId ?? "");
            UserPassword = _crypt.Encrypt(UserPassword ?? Guid.NewGuid().ToString());
            ServerUrl = _crypt.Encrypt(ServerUrl ?? "");
        }

        /// <summary>
        /// Decrypt strings after deserialization as well as after serialization which 
        /// decrypts them, so app data remains un-encrypted
        /// </summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        [OnSerialized] // Decrypt after serialization, so app data remains un-encrypted
        public void AfterDeserialization(StreamingContext context)
        {
            UserId = _crypt.Decrypt(UserId);
            UserPassword = _crypt.Decrypt(UserPassword);
            ServerUrl = _crypt.Decrypt(ServerUrl);
        }
    }

    [Serializable]
    public class UploadUserSettings : UserCredentials
    {

        /// <summary>
        /// Gets or sets the path to xml file with database credentials.
        /// </summary>
        /// <value>The database credentials path.</value>
        public string DatabaseCredentialsPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remap workbook data server references].
        /// </summary>
        /// <value><c>true</c> if [remap workbook datas erver references]; otherwise, <c>false</c>.</value>
        public bool RemapServerReferences { get; set; }
    }

    [Serializable]
    public class ExportUserSettings : UserCredentials
    {
        /// <summary>
        /// Gets or sets a value indicating whether to [remove tag when exporting].
        /// </summary>
        /// <value><c>true</c> if [remove tag when exporting]; otherwise, <c>false</c>.</value>
        public bool RemoveTagWhenExporting { get; set; }

        /// <summary>
        /// Gets or sets the export tag.
        /// Export only if tagged [string.IsNullOrEmpty()]
        /// </summary>
        /// <value>The export tag.</value>
        public string ExportTag { get; set; }

        /// <summary>
        /// Gets or sets the export project name.
        /// Export content from only a single project
        /// </summary>
        /// <value>The project to export.</value>
        public string ExportProject { get; set; }

    }

    [Serializable]
    public class InventoryUserSettings : UserCredentials
    {

    }
}