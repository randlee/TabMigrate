using System;
using System.Collections.Generic;
using System.Xml;
using TabRESTMigrate.FilesLogging;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about a Grou[ in a Server's site
    /// </summary>
    public class SiteGroup : IHasSiteItemId
    {
        public string Id { get; }
        public string Name { get; }
        private List<SiteUser> UsersInGroup { get; }
        //    public string DomainName  { get; }

        /// <summary>
        /// Any developer/diagnostic notes we want to indicate
        /// </summary>
        public string DeveloperNotes { get; }

        /// <summary>
        /// Returns the list of users associated with this group
        /// </summary>
        public ICollection<SiteUser> Users => UsersInGroup.AsReadOnly();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectNode"></param>
        /// <param name="usersToPlaceInGroup"></param>
        public SiteGroup(XmlNode projectNode, IEnumerable<SiteUser> usersToPlaceInGroup )
        {
            //If we were passed in a set of users, store them
            var usersList = new List<SiteUser>();
            if(usersToPlaceInGroup != null)
            {
                usersList.AddRange(usersToPlaceInGroup);
            }
            UsersInGroup = usersList;


            if(projectNode.Name.ToLower() != "group")
            {
                AppDiagnostics.Assert(false, "Not a group");
                throw new Exception("Unexpected content - not group");
            }

            Id = projectNode.Attributes["id"].Value;
            Name = projectNode.Attributes["name"].Value;
//        this.DomainName = projectNode.Attributes["description"].Value;
        }


        public override string ToString()
        {
            return "Group: " + Name + "/" + Id;
        }

        /// <summary>
        /// Adds a set of users.  This is typically called when initializing this object.
        /// </summary>
        /// <param name="usersList"></param>
        internal void AddUsers(IEnumerable<SiteUser> usersList)
        {
            //Nothing to add?
            if (usersList == null)
            {
                return;
            }

            UsersInGroup.AddRange(usersList);
        }

        string IHasSiteItemId.Id => Id;
    }
}
