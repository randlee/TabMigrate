using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TabRESTMigrate.FilesLogging
{
    /// <summary>
    /// Stores an item of status
    /// </summary>
    public class StatusItem
    {
        public string Text { get; private set; }
        public DateTime When { get; private set; }

        public StatusItem(string text)
        {
            When = DateTime.Now;
            Text = text;
        }

        public override string ToString()
        {
            return $"{When}, {Text}";
        }
    }

    /// <summary>
    /// Generic threadsafe class for maintaining a log of items
    /// </summary>
    public class Logger : IReadOnlyList<StatusItem>
    {
        //Thread lock
        private readonly object _lockStatus = new object();

        readonly List<StatusItem> _status = new List<StatusItem>();
        public string StatusText
        {
            get
            {
                var sb = new StringBuilder();

                lock (_lockStatus)
                {
                    //No status?
                    var statusList = _status;
                    if (statusList.Count == 0)
                    {
                        return "";
                    }

                    var previousWhen = _status[0].When;

                    //Go in reverse order to show the last first
                    for (int idx = 0; idx < statusList.Count; idx++)
                    {
                        var thisItem = statusList[idx];
                        //For readability, add a blank line if the current time differs from the previous time by more than a defined-delta
                        var timeDeltaSeconds = Math.Abs((previousWhen - thisItem.When).TotalSeconds);
                        if(timeDeltaSeconds > 15)
                        {
                            sb.AppendLine();
                        }

                        //Append the line
                        sb.AppendLine(idx.ToString("000") + ",  " + statusList[idx]);
                        //Advance the date counter
                        previousWhen = thisItem.When;
                    }
                }

                return sb.ToString();
            }
        }

        public int Count => _status.Count;


        /// <summary>
        /// Add an item to the status list
        /// </summary>
        /// <param name="statusText"></param>
        public void AddStatus(string statusText)
        {
            var statusItem = new StatusItem(statusText);
            //string textWithTime = DateTime.Now.ToString() + ": " + statusText;
            lock (_lockStatus)
            {
                _status.Add(statusItem);
            }
        }

        #region Implementation of IEnumerable

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<StatusItem> GetEnumerator()
        {
            lock (_lockStatus)
            {
                return _status.GetEnumerator();
            }
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of IReadOnlyList<out string>

        /// <summary>Gets the element at the specified index in the read-only list.</summary>
        /// <returns>The element at the specified index in the read-only list.</returns>
        /// <param name="index">The zero-based index of the element to get. </param>
        public StatusItem this[int index]
        {
            get
            {
                lock (_lockStatus)
                {
                    return _status[index];
                }
            }
        }

        #endregion
    }
}
