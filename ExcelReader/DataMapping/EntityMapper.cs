using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
namespace ExcelReader
{
    public class EntityMapper
    {
        //public List<TEntity> MapDataTableToEntity(DataTable table)
        //{
        //    List<TEntity> entities = new List<TEntity>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        var entity = MapDataRowToEntity(row);
        //        entities.Add(entity);
        //    }
        //    return entities;
        //}

        //public TEntity MapDataRowToEntity(DataRow row)
        //{
        //    var entityProperties = (typeof(TEntity)).GetProperties()
        //                                            .Where(x => x.GetCustomAttributes(typeof(DataSetAttribute), true).Any())
        //                                            .ToList();
        //    TEntity entity = new TEntity();
        //    foreach (var prop in entityProperties)
        //    {
        //        new EntityPropertyMapper().MapRowDataToEntityByPropertyName(typeof(TEntity), row, prop, entity);
        //    }
        //    return entity;
        //}


    }
}
