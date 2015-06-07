using Db4objects.Db4o;

namespace DataAccess
{
    
    public interface IUpdateAction
    {

        void PerformUpdate(IObjectContainer db);

    }

}
