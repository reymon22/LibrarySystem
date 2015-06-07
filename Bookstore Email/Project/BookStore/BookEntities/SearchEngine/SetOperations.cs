using System.Collections.Generic;


namespace BookEntities
{
    
    /// <summary>
    /// Set data strucuture operations class.
    /// </summary>
    class SetOperations<T>
    {

        /// <summary>
        /// Intersection operation of two sets, returning the intersection set.
        /// </summary>
        /// <param name="a">The 1st set</param>
        /// <param name="b">The 2nd set</param>
        /// <returns>The intersection set</returns>
        public static List<T> Intersection(List<T> a, List<T> b)
        {
            List<T> result = new List<T>();

            foreach (T element in a)
                if (b.Contains(element) == true)
                    result.Add(element);

            return result;
        }


        /// <summary>
        /// Union operation of two sets, returning the union set.
        /// </summary>
        /// <param name="a">The 1st set</param>
        /// <param name="b">The 2nd set</param>
        /// <returns>The union set</returns>
        public static List<T> Union(List<T> a, List<T> b)
        {
            List<T> result = new List<T>(a);

            foreach (T element in b)
                if (result.Contains(element) == false)
                    result.Add(element);

            result.Sort();

            return result;
        }


        /// <summary>
        /// Difference operation of two sets, returning the difference set.
        /// </summary>
        /// <param name="a">The 1st set</param>
        /// <param name="b">The 2nd set</param>
        /// <returns>The difference set</returns>
        public static List<T> Difference(List<T> a, List<T> b)
        {
            List<T> result = new List<T>();

            foreach (T element in a)
                if (b.Contains(element) == false)
                    result.Add(element);

            return result;
        }

    }

}
