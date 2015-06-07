using Db4objects.Db4o;

namespace DataAccess
{

    class DeleteAction : IUpdateAction
    {

       
        private object objectToDelete;
       
        public DeleteAction(object objectToDelete)
        {
            this.objectToDelete = objectToDelete;
        }

        public void PerformUpdate(IObjectContainer db)
        {
            db.Delete(objectToDelete);
        }

    }

}
