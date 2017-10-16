## **CECS 475  
ASSIGNMENT 2**  
Assigned date: 2/2  
Due date: 2/14  
20 points

**PreLab**

*   Review the lecture note on [indexers,delegates, events, and operators.](../pdf/delegatevent.pdf) (pdf)
*   Do the tutorial to create a [Windows forms application project](https://msdn.microsoft.com/en-us/library/dd492132.aspx)   (link)
*   [Code examples to read and write data in text files](lab2filenote.html)
*   [Listbox control](https://www.dotnetperls.com/listbox)

In this lab assignment, you'll will create a Fitness Membership Maintenance application that uses classes described below.

**Class Member**  
Private properties:  
firstName;  
lastName;  
email;

Implement the following features:

*   default argument constructor
*   argument constructor
*   property methods  
    Throw an exception if the value of first name, last name, or email in longer than 25 characters.
*   method public string GetDisplayText()  
    The method return the following string  
    First name Last name  - email

**Class MembershipList  
**Private properties  
members - a list of membership objects

Implement the following members:

*   default argument constructor - Creates a new list of membership objects.
*   indexer - Provides access to the Membership at the specified position
*   property Count - An integer that indicates how many membership objects are in the list.
*   Methods:
    *   Add(Membership) - Add a specified Membership object to the list
    *   Remove(Membership) - Remove the specified Membership from the list.
    *   Write( ) - Fill the list with membership data from the Membership data from a file using the GetMemberships method of the MembershipData class
    *   Save( ) - Saves the memberships to a file using the SaveMemberships method of the MembershipData class.
    *   Add overloaded operator + and - operators that add and remove a membership from the membership list
*   Events - add a delegate and an event to the MembershipList class
    *   Add a delegate named ChangeHandler. This delegate specify a method with void return type and a MembershipList parameter.
    *   Add event named Changed to the MembershipList class. This event should use the ChangeHandler delegate and should be raised any time when the membership list changes.
    *   Modify the Membership Maintenance form to use the Changed event to save the memberships and refresh the list box any time the list changes. To do that, you'll need to code and event handler that has signature specified by the delegate, you'll need to wire the event handler to the event for the Save and Delete buttons.
    *   Modify the statement that wires an event handler to the event so it uses a lambda expression.

**Next you design and implement the Windows forms.**

![](../images/membershipmaintenance.png)

           The Membership Maintenance form displays a list of memberships that are stored in a file in a list box. The user can use this form to add or delete a  
           delete a membership.  

           If the user clicks the Add button, the New Membership is displayed as a dialog box.  

          ![](../images/membershipadd.png)  

           Then, the user can enter the data for a new membership and click Save button to add the membership to the file. After the member is saved, the list box in  
            the Membership Maintenance form is refreshed to it includes the new membership. The user can also click the Cancel button on the New Membership  
            from to cancel the add operation.  
            To delete a membership, the user selects the membership in the list and click the Delete button, then a dialog box is displayed to confirm the  
            operation. If the operation is confirmed, the membership is deleted and the list box is refreshed so it no longer includes the deleted product.

**Grading**

*   Demonstrate the lab assignment to the instructor in the lab
*   Submit the lab assignment to the BeachBoard
*   Return a printed copy by with the following information:
    1.  Code that uses indexers
    2.  Code that overloads + operator and - operator  
        What code do you use to substitue those operator?
    3.  Code to use the Changed Changed event to save the memberships and refresh the list box any time the list change
    4.  Code to wire the event handler to the event for the Save.
    5.  Code to open the Add form
    6.  Code to transfer data from the Add form to the Membership Maintenance form to the