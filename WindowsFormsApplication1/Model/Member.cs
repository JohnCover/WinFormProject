using System;

namespace Lab2
{

   
    /// <summary>
    /// Represents a member of a gym.
    /// Stores identifying member information.
    /// </summary>
    public class Member
    {
        private String firstName;
        private String lastName;
        private String email;

        public Member()
        {
            firstName = "N/A";
            lastName = "N/A";
            email = "N/A";
        }

        public Member(String firstName, String lastName, String email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }


        /// <summary>
        /// property method for setting and getting firstName private field.
        /// </summary>
        public String FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length > 25)
                    throw new System.ArgumentException("String parameter cannot be longer than 25 characters.", "firstName");
                else
                    this.firstName = value;
            }
        }

        /// <summary>
        /// property method for setting and getting lastName private field.
        /// </summary>
        public String LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length > 25)
                    throw new System.ArgumentException("String parameter cannot exceed 25 characters.", "lastName");
                else
                    this.lastName = value;
            }
        }

        /// <summary>
        /// property method for setting and getting email private field.
        /// </summary>
        public String Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (value.Length > 25)
                    throw new System.ArgumentException("String parameter cannot be longer than 25 characters.", "email");
                else
                    this.email = value;
            }
        }

        /// <summary>
        /// Similar functionality to toString().  Provides a string representation of a member object,
        /// and is used in saving member objects to data files.
        /// </summary>
        /// <returns>string representation of member object</returns>
        public String getDisplayText()
        {
            return this.firstName + " " + this.lastName + " - " + this.email;
        }

    }
}
