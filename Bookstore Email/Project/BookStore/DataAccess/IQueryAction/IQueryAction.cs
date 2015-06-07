using System.Collections.Generic;

using Db4objects.Db4o;


namespace DataAccess
{

    
    public interface IQueryAction<GenericType>
                        where GenericType : class
    {

       
        IList<GenericType> PerformQuery(IObjectContainer db);

    }

}

