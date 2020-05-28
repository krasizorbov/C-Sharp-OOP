using System.Collections.Generic;

namespace CollectionHierarchy
{
    public abstract class Collection : IAdd
    {
        private List<string> list;

        public Collection()
        {
            this.list = new List<string>();
        }

        protected List<string> List
        {
            get
            {
                return this.list;
            }
        }

        public abstract int Add(string element);
    }
}
