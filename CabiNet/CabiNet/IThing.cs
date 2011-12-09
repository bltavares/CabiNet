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

        private string _createThingQuery;

        protected Int64 _id;
        private readonly IDictionary<string, object> _cachedRalationships = new Dictionary<string, object>();
        private readonly IDictionary<string, IList<object>> _validationActions = new Dictionary<string, IList<object>>();

        protected string[] AttributesList;
        private OdbcConnection _shelfConnection;
        /// <summary>
        /// Set the connetion object to be used on this things
        /// For relational purposes
        /// </summary>
        /// <param name="con">The ODBC connection object</param>
        /// <exception cref="Exception">Already using a connection object</exception>
        public void SetConnection(OdbcConnection con)
        {
            if (_shelfConnection != null)
                throw new Exception("Already using a connection object");

            _shelfConnection = con;
        }
        
        /// <summary>
        /// The id of the current object
        /// Can't set the id if it's already set
        /// </summary>
        /// <exception cref="IdChangeException">Can't set the id if it's already set</exception>
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
        /// Returns whether this thing is new or it's on the database already
        /// </summary>
        /// <returns>True if new</returns>
        public bool IsNew()
        {
            return Id == 0;
        }

        /// <summary>
        /// Validate the properties
        /// </summary>
        /// <returns>True if valid</returns>
        /// <exception cref="NotNullException">If non nullable attributes are null</exception>
        /// <exception cref="MaxLengthOverflowException">If a attribute is over the seted length</exception>
        public bool Validate()
        {
            foreach (object action in ValidationActionsFor("before"))
                action.GetType().GetMethod("Invoke").Invoke(action, new object[] {this});

            foreach (object action in ValidationActionsFor("validation"))
            {
                if (!(bool)action.GetType().GetMethod("Invoke").Invoke(action, new object[] { this }))
                    throw new CustomValidationException();
            }

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

            foreach (object action in ValidationActionsFor("after"))
                action.GetType().GetMethod("Invoke").Invoke(action, new object[] {this});

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
            if (_shelfConnection == null)
                throw new Exception();
            string ralationName = GetType().Name + "_Id";
            if (!_cachedRalationships.ContainsKey(ralationName))
                _cachedRalationships.Add(ralationName, new HasLotsOf<T>(this, _shelfConnection));

            return (HasLotsOf<T>)_cachedRalationships[ralationName];
        }

        /// <summary>
        /// Cache and return a relational shelf
        /// </summary>
        /// <typeparam name="T">The IThing related (Using the default relationalColumn)</typeparam>
        /// <param name="relationalColumn">The column to use on the ralationship</param>
        /// <returns>A shelf of the desired type</returns>
        public HasLotsOf<T> HasLotsOf<T>(string relationalColumn) where T : IThing, new()
        {
            if (_shelfConnection == null)
                throw new Exception();
            if (!_cachedRalationships.ContainsKey(relationalColumn))
                _cachedRalationships.Add(relationalColumn, new HasLotsOf<T>(this, relationalColumn, _shelfConnection));

            return (HasLotsOf<T>)_cachedRalationships[relationalColumn];
        }

        /// <summary>
        /// Generate the CREATE TABLE statement for the current Thing Class
        /// </summary>
        /// <returns>Thq SQL Create query</returns>
        public string GenerateCreateSQL()
        {
            if (_createThingQuery == null)
            {
                AttributesExtractor<IThing> attributes = new AttributesExtractor<IThing>(this);
                MysqlBuilder.MysqlCommandBuilder builder = new MysqlBuilder.MysqlCommandBuilder(GetType().Name);
                _createThingQuery = builder.BuildCreate(attributes.PropertiesWithAttributes());
            }
            return _createThingQuery;
        }

        /// <summary>
        /// Return the shallow copy of the object
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Add a custom validation to the validation actions
        /// </summary>
        /// <typeparam name="T">T: The current class name</typeparam>
        /// <param name="val">The validation</param>
        public void Validation<T>(Func<T, bool> val) where T : IThing
        {
            AddValidationAction("validation", val);
        }

        /// <summary>
        /// Store actions do do with your object before validation
        /// </summary>
        /// <typeparam name="T">The current class name</typeparam>
        /// <param name="action">The action to do</param>
        public void DoBeforeValidation<T>(Action<T> action) where T : IThing
        {
            AddValidationAction("before", action);
        }

        /// <summary>
        /// Store actions do do with your object after validation
        /// </summary>
        /// <typeparam name="T">The current class name</typeparam>
        /// <param name="action">The action to do</param>
        public void DoAfterValidation<T>(Action<T> action) where T : IThing
        {
            AddValidationAction("after", action);
        }

        private IEnumerable<object> ValidationActionsFor(string key)
        {
            return _validationActions.ContainsKey(key) ? _validationActions[key] : new List<Object>();
        }

        private void AddValidationAction(string key, object value)
        {
            if (!_validationActions.Any(dic => dic.Key == key))
            {
                _validationActions.Add(key, new List<object>());
            }
            _validationActions[key].Add(value);
        }

    }
}
