using Db4objects.Db4o;

namespace DataAccess
{


    class UpdateStoreAction : IUpdateAction
    {

        private object objectToUpdate;

        public UpdateStoreAction(object objectToUpdate)
        {
            this.objectToUpdate = objectToUpdate;
        }

        public void PerformUpdate(IObjectContainer db)
        {
            db.Store(objectToUpdate);
        }

    }

}
