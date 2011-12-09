using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CabiNet
{
    class AttributesExtractor<T> where T : IThing, new()
    {
        private readonly T _thing;
        public AttributesExtractor(T thing)
        {
            _thing = thing;
        }

        public PropertyInfo[] PersistentProperties()
        {
            return _thing.GetType().GetProperties().Where(property =>
                property.GetCustomAttributes(true).Contains(new PersistentAttribute())).ToArray();
        }

        public IDictionary<PropertyInfo, int> MaxLenghtProperties()
        {
            IDictionary<PropertyInfo, int> maxLengths = new Dictionary<PropertyInfo, int>();

            foreach (PropertyInfo property in _thing.GetType().GetProperties().Where(property =>
                        property.GetCustomAttributes(true).Any(attr =>
                            attr.GetType().Name == "MaxLengthAttribute")))
            {
                MaxLengthAttribute attribute = (MaxLengthAttribute)property.GetCustomAttributes(true).FirstOrDefault(attr => ((MemberInfo)((Attribute)attr).TypeId).Name == "MaxLengthAttribute");
                maxLengths.Add(property, attribute.Size);
            }
            return maxLengths;
        }

        public PropertyInfo[] NotNullProperties()
        {
            return _thing.GetType().GetProperties().Where(property =>
                 property.GetCustomAttributes(true).Contains(new NotNullAttribute())).ToArray();
        }

        public IDictionary<string, object> PersistentAttributes()
        {
            IDictionary<string, object> thingProperties = new Dictionary<string, object>();

            foreach (PropertyInfo prop in typeof(T).GetProperties().Where(property => property.GetCustomAttributes(true).Contains(new PersistentAttribute())))
                thingProperties.Add(prop.Name, prop.GetValue(_thing, null));

            return thingProperties;

        }

        public string[] PersistentAttributesList()
        {
            IList<string> thingProperties = new List<string>();

            foreach (PropertyInfo prop in _thing.GetType().GetProperties().Where(property => property.GetCustomAttributes(true).Contains(new PersistentAttribute())))
                thingProperties.Add(prop.Name);

            return thingProperties.ToArray();
        }

        public ThingProperties[] PropertiesWithAttributes()
        {
            IList<ThingProperties> output = new List<ThingProperties>();
            foreach (PropertyInfo property in PersistentProperties())
            {
                ThingProperties prop = new ThingProperties
                                           {
                                               Property = property,
                                               IsNullable = property.GetCustomAttributes(true).Contains(new NotNullAttribute())
                                           };
                switch (property.PropertyType.Name)
                {
                    case "String":
                        prop.Type = "varchar";
                        if (property.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "MaxLengthAttribute"))
                        {
                            prop.IsMaxLength = true;
                            prop.MaxLength = ((MaxLengthAttribute)property.GetCustomAttributes(true).
                                                FirstOrDefault(attr => ((MemberInfo)((Attribute)attr).TypeId).Name == "MaxLengthAttribute")).Size;
                        }
                        else
                            prop.Type += "(255)";
                        break;
                    case "Boolean":
                        prop.Type = "tinyint(1)";
                        break;
                    case "DateTime":
                        prop.Type = "datetime";
                        break;
                    case "Int32":
                        prop.Type = "integer(9)";
                        break;
                    case "Float":
                        prop.Type = "float";
                        break;
                    case "Double":
                        prop.Type = "double";
                        break;
                    case "Int64":
                        prop.Type = "integer(11)";
                        break;

                }

                output.Add(prop);
            }


            return output.ToArray();
        }
    }
}
