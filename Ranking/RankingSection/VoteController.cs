using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RankingSection
{
    class VoteController
    {
        /// <summary>
        /// List to stores the vote from students.
        /// </summary>
        private List<int> _list = new List<int> { 0, 0, 0, 0, 0};

        /// <summary>
        /// method to add vote to the list.
        /// </summary>
        /// <param name="i">The rank student make for this section.</param>
        public void MakeVote(int i)
        {
            _list[i]++;
        }

        /// <summary>
        /// method to remove the vote.
        /// </summary>
        /// <param name="i"></param>
        public void RemoveVote(int i)
        {
            _list[i]--;
        }

        /// <summary>
        /// find final score for this section understanding.
        /// </summary>
        /// <returns>the secore got.</returns>
        public double RankSection()
        {
            double sum = 0;
            int count = 0;
            for(int i = 0; i < 5; i++)
            {
                count += _list[i];
                sum += (i + 1) * _list[i];
            }
            sum = sum / count;
            return Math.Round(sum, 2);
        }
    }
}
