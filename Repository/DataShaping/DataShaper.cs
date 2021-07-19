using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Repository.DataShaping
{
    public class DataShaper<T> : IDataShaper<T> where T: class
    {
        public PropertyInfo[] Properties { get; set; }

        public DataShaper()
        {
            Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldString)
        {
            var requiredProperties = GetRequiredProperties(fieldString);
            return FetchData(entities, requiredProperties);
        }

        public Entity ShapeData(T entity, string fieldString)
        {
            var requiredProperties = GetRequiredProperties(fieldString);
            return FetchDataForEntity(entity, requiredProperties);
        }
       
        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldString)
        {
            var requiredProperties = new List<PropertyInfo>();

            if (!string.IsNullOrWhiteSpace(fieldString))
            {
                var fields = fieldString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach(var field in fields)
                {
                    var property = Properties
                           .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                    if (property == null)
                        continue;

                    requiredProperties.Add(property);
                }
            }
            else
            {
                requiredProperties = Properties.ToList();
            }

            return requiredProperties;
        }

        private IEnumerable<Entity> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<Entity>();

            foreach(var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }

        private Entity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new Entity();

            foreach(var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }

    }
}
