using System;
using System.Transactions;

namespace Williams_linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkLists ll = new LinkLists();

            string choice = "";

            while (choice != "6")
            {
                Console.WriteLine("What would you like to do?: ");
                Console.WriteLine("");
                Console.WriteLine("1. Show Head");
                Console.WriteLine("2. Add Item");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. Search for Item");
                Console.WriteLine("5. Print");
                Console.WriteLine("6. Exit");
                choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        if (ll.getFirst() == null)
                        {
                            Console.WriteLine("There is no head.\n");
                        }
                        else {
                            Console.WriteLine(ll.getFirst().data + "\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine("What are we adding: ");
                        string add = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Add to begining or end?");
                        Console.WriteLine("B for begining, E for end: ");
                        string where = Console.ReadLine().ToUpper();

                        while (where != "B" && where != "E")
                        {
                            Console.WriteLine("Invalid Option, Try Again: ");
                            where = Console.ReadLine().ToUpper();
                        }
                        if (where == "B")
                        {
                            ll.addFirst(add);
                            Console.WriteLine("\"" + add +"\" was added to the front of the list!");
                        }
                        else
                        {
                            ll.addToEnd(add);
                            Console.WriteLine("\"" + add + "\" was added to the back of the list!");
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("What are we removing: ");
                        string remove = Console.ReadLine();
                        if (ll.Contains(remove) == null)
                        {
                            Console.WriteLine("No matching words, not Removed.\n");
                        }
                        else {
                            ll.Remove(remove);
                            Console.WriteLine("Removed \"" + remove + "\"\n");
                        }
                        break;
                    case "4":
                        Console.WriteLine("What are we looking for: ");
                        string find = Console.ReadLine();
                        Console.WriteLine();

                        if (ll.Contains(find) == null)
                        {
                            Console.WriteLine("Does not contain the word \"" + find + "\"\n");
                        }
                        else {
                            Console.WriteLine("Contains the word \"" + find + "\"\n");
                        }
                        break;
                    case "5":
                        Console.WriteLine(ll.PrintNodes());
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option: Try Again");
                        break;

                }
            }
        }
    }

    public class Node
    {
        public string data;
        public Node next;

        public Node(string data)
        {
            this.data = data;
            next = null;
        }
    }

    public class LinkLists
    {
        Node head;
        //Returns a reference to the first node; if no first, return null
        public Node getFirst()
        {
            if (head == null)
            {
                return null;
            }
            else
            {
                return head;
            }
        }
        //Add a new node to the front of the list
        public void addFirst(string data)
        {
            Node newData = new Node(data);
            newData.next = head;
            head = newData;
        }
        public void addToEnd(string data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new Node(data);
            }
        }
        //Returns a node with a matching item; if no match, return null
        public Node Contains(string item)
        {
            Node current = head;
            if (head == null)
            {
                return null;
            }
            while (current != null)
            {
                if (current.data == item)
                {
                    return current;
                }
                if (current.next == null)
                {
                    return null;
                }
                current = current.next;
            }
            return null;
        }
        //Removes node containing the item and links the two adjacent nodes together
        public void Remove(string item)
        {
            Node current = head;
            while (current != null)
            {
                Node next = current.next;
                if (current.data == item)
                {
                    head = next;
                    break;
                }
                if (next.data == item)
                {
                    current.next = next.next;
                    break;
                }
                current = current.next;
            }
        }
        //Prints the entire list front to back. Breaking encapsulation here is permitted
        public string PrintNodes()
        {
            Node current = head;
            string list = "";
            if (head == null)
            {
                return "This list empty! Crazy dawg!\n";
            }
            else
            {
                while (current != null)
                {
                    list += current.data + "\n";
                    current = current.next;
                }
                return list;
            }
        }
    }
}