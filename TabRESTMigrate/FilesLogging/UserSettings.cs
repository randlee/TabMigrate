using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace TabRESTMigrate.FilesLogging
{
    [Serializable]
    public class UserSettings
    {
        public static readonly string DefaultFilename = Path.Combine(PathHelper.UserAppDataDirectory(), "UserSettings.xml");
        public bool SavePassword { get; set; }
        public UserCredentials ImportTo { get; set; } = new UserCredentials();
        public UserCredentials InventoryFrom { get; set; } = new UserCredentials();
        public UserCredentials ExportFrom { get; set; } = new UserCredentials();
    }

    [Serializable]
    public class UserCredentials
    {
        private SimpleStringEncryption crypt = new SimpleStringEncryption(WindowsIdentity.GetCurrent().Name);
        public string UserId { get; set; }
        public string UserPassword { get; set; } = Guid.NewGuid().ToString();
        public string ServerUrl { get; set; }
        /// <summary>
        /// Befores the serialization.
        /// </summary>
        /// <param name="context">The context.</param>
        [OnSerializing]
        public void BeforeSerialization(StreamingContext context)
        {
            var crypt = new SimpleStringEncryption(WindowsIdentity.GetCurrent().Name);
            UserId = crypt.Encrypt(UserId);
            UserPassword = crypt.Encrypt(UserPassword);
            ServerUrl = crypt.Encrypt(ServerUrl);
        }

        [OnDeserialized]
        [OnSerialized]      // Decrypt after serialization, so app data remains un-encrypted
        public void AfterDeserialization(StreamingContext context)
        {
            UserId = crypt.Decrypt(UserId);
            UserPassword = crypt.Decrypt(UserPassword);
            ServerUrl = crypt.Decrypt(ServerUrl);
        }
    }
}