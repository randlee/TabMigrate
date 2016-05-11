namespace TabRESTMigrate.RESTHelpers
{
    partial class CredentialManager
    {
        internal class Credential
        {
            public string Name { get; }
            public string Password { get; }
            public bool IsEmbedded { get; }

            public Credential(string name, string password, bool isEmbedded)
            {
                Name = name;
                Password = password;
                IsEmbedded = isEmbedded;
            }
        }

    }
}
