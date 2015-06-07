using System;
using System.Collections.Generic;

using Db4objects.Db4o;


namespace DataAccess
{

    
    class NativeQueryAction<GenericType> : IQueryAction<GenericType>
                                where GenericType : class
    {

        private Predicate<GenericType> matchPredicate;
        
       
        private int queryDepth;


        
        public NativeQueryAction(Predicate<GenericType> matchPredicate, int queryDepth)
        {
            this.matchPredicate = matchPredicate;
            this.queryDepth = queryDepth;
        }


      
        public IList<GenericType> PerformQuery(IObjectContainer db)
        {
            IList<GenericType> resultObjects = new List<GenericType>();

            IList<GenericType> queryResults = db.Query<GenericType>(matchPredicate);

            foreach (GenericType currentObject in queryResults)
            {
                db.Activate(currentObject, queryDepth);
                resultObjects.Add(currentObject);
            }

            return resultObjects;
        }

    }

}

