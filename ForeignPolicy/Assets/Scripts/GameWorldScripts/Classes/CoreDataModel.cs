using System.Collections.Generic;

namespace Assets.Scripts.GameWorldScripts.Classes
{
    [System.Serializable]
    public class CoreDataModel
    {
        public List<NationDataModel> NationData;

        public CoreDataModel()
        {
            NationData = new List<NationDataModel>();
        }
    }
}
