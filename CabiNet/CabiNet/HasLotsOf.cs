using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection;

namespace CabiNet
{
    public class HasLotsOf<T> : Shelf<T> where T : IThing, new()
    {

        public string RelationalColumn { get; private set; }
        private IThing ParentThing;

        public HasLotsOf(IThing relatedParent, OdbcConnection con)
            : base(con)
        {
            RelationalColumn = relatedParent.GetType().Name + "_Id";
            ParentThing = relatedParent;
        }

        public HasLotsOf(IThing relatedParent, string relationalColumn, OdbcConnection con)
            : base(con)
        {
            RelationalColumn = relationalColumn;
            ParentThing = relatedParent;
        }

        /// <summary>
        /// Gets all the related columns
        /// </summary>
        /// <returns>Array of things</returns>
        public override T[] All()
        {
            try
            {
                return EnumerableFor(MySqlBuilder.BuildSelectRelated(RelationalColumn, ParentThing.Id)).ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
