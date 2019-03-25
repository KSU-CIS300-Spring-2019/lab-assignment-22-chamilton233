using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// is a varable that states if it has an empty string
        /// </summary>
        private bool _hasEmptyString = false;
        /// <summary>
        /// the child of this tree
        /// </summary>
        private ITrie _child;
        /// <summary>
        /// the char associated with this trie
        /// </summary>
        private char _label;
        /// <summary>
        /// the constuctor for a trie with one child
        /// </summary>
        /// <param name="s"></param> the string you want stored as a trie
        /// <param name="empty"></param> weather the sting is empty
        public TrieWithOneChild(string s, bool empty)
        {
            if (s == "" || s[0] > 'z' || s[0] < 'a')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = empty;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }
            

        /// <summary>
        /// adds the string to the trie
        /// </summary>
        /// <param name="s"></param> the string you want added
        /// <returns></returns> the resulting trie
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s[0] == _label)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _child);
            }
        }
        /// <summary>
        /// checks the trie for if it contains this trie
        /// </summary>
        /// <param name="s"></param> teh string you want added
        /// <returns></returns> weather it found it or not
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            if (s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            return false;
        }
    }
}
