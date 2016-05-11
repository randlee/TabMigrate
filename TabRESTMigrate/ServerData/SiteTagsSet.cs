using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TabRESTMigrate.FilesLogging;
using TabRESTMigrate.RESTHelpers;

namespace TabRESTMigrate.ServerData
{
    /// <summary>
    /// Information about Tags associated with content in a site
    /// </summary>
    public class SiteTagsSet : ITagSetInfo, IReadOnlyList<SiteTag>
    {
        private readonly IReadOnlyList<SiteTag> _tags;
        public IReadOnlyList<SiteTag> Tags => _tags;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tagsNode">'tags' XML node</param>
        public SiteTagsSet(XmlNode tagsNode)
        {
            if (tagsNode.Name.ToLower() != "tags")
            {
                AppDiagnostics.Assert(false, "Not tags");
                throw new Exception("Unexpected content - not tags");
            }

            //Namespace for XPath queries
            var nsManager = XmlHelper.CreateTableauXmlNamespaceManager("iwsOnline");

            //Build a set of tags
            var tags = new List<SiteTag>();
            //Get the project tags
            var tagsSet = tagsNode.SelectNodes("iwsOnline:tag", nsManager);
            if(tagsSet == null) throw new NullReferenceException("Tagset missing in XMLNode");
            foreach(var tagNode in tagsSet)
            {
                var newTag = new SiteTag((XmlNode) tagNode);
                tags.Add(newTag);

            }
            _tags = tags.AsReadOnly();
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SiteTag> GetEnumerator()
        {
            return _tags.GetEnumerator();
        }

        /// <summary>
        /// String representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "tags: " + TagSetText;
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _tags).GetEnumerator();
        }


        /// <summary>
        /// Text of the tag set
        /// </summary>
        public string TagSetText
        {
            get
            {
                if (_tags == null) return "";

                var sb = new StringBuilder();
                var numItems = 0;
                foreach (var tag in _tags)
                {
                    if (numItems > 0)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(tag.Label);
                    numItems++;
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// True of the specified tag can be found in the set
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool IsTaggedWith(string tag)
        {
            //No tags?
            return _tags != null && _tags.Any(thisTag => thisTag.Label == tag);

            //Look for hte tag
        }

        #region Implementation of IReadOnlyCollection<out SiteTag>

        /// <summary>Gets the number of elements in the collection.</summary>
        /// <returns>The number of elements in the collection. </returns>
        public int Count => _tags.Count;

        #endregion

        #region Implementation of IReadOnlyList<out SiteTag>

        /// <summary>Gets the element at the specified index in the read-only list.</summary>
        /// <returns>The element at the specified index in the read-only list.</returns>
        /// <param name="index">The zero-based index of the element to get. </param>
        public SiteTag this[int index] => _tags[index];

        #endregion
    }
}
