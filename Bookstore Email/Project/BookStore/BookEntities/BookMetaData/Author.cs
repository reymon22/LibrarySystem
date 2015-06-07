using System;


namespace BookEntities
{
    
    public class Author : IBookMetaData, IComparable<Author>
    {

        private Guid guid;
        private string name;


        public Author(string name)
        {
            this.guid = Guid.NewGuid();
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Author))
                return false;
            else
                return (this.guid == ((Author)obj).guid);
        }

        public int CompareTo(Author other)
        {
            return name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return name;
        }

    }

}
