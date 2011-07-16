using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection;

namespace CabiNet
{
    /// <summary>
    /// The IThing is a wrapper for the default properties of a table.
    /// Must me inherited from others classes
    /// </summary>
    public class IThing
    {

        private string CreateThingQuery = null;

        protected Int64 _id = 0;
        private IDictionary<string, object> CachedRalationships = new Dictionary<string, object>();

        protected string[] AttributesList;
        private OdbcConnection _ShelfConnection;
        public void SetConnection(OdbcConnection _con)
        {
            if (_ShelfConnection != null)
                throw new Exception();

            _ShelfConnection = _con;
        }

        [Id]
        public Int64 Id
        {
            get { return _id; }
            set
            {
                if (_id != 0)
                    throw new IdChangeException();
                _id = value;
            }

        }

        /// <summary>
        /// Validate the properties
        /// </summary>
        /// <returns>True if valid</returns>
        /// <exception cref="NotNullException">If non nullable attributes are null</exception>
        /// <exception cref="MaxLengthOverflowException">If a attribute is over the seted length</exception>
        public bool Validate()
        {
            AttributesExtractor<IThing> attributes = new AttributesExtractor<IThing>(this);
            foreach (PropertyInfo prop in attributes.NotNullProperties())
            {
                if (InvalidNotNullProperty(prop))
                    throw new NotNullException(prop.Name);
            }

            foreach (KeyValuePair<PropertyInfo, int> maxprop in attributes.MaxLenghtProperties())
            {
                if (InvalidMaxLengthProperty(maxprop))
                    throw new MaxLengthOverflowException(maxprop.Key.Name, maxprop.Value);
            }
            return true;
        }

        /// <summary>
        /// A safer way to validate the current thing
        /// </summary>
        /// <returns>True if valid</returns>
        public bool IsValid()
        {
            try
            {
                return Validate();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if a property overflowed
        /// </summary>
        /// <param name="restriction">the property with the size</param>
        /// <returns>True if invalid</returns>
        private bool InvalidMaxLengthProperty(KeyValuePair<PropertyInfo, int> restriction)
        {
            return restriction.Key.GetValue(this, null).ToString().Length > restriction.Value;
        }

        private bool InvalidNotNullProperty(PropertyInfo property)
        {
            if (property.PropertyType.Name == "String")
                return string.IsNullOrWhiteSpace(property.GetValue(this, null).ToString());

            return property.GetValue(this, null) == null;
        }

        /// <summary>
        /// Cache the properties names of the thing
        /// </summary>
        /// <returns>Array of properties names</returns>
        public string[] PropertyNames()
        {
            if (AttributesList == null)
            {
                AttributesExtractor<IThing> attributes = new AttributesExtractor<IThing>(this);
                AttributesList = attributes.PersistentAttributesList();
            }
            return AttributesList;
        }

        /// <summary>
        /// Check if there is an existing collumn on the thing
        /// </summary>
        /// <param name="property">The column name to be checked</param>
        /// <returns>True if valid</returns>
        public bool ValidProperty(string property)
        {
            return !PropertyNames().Any(prop => prop != property);
        }

        /// <summary>
        /// Cache and return a relational shelf
        /// </summary>
        /// <typeparam name="T">The IThing related (Using the default classname_id)</typeparam>
        /// <returns>A shelf of the desired type</returns>
        public HasLotsOf<T> HasLotsOf<T>() where T : IThing, new()
        {
            if (_ShelfConnection == null)
                throw new Exception();
            string ralationName = this.GetType().Name + "_Id";
            if (!CachedRalationships.ContainsKey(ralationName))
                CachedRalationships.Add(ralationName, new HasLotsOf<T>(this, _ShelfConnection));

            return (HasLotsOf<T>)CachedRalationships[ralationName];
        }

        /// <summary>
        /// Cache and return a relational shelf
        /// </summary>
        /// <typeparam name="T">The IThing related (Using the default relationalColumn)</typeparam>
        /// <param name="relationalColumn">The column to use on the ralationship</param>
        /// <returns>A shelf of the desired type</returns>
        public HasLotsOf<T> HasLotsOf<T>(string relationalColumn) where T : IThing, new()
        {
            if (_ShelfConnection == null)
                throw new Exception();
            if (!CachedRalationships.ContainsKey(relationalColumn))
                CachedRalationships.Add(relationalColumn, new HasLotsOf<T>(this, relationalColumn, _ShelfConnection));

            return (HasLotsOf<T>)CachedRalationships[relationalColumn];
        }

        /// <summary>
        /// Generate the CREATE TABLE statement for the current Thing Class
        /// </summary>
        /// <returns>Thq SQL Create query</returns>
        public string GenerateCreateSQL()
        {
            if (CreateThingQuery == null)
            {
                AttributesExtractor<IThing> attributes = new AttributesExtractor<IThing>(this);
                MysqlBuilder.MysqlCommandBuilder builder = new MysqlBuilder.MysqlCommandBuilder(GetType().Name);
                CreateThingQuery = builder.BuildCreate(attributes.PropertiesWithAttributes());
            }
            return CreateThingQuery;
        }
    }
}
