using System;


namespace BookEntities
{

    public class YearOfPublishing : IBookMetaData, IComparable<YearOfPublishing>
    {

        private Guid guid;
        private int year;


        public YearOfPublishing(int year)
        {
            this.guid = Guid.NewGuid();
            this.year = year;
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }


        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is YearOfPublishing))
                return false;
            else
                return (this.guid == ((YearOfPublishing)obj).guid);
        }

        public int CompareTo(YearOfPublishing other)
        {
            return year.CompareTo(other.year);
        }

        public override string ToString()
        {
            return year.ToString();
        }

    }

}
