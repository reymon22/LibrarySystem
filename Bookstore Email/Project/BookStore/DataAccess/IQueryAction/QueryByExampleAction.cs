using System.Collections.Generic;

using Db4objects.Db4o;


namespace DataAccess
{

    
    class QueryByExampleAction<GenericType> : IQueryAction<GenericType>
                                where GenericType : class
    {

        
        private GenericType queryObject;

        
        private int queryDepth;


       
        public QueryByExampleAction(GenericType queryObject, int queryDepth)
        {
            this.queryObject = queryObject;
            this.queryDepth = queryDepth;
        }


       
        public IList<GenericType> PerformQuery(IObjectContainer db)
        {
            IList<GenericType> resultObjects = new List<GenericType>();

            IObjectSet objectSet = db.QueryByExample(queryObject);

            while (objectSet.HasNext() == true)
            {
                object currentObject = objectSet.Next();
                db.Activate(currentObject, queryDepth);

                resultObjects.Add((GenericType)currentObject);
            }

            return resultObjects;
        }

    }

}

