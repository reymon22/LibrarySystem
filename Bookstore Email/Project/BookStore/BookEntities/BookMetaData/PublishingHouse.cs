using System;


namespace BookEntities
{

    public class PublishingHouse : IBookMetaData, IComparable<PublishingHouse>
    {

        private Guid guid;
        private string name;


        public PublishingHouse(string name)
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
            if (!(obj is PublishingHouse))
                return false;
            else
                return (this.guid == ((PublishingHouse)obj).guid);
        }

        public int CompareTo(PublishingHouse other)
        {
            return name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return name;
        }

    }

}
