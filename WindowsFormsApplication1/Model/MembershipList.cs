using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

namespace Lab2
{
    /// <summary>
    /// Maintains a list of members that subscibe to a gym service
    /// </summary>
    class MembershipList
    {
        ArrayList listOfMembers;
        int count;
        public delegate void changeHolder(MembershipList list);
        public event changeHolder Changed;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MembershipList()
        {
            listOfMembers = new ArrayList();
            int count = 0;
        }


        /// <summary>
        /// Displays the current number of members in the list
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        /// <summary>
        /// This is the method that is called to invoke, or "raise" the event changeHolder.
        /// </summary>
        /// <param name="e">custom event argument</param>
        public virtual void OnChanged(MembershipList e)
        {
            Changed?.Invoke(e);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">a list holding member objects representing the gym members</param>
        public MembershipList(ArrayList list)
        {
            this.count = list.Count;
            this.listOfMembers = list;
        }

        /// <summary>
        /// Indexed property
        /// </summary>
        /// <param name="index">an index</param>
        /// <returns>the member object located at index location provoided</returns>
        public Member this[int index]
        {
            get
            {
                return (Member)listOfMembers[index];
            }
            set
            {
                listOfMembers[index] = value;
                OnChanged(this);
            }
        }

        /// <summary>
        /// Adds a member to the list
        /// </summary>
        /// <param name="m">the member object to add to the list of members</param>
        public void add(Member m)
        {
            listOfMembers.Add(m);
            count++;
            OnChanged(this);
        }

        /// <summary>
        /// removes a member for the list
        /// </summary>
        /// <param name="m"></param>
        public void remove(Member m)
        {
            listOfMembers.Remove(m);
            count--;
            OnChanged(this);
        }

        /// <summary>
        /// Fill the list with membership data from the Membership data file using the GetMemberships
        /// method of the MembershipData class
        /// </summary>
        /// <param name="path"></param>
        public void write(string path)
        {
            string[] lines = MembershipData.GetMemberships(path);
            string[] data;
            char[] delimiterChars = { ' ', ',', '-', };

            foreach (string s in lines)
            {
                data = s.Split(delimiterChars);
                add(new Member(data[0], data[1], data[4]));
            }
        }

        /// <summary>
        ///  Saves the memberships to a file using the SaveMemberships method of the MembershipData class
        /// </summary>
        /// <param name="path">the directory of the data file</param>
        public void save(string path)
        {
            //ArrayList export = new ArrayList();
            string[] export = new string[listOfMembers.Count];
            int i = 0;
            foreach (Member m in listOfMembers)
            {
                export[i]=(m.getDisplayText());
                i++;
            }

            //save to file
            MembershipData.SaveMemberships(path, export);
        }

        /// <summary>
        /// operator overload, binary operator +, adds member to membershipList class.
        /// </summary>
        /// <param name="membership"> the list of members to be updated</param>
        /// <param name="m">the member object being added to the list of members</param>
        /// <returns></returns>
        public static MembershipList operator +(MembershipList membership, Member m)
        {
            membership.add(m);
            return membership;
        }

        /// <summary>
        /// operator overload, binary operator -, subtracts member to membershipList class
        /// </summary>
        /// <param name="membership">the membershipList to be edited</param>
        /// <param name="m">the member to be removed</param>
        /// <returns></returns>
        public static MembershipList operator -(MembershipList membership, Member m)
        {
            membership.remove(m);
            return membership;
        }
    }
}
