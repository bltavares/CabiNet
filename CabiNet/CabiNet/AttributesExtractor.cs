using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CabiNet
{
    class AttributesExtractor<T> where T : IThing, new()
    {
        private T Thing;
        public AttributesExtractor(T thing)
        {
            Thing = thing;
        }

        public PropertyInfo[] PersistentProperties()
        {
            return Thing.GetType().GetProperties().Where(property =>
                property.GetCustomAttributes(true).Contains(new PersistentAttribute())).ToArray();
        }

        public IDictionary<PropertyInfo, int> MaxLenghtProperties()
        {
            IDictionary<PropertyInfo, int> MaxLengths = new Dictionary<PropertyInfo, int>();

            foreach (PropertyInfo property in Thing.GetType().GetProperties().Where(property =>
                        property.GetCustomAttributes(true).Any(attr =>
                            attr.GetType().Name == "MaxLengthAttribute")))
            {
                MaxLengthAttribute attribute = (MaxLengthAttribute)property.GetCustomAttributes(true).FirstOrDefault(attr => ((MemberInfo)((Attribute)attr).TypeId).Name == "MaxLengthAttribute");
                MaxLengths.Add(property, attribute.Size);
            }
            return MaxLengths;
        }

        public PropertyInfo[] NotNullProperties()
        {
            return Thing.GetType().GetProperties().Where(property =>
                 property.GetCustomAttributes(true).Contains(new NotNullAttribute())).ToArray();
        }

        public IDictionary<string, object> PersistentAttributes()
        {
            IDictionary<string, object> ThingProperties = new Dictionary<string, object>();

            foreach (PropertyInfo prop in typeof(T).GetProperties().Where(property => property.GetCustomAttributes(true).Contains(new PersistentAttribute())))
                ThingProperties.Add(prop.Name, prop.GetValue(Thing, null));

            return ThingProperties;

        }

        public string[] PersistentAttributesList()
        {
            IList<string> ThingProperties = new List<string>();

            foreach (PropertyInfo prop in Thing.GetType().GetProperties().Where(property => property.GetCustomAttributes(true).Contains(new PersistentAttribute())))
                ThingProperties.Add(prop.Name);

            return ThingProperties.ToArray();
        }

        public ThingProperties[] PropertiesWithAttributes()
        {
            IList<ThingProperties> output = new List<ThingProperties>();
            ThingProperties prop;
            foreach (PropertyInfo property in PersistentProperties())
            {
                prop = new ThingProperties() { property = property };
                prop.IsNullable = property.GetCustomAttributes(true).Contains(new NotNullAttribute());
                switch (property.PropertyType.Name)
                {
                    case "String":
                        prop.type = "varchar";
                        if (property.GetCustomAttributes(true).Any(attr => attr.GetType().Name == "MaxLengthAttribute"))
                        {
                            prop.IsMaxLength = true;
                            prop.MaxLength = ((MaxLengthAttribute)property.GetCustomAttributes(true).
                                                FirstOrDefault(attr => ((MemberInfo)((Attribute)attr).TypeId).Name == "MaxLengthAttribute")).Size;
                        }
                        else
                            prop.type += "(255)";
                        break;
                    case "Boolean":
                        prop.type = "tinyint(1)";
                        break;
                    case "Datetime":
                        prop.type = "datetime";
                        break;
                    case "Int32":
                        prop.type = "integer(9)";
                        break;
                    case "Float":
                        prop.type = "float";
                        break;
                    case "Int64":
                        prop.type = "integer(11)";
                        break;

                }

                output.Add(prop);
            }


            return output.ToArray();
        }
    }
}
