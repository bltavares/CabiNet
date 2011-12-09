using System.Data.Odbc;
using System.Linq;

namespace CabiNet
{
    /// <summary>
    /// Retrivies child things based on the column name and table name
    /// </summary>
    /// <typeparam name="T">Type of the thing to be returned</typeparam>
    public class HasLotsOf<T> : Shelf<T> where T : IThing, new()
    {
        /// <summary>
        /// The column used on the relationship
        /// </summary>
        public string RelationalColumn { get; private set; }
        private readonly IThing _parentThing;

        /// <summary>
        ///  Retrivies child things based on the column name and table name, setting the relational colummn to
        ///  parent_Id
        /// </summary>
        /// <param name="relatedParent">The parent to be used</param>
        /// <param name="con">The connection</param>
        public HasLotsOf(IThing relatedParent, OdbcConnection con)
            : base(con)
        {
            RelationalColumn = relatedParent.GetType().Name + "_Id";
            _parentThing = relatedParent;
        }

        /// <summary>
        /// Retrivies child things based on the column name and table name
        /// </summary>
        /// <param name="relatedParent">The parent to be used</param>
        /// <param name="relationalColumn">The collumn name</param>
        /// <param name="con">The connection</param>
        public HasLotsOf(IThing relatedParent, string relationalColumn, OdbcConnection con)
            : base(con)
        {
            RelationalColumn = relationalColumn;
            _parentThing = relatedParent;
        }

        /// <summary>
        /// Gets all the related columns
        /// </summary>
        /// <returns>Array of things</returns>
        public override T[] All()
        {
            return EnumerableFor(MySqlBuilder.BuildSelectRelated(RelationalColumn, _parentThing.Id)).ToArray();
        }
    }
}
