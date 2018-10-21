using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingSection
{
    /// <summary>
    /// the object contain one classroom.
    /// </summary>
    class Classroom
    {
        /// <summary>
        /// The section nubmer to working now.
        /// </summary>
        int _sectionNumber;
        /// <summary>
        /// Is voting start now.
        /// </summary>
        Boolean _buttonEnable;
        /// <summary>
        /// The names of sections.
        /// </summary>
        string[] _section;
        /// <summary>
        /// The list to record the socre for each section.
        /// </summary>
        private List<VoteController> _voteSections;
        /// <summary>
        /// The list to record the voted sutdents IDs.
        /// </summary>
        private List<List<int>> _votedList;

        /// <summary>
        /// Generate a new classroom with number of sections.
        /// </summary>
        /// <param name="numberOfsections">how</param>
        public Classroom(int numberOfsections)
        {
            _sectionNumber = 0;
            _buttonEnable = false;
            _section = new string[numberOfsections];
            _voteSections = new List<VoteController>(new VoteController[numberOfsections]);
            _votedList = new List<List<int>>(numberOfsections);
        }
        /// <summary>
        /// give the name to the section.
        /// </summary>
        /// <param name="name">the name for section.</param>
        /// <param name="section">the number of section.</param>
        /// <returns>if success.</returns>
        public Boolean NameSection(string name, int section)
        {
            if(section >= _section.Length || section < 0)
            {
                return false;
            }
            else
            {
                _section[section] = name;
                return true;
            }
        }

        /// <summary>
        /// change the name to the section.
        /// </summary>
        /// <param name="name">the new name for section.</param>
        /// <param name="section">the number of section.</param>
        /// <returns>if success.</returns>
        public Boolean ChangeSectionName(string name, int section)
        {
            if (section >= _section.Length || section < 0)
            {
                return false;
            }
            else
            {
                _section[section] = name;
                return true;
            }
        }

        /// <summary>
        /// display the sections line by line.
        /// </summary>
        /// <returns>the section names as string.</returns>
        public string ShowSectionNames()
        {
            string s = "";
            foreach(string name in _section)
            {
                s += name + "\n";
            }
            return s;
        }

        /// <summary>
        /// Change the current section working for.
        /// </summary>
        /// <param name="i">the index of section.</param>
        public void ChangeSection(int i)
        {
            _sectionNumber = i;
        }

        /// <summary>
        /// Start the vote.
        /// </summary>
        public void StartVote()
        {
            _buttonEnable = true;
        }

        /// <summary>
        /// Stop the vote.
        /// </summary>
        public void StopVote()
        {
            _buttonEnable = false;
        }

        /// <summary>
        /// try to vote.
        /// </summary>
        /// <param name="i">the score give.</param>
        /// <param name="id">the id of voting student.</param>
        /// <returns>if vote success.</returns>
        public Boolean Voting(int i, int id)
        {
            if (_votedList[_sectionNumber].Contains(id))
            {
                return false;
            }
            else
            {
                _votedList[_sectionNumber].Add(id);
                _voteSections[_sectionNumber].MakeVote(i);
                return true;
            }
        }

        /// <summary>
        /// try to remove the vote.
        /// </summary>
        /// <param name="i">the score voted.</param>
        /// <param name="id">the id of voting student.</param>
        /// <returns>if vote cancelled.</returns>
        public Boolean ResetVote(int i,int id)
        {
            if (!_votedList[_sectionNumber].Contains(id))
            {
                return false;
            }
            else
            {
                _votedList[_sectionNumber].Remove(id);
                _voteSections[_sectionNumber].RemoveVote(i);
                return true;
            }
        }

        /// <summary>
        /// show the understanding score for the class.
        /// </summary>
        /// <returns>The result.</returns>
        public string ShowScore()
        {
            string s = "";
            for(int i = 0 ;i < _section.Length; i++)
            {
                s += "The understanding of section: " + _section[i] + " is " + _voteSections[i].RankSection() +"\n";
            }
            s += "if score is 0, it means no one vote on this section.";
            return s;
        }
    }
}
