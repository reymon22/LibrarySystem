using System;


namespace BookEntities
{

    public class Tag : IBookMetaData, IComparable<Tag>
    {

        private Guid guid;
        private string name;


        public Tag(string name)
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
            if (!(obj is Tag))
                return false;
            else
                return (this.guid == ((Tag)obj).guid);
        }

        public int CompareTo(Tag other)
        {
            return name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return name;
        }
    }

}
