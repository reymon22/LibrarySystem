using Db4objects.Db4o;

namespace DataAccess
{

    
    class ActivateAction : IUpdateAction
    {

        private object objectToActivate;

        private int activateDepth;

        public ActivateAction(object objectToActivate, int activateDepth)
        {
            this.objectToActivate = objectToActivate;
            this.activateDepth = activateDepth;
        }

        public void PerformUpdate(IObjectContainer db)
        {
            db.Activate(objectToActivate, activateDepth);
        }

    }

}