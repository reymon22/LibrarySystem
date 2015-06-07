using Db4objects.Db4o;

namespace DataAccess
{

  
    class DeactivateAction : IUpdateAction
    {

       
        private object objectToDeactivate;
        private int deactivateDepth;
        public DeactivateAction(object objectToDeactivate, int deactivateDepth)
        {
            this.objectToDeactivate = objectToDeactivate;
            this.deactivateDepth = deactivateDepth;
        }

        public void PerformUpdate(IObjectContainer db)
        {
            db.Deactivate(objectToDeactivate, deactivateDepth);
        }

    }

}