using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// is a varable that states if it has an empty string
        /// </summary>
        private bool _empty = false;
        /// <summary>
        /// adds the string to the trie
        /// </summary>
        /// <param name="s"></param> the string you want added
        /// <returns></returns> the resulting trie
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _empty = true;
                return this;
            }
            else
            { 
                return new TrieWithOneChild(s, _empty);
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
                return _empty;
            }
            else
            {
                return false;
            }
        }
    }
}
